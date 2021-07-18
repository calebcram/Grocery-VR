using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class LeftHandV2 : XRInput
{
    //Variables added for XR toolkit integration
    public InputHelpers.Button MenuButton = InputHelpers.Button.MenuButton;
    public XRNode controller = XRNode.LeftHand;

    public GameObject wallet;
    private bool isPressed;
    private bool pressed;

    private void Start()
    {
        pressed = false;
        //wallet = GameObject.FindGameObjectWithTag("Wallet");
        wallet.SetActive(false);
    }
    private void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(controller), MenuButton, out isPressed);

        if (isPressed && !pressed)
        {
            //If the canvas menu is inactive, activate it
            if (!wallet.activeSelf)
            {
                wallet.SetActive(true);
            }
            //If the canvas menu is active, deactivate it
            else
            {
                wallet.SetActive(false);
            }
            pressed = true;
        } 
        else if (!isPressed) {
            pressed = false;
        }
    }

    //public bool LeftHandOpen()
    //{
    //    //return OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);
    //    return InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(controller), MenuButton, out bool isPressed);
    //    //return 
    //}
}
