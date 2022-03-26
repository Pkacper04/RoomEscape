using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    public void Open()
    {
        
        StartCoroutine("WaitForChestAnimation");

    }

    public void EndAnimation()
    {
        QuestionPanelScript.panelActive = false;
    }  
    
    public void TakeKey()
    {
        StartCoroutine("WaitForKeyAnimation");

    }

    private IEnumerator WaitForChestAnimation()
    {
        yield return new WaitUntil(() => QuestionPanelScript.panelActive == false);
        chestParticles.Play();
        MouseControler.chestOpened = true;
        animator.SetBool("Open", true);
        SFXaudio.clip = chestCracking;
        SFXaudio.Play();

    }
    private IEnumerator WaitForKeyAnimation()
    {
        yield return new WaitUntil(() => QuestionPanelScript.panelActive == false);

        keyParticles.Play();
        PlayerData.SetKey();
        key.GetComponent<MeshRenderer>().enabled = false;
        key.GetComponent<MeshCollider>().enabled = false;

        SFXaudio.clip = pickingUpKey;
        SFXaudio.Play();
    }
}
