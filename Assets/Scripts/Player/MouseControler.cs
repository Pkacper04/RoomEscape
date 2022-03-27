using UnityEngine;
using UnityEngine.InputSystem;
using RoomEscape.Core;
using RoomEscape.Objects;
using RoomEscape.UI;

namespace RoomEscape.Player
{
    public class MouseControler : MonoBehaviour
    {
        [SerializeField] PanelsManager panelManager;

        public static bool chestOpened;

        private ChangeColor objectScript;
        private Camera cam;
        private Vector2 mousePosition = Vector2.zero;

        private void Awake()
        {
            chestOpened = false;
            cam = Camera.main;
        }

        public void OnMouseActions(InputValue input)
        {
            mousePosition = input.Get<Vector2>();

            Ray ray = cam.ScreenPointToRay(mousePosition);

            RaycastHit hit;

            bool hitted = Physics.Raycast(ray, out hit);

            if (hitted)
                MouseHover(hit);
        }

        public void OnClick()
        {
            if (!TimerController.StartTime || PanelsManager.panelActive)
                return;


            Ray ray = cam.ScreenPointToRay(mousePosition);

            RaycastHit hit;

            bool hitted = Physics.Raycast(ray, out hit);

            if (hitted)
                MouseClick(hit);
        }

        private void MouseClick(RaycastHit hit)
        {
            switch (hit.transform.tag)
            {
                case "Chest":
                    if (!chestOpened)
                        panelManager.SetQuestionPanel("Open?", "CHEST");
                    else
                        panelManager.SetInfoBox("Chest is empty!");
                    break;
                case "Key":
                    panelManager.SetQuestionPanel("Take?", "KEY");
                    break;
                case "Door":
                    if (PlayerData.key)
                        panelManager.SetQuestionPanel("Open?", "DOOR");
                    else
                        panelManager.SetInfoBox("You need a key!");
                    break;
            }

        }

        private void MouseHover(RaycastHit hit)
        {

            switch (hit.transform.tag)
            {
                case "Chest":
                    ChangeObjColor(hit);
                    break;
                case "Door":
                    ChangeObjColor(hit);
                    break;
                case "Key":
                    ChangeObjColor(hit);
                    break;
                default:
                    if (objectScript == null)
                        return;
                    objectScript.OutHover();
                    objectScript = null;
                    break;
            }


        }


        private void ChangeObjColor(RaycastHit hit)
        {
            if (objectScript != null && objectScript.transform == hit.transform)
                return;

            if (objectScript != null)
                objectScript.OutHover();

            objectScript = hit.transform.GetComponent<ChangeColor>();
            objectScript.OnHover();
        }


    }
}
