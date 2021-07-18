using System.Collections;
using System.Collections.Generic;
//using TMPro;
using UnityEngine;

public class ProductChecker : MonoBehaviour
{
    //public TMP_Text ListItemsText;

    public static ProductChecker instance;

    [SerializeField] private GameObject winCanvas;

    public List<string> products;

    private bool win;

    public GameObject ExitScanner;

    //Color color0 = Color.red;
    //Color color1 = Color.white;

    //Light lt1;

    private void Awake() 
    {
        instance = this;

        win = false;

        products = new List<string>();

        //lt1 = GetComponent<Light>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<ProductData>().hasBeenPurchased == false)
        {
            //lt1.color = color0;
            //Change color of store lights to a red hue 
            //Disable the store doors so the player cannot leave until paying
            Debug.Log("STORE ALARM HAS BEEN TRIGGERED, CUSTOMER HAS STOLEN FOOD");
        }
        if (other.CompareTag("Product")) {
            
            if (other.GetComponent<ProductData>().hasBeenScanned) {
                if (products.Contains(other.gameObject.name)) {
                    for (int i = 0; i < products.Count; i++) {
                        if (products[i] == other.gameObject.name) {
                            Debug.Log(products[i] + " was removed.");
                            products.Remove(products[i]);

                            if (products.Count == 0) {
                                Win();
                            }
                            return;
                        }
                    }
                }
            }
        }
    }

    private void Win() {
        winCanvas.SetActive(true);
    }
}
