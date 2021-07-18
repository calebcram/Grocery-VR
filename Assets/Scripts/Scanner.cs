using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
//using TMPro;

public class Scanner : MonoBehaviour
{
    //public List<string> products;

    //public TMP_Text ListItemsText;

    [SerializeField] private PayScreen payScreen;


    [SerializeField] private AudioClip beepClip;
    private AudioSource source;

    [SerializeField] private float scanTime = 0.5f;
    private bool scannable;

    void Start()
    {
        scannable = true;
        source = GetComponent<AudioSource>();
    }

    private void EnableScanner() {
        scannable = true;
    }

    private void OnTriggerEnter(Collider other) {
        if (!scannable) return;

        if (other.gameObject.CompareTag("Product")) {
            if (!other.gameObject.GetComponent<ProductData>().hasBeenScanned) {
                source.PlayOneShot(beepClip);
                
                if (!payScreen.resetButton.activeSelf) {
                    payScreen.okayButton.SetActive(true);
                    payScreen.resetButton.SetActive(true);
                    payScreen.instructionText.text = "Press OK when you've scanned all the items you want.";
                }

                scannable = false;
                Invoke("EnableScanner", scanTime);

                ProductData currentProduct = other.gameObject.GetComponent<ProductData>();
                currentProduct.hasBeenScanned = true;

                string productName = other.name.Replace("(Clone)", " ");
                
                float productPrice = currentProduct.price;

                Debug.Log(productName);
                Debug.Log(productPrice);

                payScreen.total += productPrice;

                payScreen.itemSB.Append($"{productName} {productPrice:c} \n");
                payScreen.itemizedText.text = payScreen.itemSB.ToString();

                payScreen.outPutText.text = ($"{payScreen.total:c}");

                payScreen.productList.Add(other.gameObject);
            }
        }
    }
}
