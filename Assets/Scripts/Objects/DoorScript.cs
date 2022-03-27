using UnityEngine;
using RoomEscape.Core;
using RoomEscape.UI;

namespace RoomEscape.Objects
{
    public class DoorScript : MonoBehaviour
    {
        private Animator animator;
        private AudioSource SFXaudio;
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            SFXaudio = GetComponent<AudioSource>();
        }

        public void OpenDoor()
        {
            TimerController.StopTimer();
            animator.SetBool("OpenDoor", true);
            SFXaudio.Play();
        }


        public void AnimationEnd()
        {
            GameOver.GameOverScreen();
        }
    }
}

