using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorColliderScriptVR : MonoBehaviour
{
    private Animator doorAnims;
    private AudioSource source;
    public AudioClip storeDoors;
    //public Transform playerHand;
    //public GameObject product;



    // Start is called before the first frame update
    void Start()
    {
        doorAnims = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        //player = GameObject.FindWithTag("Player");
        //playerHand = GameObject.FindWithTag("PlayerGrabLocation").transform;
    }

    void OnTriggerEnter(Collider player)
    {       
        if (player.gameObject.tag == "Player")
        {
            doorAnims.SetBool("isOpening", true);
            doorAnims.SetBool("isClosing", false);
            source.PlayOneShot(storeDoors);
            //SoundManager.Instance.PlayOneShot(SoundManager.Instance.storeDoors);
        }
    }

    void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            doorAnims.SetBool("isClosing", true);
            doorAnims.SetBool("isOpening", false);
            source.PlayOneShot(storeDoors);
            //SoundManager.Instance.PlayOneShot(SoundManager.Instance.storeDoors);
        }
    }   
}
