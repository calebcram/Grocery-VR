using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class CustomHandV2 : MonoBehaviour
{
    public GameObject oneDollar;
    public GameObject fiveDollar;
    public GameObject tenDollar;
    public GameObject twentyDollar;
    public GameObject fiftyDollar;
    public GameObject penny;
    public GameObject nickel;
    public GameObject dime;
    public GameObject quarter;
    public GameObject creditCard;

    //public GameObject playerMoneyTextBox;
    public Text playerMoneyText;

    public Text debug;

    private bool holdingDollar;
    private GameObject dollar;
    private Transform offset;

    //Variables added for XR toolkit integration
    public InputHelpers.Button rightIndexDown = InputHelpers.Button.MenuButton;
    public InputHelpers.Button rightIndexUp = InputHelpers.Button.MenuButton;
    public InputHelpers.Button getRightHand = InputHelpers.Button.MenuButton;
    public XRNode controller = XRNode.RightHand;
    //The target should be the empty location where the item should spawn at
    public bool ReadyToPickup = false;
    public GameObject Target;
    //If the object has a collision attached set as trigger so we can use OnTriggerEnter and OnTriggerExit
    private void OnTriggerEnter(Collider other)
    {
        ReadyToPickup = true;
    }
    private void OnTriggerExit(Collider other)
    {
        ReadyToPickup = false;
    }


    private void Start()
    {
        //playerMoneyTextBox = GameObject.FindWithTag("PlayerMoneyText");

        offset = GameObject.FindGameObjectWithTag("hand").transform;
        holdingDollar = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "icon" && PlayerMoneyHandlerVR.PlayerMoney > 0)
        {
            if (other.name == "One")
            {
                if (RightIndexDown())
                {
                    if (holdingDollar == false)
                    {
                        TakeMoneyOneDollar();
                    }
                }
            }

            if (other.name == "Five")
            {
                if (RightIndexDown())
                {
                    if (holdingDollar == false)
                    {
                        TakeMoneyFiveDollar();
                    }
                }
            }

            if (other.name == "Ten")
            {
                if (RightIndexDown())
                {
                    if (holdingDollar == false)
                    {
                        TakeMoneyTenDollar();
                    }
                }
            }

            if (other.name == "Twenty")
            {
                if (RightIndexDown())
                {
                    if (holdingDollar == false)
                    {
                        TakeMoneyTwentyDollar();
                    }
                }
            }

            if (other.name == "Fifty")
            {
                if (RightIndexDown())
                {
                    if (holdingDollar == false)
                    {
                        TakeMoneyFiftyDollar();
                    }
                }
            }
            if (other.name == "CreditCard")
            {
                if (RightIndexDown())
                {
                    if (holdingDollar == false)
                    {
                        TakeCreditCard();
                    }
                }
            }
            if (other.name == "Penny")
            {
                if (RightIndexDown())
                {
                    if (holdingDollar == false)
                    {
                        TakeMoneyPenny();
                    }
                }
            }
            if (other.name == "Nickel")
            {
                if (RightIndexDown())
                {
                    if (holdingDollar == false)
                    {
                        TakeMoneyNickel();
                    }
                }
            }
            if (other.name == "Dime")
            {
                if (RightIndexDown())
                {
                    if (holdingDollar == false)
                    {
                        TakeMoneyDime();
                    }
                }
            }
            if (other.name == "Quarter")
            {
                if (RightIndexDown())
                {
                    if (holdingDollar == false)
                    {
                        TakeMoneyQuarter();
                    }
                }
            }
        }
    }

    private void Update()
    {
        //This is to allow the system to look for the XR toolkit controller
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(controller), rightIndexDown, out bool isPressed);
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(controller), rightIndexUp, out bool isReleased);
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(controller), getRightHand, out bool gotRightHand); 
        //Rudimentary attempt at using Ontriggerenter/Exit to control spawning money
        //if (isPressed == true && ReadyToPickup == true)
        //{
        //    Instantiate(this.gameObject, Target.transform);
        //    Destroy(this.gameObject);
        //}

        if (RightIndexUp())
        {
            if (holdingDollar == true)
            {
                DropMoney();
            }
        }

        else if (GetRightHand())
        {
            if (holdingDollar == true)
            {
                UpdateLocation();
            }
        }

        //playerMoneyText = playerMoneyTextBox.GetComponent<Text>();
        //This was causing the "NullReferenceException: Object reference not set to an instance of an objject CustomHandV2.Update() (at Assets/Scripts/Old/VR/CustomHandV2.cs:197)
    }

    private void FixedUpdate()
    {
        playerMoneyText.text = "Player Money: " + PlayerMoneyHandlerVR.PlayerMoney.ToString("00");
    }

    public void UpdateLocation()
    {
        dollar.transform.localPosition = offset.position;
        dollar.transform.localRotation = offset.rotation;
    }

    public bool RightIndexDown()
    {
        //return OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger);
        return InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(controller), rightIndexDown, out bool isPressed);
    }

    public bool GetRightHand()
    {
        //return OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger);
        return InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(controller), getRightHand, out bool gotRightHand);
    }

    public bool RightIndexUp()
    {
        //return OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger);
        return InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(controller), rightIndexUp, out bool isReleased);
    }

    public void TakeMoneyOneDollar()
    {
        holdingDollar = true;
        //dollar = Instantiate(oneDollar);
        //dollar.GetComponent<OVRGrabbable>().GrabBegin(this.GetComponent<OVRGrabber>(), dollar.GetComponent<Collider>());
        Instantiate(oneDollar.gameObject, Target.transform);
        oneDollar.GetComponent<Rigidbody>().isKinematic = true;
        PlayerMoneyHandlerVR.PlayerMoney = PlayerMoneyHandlerVR.PlayerMoney - 1.00f;
        Debug.Log("One Dollar Withdrawn, Current PlayerMoney balance is: " + PlayerMoneyHandlerVR.PlayerMoney);
    }

    public void TakeMoneyFiveDollar()
    {
        holdingDollar = true;
        //dollar = Instantiate(fiveDollar);
        //dollar.GetComponent<OVRGrabbable>().GrabBegin(this.GetComponent<OVRGrabber>(), dollar.GetComponent<Collider>());
        Instantiate(fiveDollar.gameObject, Target.transform);
        fiveDollar.GetComponent<Rigidbody>().isKinematic = true;
        PlayerMoneyHandlerVR.PlayerMoney = PlayerMoneyHandlerVR.PlayerMoney - 5.00f;
        Debug.Log("Five Dollars Withdrawn, Current PlayerMoney balance is: " + PlayerMoneyHandlerVR.PlayerMoney);
    }

    public void TakeMoneyTenDollar()
    {
        holdingDollar = true;
        //dollar = Instantiate(tenDollar);
        //dollar.GetComponent<OVRGrabbable>().GrabBegin(this.GetComponent<OVRGrabber>(), dollar.GetComponent<Collider>());
        Instantiate(tenDollar.gameObject, Target.transform);
        tenDollar.GetComponent<Rigidbody>().isKinematic = true;
        PlayerMoneyHandlerVR.PlayerMoney = PlayerMoneyHandlerVR.PlayerMoney - 10.00f;
        Debug.Log("Ten Dollars Withdrawn, Current PlayerMoney balance is: " + PlayerMoneyHandlerVR.PlayerMoney);
    }

    public void TakeMoneyTwentyDollar()
    {
        holdingDollar = true;
        //dollar = Instantiate(twentyDollar);
        //dollar.GetComponent<OVRGrabbable>().GrabBegin(this.GetComponent<OVRGrabber>(), dollar.GetComponent<Collider>());
        Instantiate(twentyDollar.gameObject, Target.transform);
        twentyDollar.GetComponent<Rigidbody>().isKinematic = true;
        PlayerMoneyHandlerVR.PlayerMoney = PlayerMoneyHandlerVR.PlayerMoney - 20.00f;
        Debug.Log("Twenty Dollars Withdrawn, Current PlayerMoney balance is: " + PlayerMoneyHandlerVR.PlayerMoney);
    }

    public void TakeMoneyFiftyDollar()
    {
        holdingDollar = true;
        //dollar = Instantiate(fiftyDollar);
        //dollar.GetComponent<OVRGrabbable>().GrabBegin(this.GetComponent<OVRGrabber>(), dollar.GetComponent<Collider>());
        Instantiate(fiftyDollar.gameObject, Target.transform);
        fiftyDollar.GetComponent<Rigidbody>().isKinematic = true;
        PlayerMoneyHandlerVR.PlayerMoney = PlayerMoneyHandlerVR.PlayerMoney - 50.00f;
        Debug.Log("Fifty Dollars Withdrawn, Current PlayerMoney balance is: " + PlayerMoneyHandlerVR.PlayerMoney);
    }

    public void TakeCreditCard()
    {
        holdingDollar = true;
        //dollar = Instantiate(creditCard);
        //dollar.GetComponent<OVRGrabbable>().GrabBegin(this.GetComponent<OVRGrabber>(), dollar.GetComponent<Collider>());
        Instantiate(creditCard.gameObject, Target.transform);
        creditCard.GetComponent<Rigidbody>().isKinematic = true;
        Debug.Log("You successfully grabbed CREDIT CARD from your wallet");
    }

    public void TakeMoneyPenny()
    {
        holdingDollar = true;
        //dollar = Instantiate(penny);
        //dollar.GetComponent<OVRGrabbable>().GrabBegin(this.GetComponent<OVRGrabber>(), dollar.GetComponent<Collider>());
        Instantiate(penny.gameObject, Target.transform);
        penny.GetComponent<Rigidbody>().isKinematic = true;
        PlayerMoneyHandlerVR.PlayerMoney = PlayerMoneyHandlerVR.PlayerMoney - 0.01f;
        Debug.Log("One Penny Withdrawn, Current PlayerMoney balance is: " + PlayerMoneyHandlerVR.PlayerMoney);
    }

    public void TakeMoneyNickel()
    {
        holdingDollar = true;
        //dollar = Instantiate(nickel);
        //dollar.GetComponent<OVRGrabbable>().GrabBegin(this.GetComponent<OVRGrabber>(), dollar.GetComponent<Collider>());
        Instantiate(nickel.gameObject, Target.transform);
        nickel.GetComponent<Rigidbody>().isKinematic = true;
        PlayerMoneyHandlerVR.PlayerMoney = PlayerMoneyHandlerVR.PlayerMoney - 0.05f;
        Debug.Log("One Nickel Withdrawn, Current PlayerMoney balance is: " + PlayerMoneyHandlerVR.PlayerMoney);
    }

    public void TakeMoneyDime()
    {
        holdingDollar = true;
        //dollar = Instantiate(dime);
        //dollar.GetComponent<OVRGrabbable>().GrabBegin(this.GetComponent<OVRGrabber>(), dollar.GetComponent<Collider>());
        Instantiate(dime.gameObject, Target.transform);
        dime.GetComponent<Rigidbody>().isKinematic = true;
        PlayerMoneyHandlerVR.PlayerMoney = PlayerMoneyHandlerVR.PlayerMoney - 0.10f;
        Debug.Log("One Dime Withdrawn, Current PlayerMoney balance is: " + PlayerMoneyHandlerVR.PlayerMoney);
    }

    public void TakeMoneyQuarter()
    {
        holdingDollar = true;
        //dollar = Instantiate(quarter);
        //dollar.GetComponent<OVRGrabbable>().GrabBegin(this.GetComponent<OVRGrabber>(), dollar.GetComponent<Collider>());
        Instantiate(quarter.gameObject, Target.transform);
        quarter.GetComponent<Rigidbody>().isKinematic = true;
        PlayerMoneyHandlerVR.PlayerMoney = PlayerMoneyHandlerVR.PlayerMoney - 0.25f;
        Debug.Log("One Quarter Withdrawn, Current PlayerMoney balance is: " + PlayerMoneyHandlerVR.PlayerMoney);
    }

    private void DropMoney()
    {
        holdingDollar = false;
        dollar.transform.parent = null;
        //dollar.GetComponent<Rigidbody>().useGravity = true;
        dollar.GetComponent<Rigidbody>().isKinematic = false;
        dollar.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        Debug.Log("MONEY DROPPED FROM HAND " + PlayerMoneyHandlerVR.PlayerMoney);
    }
}
