using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class LeftHand : MonoBehaviour
{
    //Variables added for XR toolkit integration
    public InputHelpers.Button SecondaryIndexTrigger = InputHelpers.Button.MenuButton;
    public XRNode controller = XRNode.LeftHand;

    private GameObject wallet;

    private void Start()
    {
        wallet = GameObject.Find("Wallet");
        wallet.SetActive(false);
    }
    private void Update()
    {
        if (LeftHandOpen())
        {
            Open();
        }
        else
        {
            Close();
        }
    }
    public void Open()
    {
        wallet.SetActive(true);
    }

    public void Close()
    {
        wallet.SetActive(false);
    }

    public bool LeftHandOpen()
    {
        //return OVRInput.Get(OVRInput.Button.PrimaryHandTrigger);
        return InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(controller), SecondaryIndexTrigger, out bool isPressed);
    }
}
