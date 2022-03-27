using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using RoomEscape.Objects;
using Zenject;

namespace RoomEscape.UI
{
    public class PanelsManager : MonoBehaviour
    {
        public static bool panelActive;

        [SerializeField] Animator questionPanelAnimator;
        [SerializeField] Animator infoPanelAnimator;

        [SerializeField] TMP_Text questionTitle;
        [SerializeField] TMP_Text infoTitle;

        [SerializeField] Button buttonYes;


        private ChestScript chest;
        private DoorScript door;


        private bool doorActive = false;

        void Start()
        {
            chest = GameObject.FindObjectOfType<ChestScript>();
            door = GameObject.FindObjectOfType<DoorScript>();
        }

        #region InforPanel

        public void SetInfoBox(string title)
        {
            infoTitle.text = title;
            ShowInfoBox();
        }

        public void ShowInfoBox()
        {
            infoPanelAnimator.SetBool("Show", true);
            panelActive = true;
        }

        public void HideInfoBox()
        {
            infoPanelAnimator.SetBool("Show", false);
            StartCoroutine("Wait", infoPanelAnimator);
        }

        #endregion

        #region QuestionPanel
        public void SetQuestionPanel(string title, string buttonConfig)
        {
            questionTitle.text = title;
            buttonYes.onClick.RemoveAllListeners();
            switch (buttonConfig)
            {
                case "CHEST":
                    buttonYes.onClick.AddListener(OpenChest);
                    break;
                case "KEY":
                    buttonYes.onClick.AddListener(TakeKey);
                    break;
                case "DOOR":
                    buttonYes.onClick.AddListener(OpenDoor);
                    break;
            }

            questionPanelAnimator.SetBool("Show", true);
            panelActive = true;

        }

        public void No()
        {
            questionPanelAnimator.SetBool("Show", false);
            StartCoroutine("Wait", questionPanelAnimator);
        }

        public void OpenChest()
        {
            questionPanelAnimator.SetBool("Show", false);
            chest.Open();
            StartCoroutine("Wait", questionPanelAnimator);
        }

        public void TakeKey()
        {
            chest.TakeKey();
            questionPanelAnimator.SetBool("Show", false);
            StartCoroutine("Wait", questionPanelAnimator);
        }

        public void OpenDoor()
        {
            questionPanelAnimator.SetBool("Show", false);
            doorActive = true;
            StartCoroutine("Wait", questionPanelAnimator);

        }

        #endregion

        private IEnumerator Wait(Animator anim)
        {
            yield return new WaitUntil(() => anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Idle");
            panelActive = false;

            if (doorActive)
                door.OpenDoor();
        }


    }

}
