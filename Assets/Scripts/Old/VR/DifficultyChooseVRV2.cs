using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Text;

public class DifficultyChooseVRV2 : MonoBehaviour
{
    public GameObject player;

    public GameObject difficultyMenuCanvas;

    public GameObject mainScreenCanvas;

    //public GameObject eventSystem;

    //public GameObject easyDifficultyButton;

    public GameObject product;

    public GameObject[] products;

    public List<GameObject> allProducts;

    public GameObject currentProduct;

    public string currentProductName;

    public int count = 0;

    public int productIndex;

    public GameObject shoppingListTextObject;
    public TextMeshProUGUI shoppingListText;

    public StringBuilder listText;

    public bool noDifficultyChosen;

    public static bool easyDifficulty = false;

    public static bool normalDifficulty = false;

    public static bool hardDifficulty = false;

    public bool chooseItemsMode = false;


    //public GameObject moneySpawnButton;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        difficultyMenuCanvas = GameObject.FindWithTag("DifficultyMenuCanvas");

        //eventSystem = GameObject.FindWithTag("EventSystem");
        //easyDifficultyButton = GameObject.FindWithTag("EasyModeButton");

        //product = productManager.GetComponent<ProductManager>().product;
        //products = productManager.GetComponent<ProductManager>().products;

        shoppingListTextObject = GameObject.FindWithTag("shoppingListText");
        shoppingListText = shoppingListTextObject.GetComponent<TMPro.TextMeshProUGUI>();

        listText = new StringBuilder();

        //Time.timeScale = 0;

        noDifficultyChosen = true;
    }

    void Update()
    {
        //if (Input.GetButtonDown("Oculus_CrossPlatform_Button4") && noDifficultyChosen == true)
        //{
        //    eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(easyDifficultyButton);
        //}


        if (easyDifficulty)
        {
            while (count < 3)
            {
                count++;
                var objectsToFind = Random.Range(0, products.Length);

                product = GameObject.FindGameObjectWithTag("Product");
                products = GameObject.FindGameObjectsWithTag("Product");
                productIndex = Random.Range(0, products.Length);
                currentProduct = products[productIndex];
                Debug.Log(currentProduct.name);

                ProductChecker.instance.products.Add(currentProduct.name);

                //currentProduct.GetComponent<Light>().enabled = true;

                listText.Append(currentProduct.name.Replace("(Clone)", " ").ToString() + " \n");
                shoppingListText.text = listText.ToString();
                Debug.Log("Difficulty was set to EASY");
            }
            //closeDifficultyMenu();   
        }
        if (normalDifficulty)
        {
            while (count < 6)
            {
                count++;
                var objectsToFind = Random.Range(0, products.Length);

                product = GameObject.FindGameObjectWithTag("Product");
                products = GameObject.FindGameObjectsWithTag("Product");
                productIndex = Random.Range(0, products.Length);
                currentProduct = products[productIndex];
                Debug.Log(currentProduct.name);

                ProductChecker.instance.products.Add(currentProduct.name);

                //currentProduct.GetComponent<Light>().enabled = true;

                listText.Append(currentProduct.name.Replace("(Clone)", " ").ToString() + " \n");
                shoppingListText.text = listText.ToString();
            }
            //closeDifficultyMenu();
            Debug.Log("Difficulty was set to NORMAL");
        }

        if (hardDifficulty)
        {
            while (count < 9)
            {
                

                count++;
                var objectsToFind = Random.Range(0, products.Length);

                product = GameObject.FindGameObjectWithTag("Product");
                products = GameObject.FindGameObjectsWithTag("Product");
                productIndex = Random.Range(0, products.Length);
                currentProduct = products[productIndex];

                ProductChecker.instance.products.Add(currentProduct.name);

                //currentProduct.GetComponent<Light>().enabled = true;

                listText.Append(currentProduct.name.Replace("(Clone)", " ").ToString() + " \n");
                shoppingListText.text = listText.ToString();
            }
            //closeDifficultyMenu();
            Debug.Log("Difficulty was set to HARD");
        }
    }

    public void ResetDifficulty()
    {
        easyDifficulty = false;
        normalDifficulty = false;
        hardDifficulty = false;
    }

    public void SetEasyDifficulty()
    {
        ResetDifficulty();
        easyDifficulty = true;
    }

    public void SetNormalDifficulty()
    {
        ResetDifficulty();
        normalDifficulty = true;
    }

    public void SetHardDifficulty()
    {
        ResetDifficulty();
        hardDifficulty = true;
    }

    public void SetChooseItemsMode()
    {
        closeDifficultyMenu();
    }

    public void closeDifficultyMenu()
    {
        //Time.timeScale = 1;
        Destroy(difficultyMenuCanvas);
        //difficultyMenuCanvas.SetActive(false);
        noDifficultyChosen = false;
    }
}
