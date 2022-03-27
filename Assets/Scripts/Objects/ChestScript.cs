using System.Collections;
using UnityEngine;
using RoomEscape.Player;
using RoomEscape.UI;

namespace RoomEscape.Objects
{
    public class ChestScript : MonoBehaviour
    {
        private Animator animator;
        private AudioSource SFXaudio;

        [SerializeField] GameObject key;

        [SerializeField] ParticleSystem keyParticles;
        [SerializeField] ParticleSystem chestParticles;

        [SerializeField] AudioClip chestCracking;
        [SerializeField] AudioClip pickingUpKey;
        private void Start()
        {
            animator = GetComponent<Animator>();
            SFXaudio = GetComponent<AudioSource>();
        }

        public void Open()
        {

            StartCoroutine("WaitForChestAnimation");

        }

        public void TakeKey()
        {
            StartCoroutine("WaitForKeyAnimation");

        }

        private IEnumerator WaitForChestAnimation()
        {
            yield return new WaitUntil(() => PanelsManager.panelActive == false);

            chestParticles.Play();
            MouseControler.chestOpened = true;
            animator.SetBool("Open", true);
            SFXaudio.clip = chestCracking;
            SFXaudio.Play();

        }
        private IEnumerator WaitForKeyAnimation()
        {
            yield return new WaitUntil(() => PanelsManager.panelActive == false);

            keyParticles.Play();
            PlayerData.key = true;
            key.GetComponent<MeshRenderer>().enabled = false;
            key.GetComponent<MeshCollider>().enabled = false;
            SFXaudio.clip = pickingUpKey;
            SFXaudio.Play();
        }
    }
}
