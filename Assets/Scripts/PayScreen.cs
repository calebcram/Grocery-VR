using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class PayScreen : MonoBehaviour
{
    public TMP_Text ListItemsText;

    public GameObject okayButton;
    public GameObject okayButton2;
    public GameObject resetButton;
    public GameObject cashButton;
    public GameObject creditButton;

    [SerializeField] private GameObject scanner;
    [SerializeField] private GameObject moneySlot;
    [SerializeField] private GameObject cardReader;

    [SerializeField] private AudioClip buttonClip;
    [SerializeField] private AudioClip purchaseClip;
    private AudioSource source;

    [HideInInspector] public StringBuilder itemSB;
    public TextMeshProUGUI itemizedText;
    [SerializeField] private TextMeshProUGUI totalText;
    public TextMeshProUGUI outPutText;
    public TextMeshProUGUI instructionText;

    [HideInInspector] public float total;

    [HideInInspector] public List<GameObject> productList;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        itemSB = new StringBuilder();

        total = 0.00f;

        productList = new List<GameObject>();
    }

    public void ClickOkay() {
        okayButton.SetActive(false);
        cashButton.SetActive(true);
        creditButton.SetActive(true);

        scanner.GetComponent<Collider>().enabled = false;

        source.PlayOneShot(buttonClip);

        instructionText.text = "Choose a payment method.";
    }

    public void ClickReset() {
        okayButton.SetActive(false);
        okayButton2.SetActive(false);
        resetButton.SetActive(false);
        cashButton.SetActive(false);
        creditButton.SetActive(false);

        itemSB = new StringBuilder();
        itemizedText.text = itemSB.ToString();
        
        total = 0.00f;
        outPutText.text = ($"{total:c}");

        totalText.text = "Total:";

        //totalText.text = "$" + PayScreen.outPutText.ToString("00.00");

        moneySlot.GetComponent<Collider>().enabled = false;
        cardReader.GetComponent<Collider>().enabled = false;
        scanner.GetComponent<Collider>().enabled = true;

        foreach (GameObject o in productList) {
            o.GetComponent<ProductData>().hasBeenScanned = false;
        }
        productList.Clear();

        source.PlayOneShot(buttonClip);

        instructionText.text = "Scan item to begin.";
    }

    public void ClickCash() {
        cashButton.SetActive(false);
        creditButton.SetActive(false);

        moneySlot.GetComponent<Collider>().enabled = true;

        source.PlayOneShot(buttonClip);

        instructionText.text = "Please hand cash over to the cashier.";
    }

    public void ClickCredit() {
        cashButton.SetActive(false);
        creditButton.SetActive(false);

        cardReader.GetComponent<Collider>().enabled = true;

        source.PlayOneShot(buttonClip);

        instructionText.text = "Please insert card into the card reader.";
    }

    public void CheckIfEnough() {
        if (total <= 0.00f) {
            moneySlot.GetComponent<Collider>().enabled = false;
            cardReader.GetComponent<Collider>().enabled = false;
            okayButton2.SetActive(true);

            instructionText.text = "Press OK to complete purchase.";
        }
        if (total < 0.00f) {
            totalText.text = "Change:";
        }
    }

    public void ClickOkayTwo() {
        if (total < 0.00f) {
            //Give change
        }

        itemSB = new StringBuilder();
        itemizedText.text = itemSB.ToString();

        total = 0.00f;
        outPutText.text = ($"{total:c}");

        totalText.text = "Total:";

        okayButton2.SetActive(false);
        resetButton.SetActive(false);

        foreach (GameObject o in productList) {
            o.GetComponent<ProductData>().hasBeenPurchased = true;
        }
        productList.Clear();

        source.PlayOneShot(purchaseClip);

        instructionText.text = "Thank you for shopping at AGrocery!";
        Invoke("ClickReset", 3f);
        //Strikethrough the text on the shopping list 
        ListItemsText.fontStyle = FontStyles.Strikethrough;
    }
}
