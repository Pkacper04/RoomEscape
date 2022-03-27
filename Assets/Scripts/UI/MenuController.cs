using UnityEngine;
using TMPro;
using RoomEscape.Player;
using RoomEscape.Core;

namespace RoomEscape.UI
{
    public class MenuController : MonoBehaviour
    {
        private static Animator animator;
        [SerializeField] private TMP_Text bestScore;


        void Start()
        {
            animator = GetComponent<Animator>();
            if (SaveSystem.LoadScore() != -1)
                bestScore.text = "Best score: " + SaveSystem.LoadScore() + "s";
            else
                bestScore.text = "Best score: ";
        }

        public void StartGame()
        {
            animator.SetBool("GameStarted", true);
        }

        public void AnimationEnd()
        {
            TimerController.StartTimer();
        }

        public static void EndGame()
        {
            animator.SetBool("GameStarted", false);
        }
    }
}
