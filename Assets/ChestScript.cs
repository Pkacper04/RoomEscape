using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    private Animator animator;
    [SerializeField] GameObject key;
    [SerializeField] ParticleSystem keyParticles;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    public void Open()
    {
        MouseControler.chestOpened = true;
        animator.SetBool("Open", true);
    }

    public void EndAnimation()
    {
        QuestionPanelScript.panelActive = false;
    }  
    
    public void TakeKey()
    {
        keyParticles.Play();
        PlayerData.SetKey();
        key.GetComponent<MeshRenderer>().enabled = false;
        key.GetComponent<MeshCollider>().enabled = false;
    }
}
