using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHandlerScript : MonoBehaviour
{
    public GameObject player;

    public string dialogue1;

    public string dialogue2;

    public string dialogue3;

    public GameObject thoughtBubbleCanvas;

    public GameObject EasterEggButton;

    public GameObject thoughtBubbleTextBox;
    public Text thoughtBubbleText;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            DialogueChoose();
            thoughtBubbleCanvas.GetComponent<Canvas>().enabled = true;
        }
    }

    void OnTriggerStay(Collider Player)
    {
        if (Player.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            DialogueChoose();
        }        
    }
    void OnTriggerExit(Collider Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            thoughtBubbleCanvas.GetComponent<Canvas>().enabled = false;
        }
    }

    void DialogueChoose()
    {
        var dialogueOptionToSay = Random.Range(0, 3);

        if (dialogueOptionToSay == 0)
        {
            EasterEggButton.SetActive(false);
            thoughtBubbleText = thoughtBubbleTextBox.GetComponent<Text>();
            thoughtBubbleText.text = " " + dialogue1;
        }
        else if (dialogueOptionToSay == 1)
        {
            thoughtBubbleText = thoughtBubbleTextBox.GetComponent<Text>();
            thoughtBubbleText.text = " " + dialogue2;
            //There's some spagehti behind this code. If you want to know more about it email: caleb.cram@gmail.com
            EasterEggButton.SetActive(true);
        }
        else if (dialogueOptionToSay == 2)
        {
            EasterEggButton.SetActive(false);
            thoughtBubbleText = thoughtBubbleTextBox.GetComponent<Text>();
            thoughtBubbleText.text = " " + dialogue3;
        }
    }
    }