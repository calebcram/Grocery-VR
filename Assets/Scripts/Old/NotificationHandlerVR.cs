﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NotificationHandlerVR : MonoBehaviour
{
    public GameObject player;

    public GameObject playerHand;

    public GameObject textBox;
    public Text text;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerHand = GameObject.FindWithTag("PlayerGrabLocation");

        textBox = GameObject.FindWithTag("NotificationText");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider Player)
    {
        if (Player.gameObject.tag == "CheckoutCounter")
        {
            text = textBox.GetComponent<Text>();
            text.text = "Match the offer to the total cost and press VR PURCHASE BUTTON to complete the purchase!";
        }
    }

    void OnTriggerStay(Collider Player)
    {

        if (Player.gameObject.tag == "Product1")
        {
            text = textBox.GetComponent<Text>();
            text.text = "This item costs 1.00. Use your VR hands to pick it up!";
        }
        if (Player.gameObject.tag == "Product2")
        {
            text = textBox.GetComponent<Text>();
            text.text = "This item costs 1.50. Use your VR hands to pick it up!";
        }
        if (Player.gameObject.tag == "Product3")
        {
            text = textBox.GetComponent<Text>();
            text.text = "This item costs 2.00. Use your VR hands to pick it up!";
        }
    }

    /*void OnTriggerExit(Collider Player)
    {
        if (Player.gameObject.tag == "NotificationCollider")
        {
            text = textBox.GetComponent<Text>();
            text.text = "Press WASD to move and Left Shift to run.";
        }
    }*/
}
