using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoneyHandlerVR : MonoBehaviour
{
    public static float PlayerMoney = 100f;

    public static float TotalCost = 0.00f;

    public static float CurrentOffer = 0.00f;

    public static float Change = 0.00f;

    public static float Penny = 0.01f;

    public static float Nickel = 0.05f;

    public static float Dime = 0.10f;

    public static float Quarter = 0.25f;

    public static float OneDollar = 1.00f;

    public static float FiveDollars = 5.00f;

    public static float TenDollars = 10.00f;

    public static float TwentyDollars = 20.00f;

    public Button OneD;
    public Button FiveD;
    public Button TenD;
    public Button TwentyD;
    public Button FiftyD;
    public Button OneC;
    public Button FiveC;
    public Button TenC;
    public Button TwennyFiveC;

    //public GameObject playerMoneyTextBox;
    public Text playerMoneyText;

    // Start is called before the first frame update
    void Start()
    { 
        //playerMoneyTextBox = GameObject.FindWithTag("PlayerMoneyText");
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMoney >= 100)
        {
            PlayerMoney = 100.00f;
        }
        if (PlayerMoney >= 49.995f)
        {
            FiftyD.enabled = true;
        }
        else
        {
            FiftyD.enabled = false;
        }
        if (PlayerMoney >= 19.995f)
        {
            TwentyD.enabled = true;
        }
        else
        {
            TwentyD.enabled = false;
        }
        if (PlayerMoney >= 9.995f)
        {
            TenD.enabled = true;
        }
        else
        {
            TenD.enabled = false;
        }
        if (PlayerMoney >= 4.995f)
        {
           FiveD.enabled = true;
        }
        else
        {
            FiveD.enabled = false;
        }
        if (PlayerMoney >= 0.995f)
        {
            OneD.enabled = true;
        }
        else
        {
            OneD.enabled = false;
        }
        if (PlayerMoney >= 0.245f)
        {
            TwennyFiveC.enabled = true;
        }
        else
        {
            TwennyFiveC.enabled = false;
        }
        if (PlayerMoney >= 0.095f)
        {
            TenC.enabled = true;
        }
        else
        {
            TenC.enabled = false;
        }
        if (PlayerMoney >= 0.045f)
        {
            FiveC.enabled = true;
        }
        else
        {
            FiveC.enabled = false;
        }
        if (PlayerMoney >= 0.005f)
        {
            OneC.enabled = true;
        }
        else
        {
            OneC.enabled = false;
        }



        if (PlayerMoney <= 0)
        {
            PlayerMoney = 0.00f;
            Debug.Log("You spent all of your money!");
        }
        //Displays player money in wallet
        playerMoneyText.text = "$" + PlayerMoney.ToString("00.00");
    }
}