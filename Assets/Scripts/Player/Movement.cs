using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using RoomEscape.Core;

namespace RoomEscape.Player
{
    public class Movement : MonoBehaviour
    {
        private Rigidbody rigid;

        [SerializeField] private float movementSpeed = 7;
        [SerializeField] private float rotationSpeed = 100;
        [SerializeField] private float shakeForce = 0.1f;
        [SerializeField] private float shakeSpeed = 0.1f;

        private bool inShake = false;
        private Vector3 movement = Vector3.zero;
        private float rotation = 0;

        void Start()
        {
            rigid = GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (!TimerController.StartTime)
                return;

            Move();

        }

        private void Move()
        {
            transform.eulerAngles = transform.localRotation.eulerAngles + new Vector3(0, rotation * rotationSpeed * Time.deltaTime, 0);

            float CameraRotation = transform.rotation.eulerAngles.y;

            rigid.position += Quaternion.Euler(0, CameraRotation, 0) * movement * movementSpeed * Time.deltaTime;

            if (rigid.velocity != Vector3.zero)
                rigid.velocity = Vector3.zero;

            #region DoSprawdzenia
            if (!inShake && movement != Vector3.zero)
                StartCoroutine("CameraShaking");
            else if (movement == Vector3.zero)
            {
                StopCoroutine("CameraShaking");
                inShake = false;
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            }
            #endregion
        }

        public void OnMove(InputValue input)
        {
            movement = new Vector3(input.Get<Vector2>().x, 0, input.Get<Vector2>().y);
        }

        public void OnRotate(InputValue input)
        {
            rotation = input.Get<float>();
        }

        private IEnumerator CameraShaking()
        {
            inShake = true;
            transform.eulerAngles += new Vector3(shakeForce, 0, 0);
            yield return new WaitForSeconds(shakeSpeed);
            transform.eulerAngles -= new Vector3(shakeForce, 0, 0);
            yield return new WaitForSeconds(shakeSpeed);
            inShake = false;
        }
    }
}
