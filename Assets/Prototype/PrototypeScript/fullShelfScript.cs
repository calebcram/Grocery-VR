using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class fullShelfScript : MonoBehaviour
{

    public bool testMode = false;
    public int shelfAmount = 3;

    //space x and y modifies shelf spacing
    public float spaceX = 0.25f;
    public float spaceY = 0.25f;

    //!!!!!array length should be = to shelfAmount 
    public int[] stockRepeatAmount = new int[3];//
    public float[] offsetX = new float[3];// 
    public float[] offsetY = new float[3];//
    public float[] offsetZ = new float[3];//
    public float[] shelfHeight = new float[3];//
    public GameObject[] stockItem = new GameObject[3];// 
    //!!!!!


    private GameObject[] shelf;
    public GameObject[] shelves;
    //private GameObject groceryProduct;
    //public GameObject[] stockItems;

    public BoxCollider shelfActivatorCollider;
    public float collisionBoxWidth = 1;
    public float collisionOffsetX = 0;

    private int shelfStockCount = 0;
    private int shelfStockCounter = 0;



    // Start is called before the first frame update
    private void Start()
    {
        Shelfer();

    }



    private void Shelfer()
    {
        for (int i = 0; i < shelfAmount; i++)
        {
            shelfStockCount += stockRepeatAmount[i];
        }
        shelves = new GameObject[shelfStockCount];
        for (int i = 0; i < shelfAmount; i++)
        {
            for (int j = 0; j < stockRepeatAmount[i]; j++)
            {
                shelves[shelfStockCounter] = GameObject.Instantiate(stockItem[i], gameObject.transform);
                if (!Mathf.Approximately(shelfHeight[i], 0))
                {
                    shelves[shelfStockCounter].transform.localPosition = new Vector3(j * spaceX + ((j) * offsetX[i]), shelfHeight[i], offsetZ[i]);
                }
                else
                {
                    shelves[shelfStockCounter].transform.localPosition = new Vector3(j * spaceX + ((j) * offsetX[i]), 0 - ((i - 1) * spaceY + offsetY[i]), offsetZ[i]);
                }

                Deactivator();

                
            }
        }

        shelfActivatorCollider.size = new Vector3(collisionBoxWidth, shelfActivatorCollider.size.y, shelfActivatorCollider.size.z);
        shelfActivatorCollider.center = new Vector3((collisionBoxWidth / 2 - 0.5f) + collisionOffsetX, shelfActivatorCollider.center.y, shelfActivatorCollider.center.z);
    }

    void Deactivator()
    {
        if (shelves[shelfStockCounter].GetComponent<BoxCollider>() != null)
        {
            shelves[shelfStockCounter].GetComponent<BoxCollider>().enabled = false;
        }
        else if (shelves[shelfStockCounter].GetComponent<SphereCollider>() != null)
        {
            shelves[shelfStockCounter].GetComponent<SphereCollider>().enabled = false;
        }
        else if (shelves[shelfStockCounter].GetComponent<CapsuleCollider>() != null)
        {
            shelves[shelfStockCounter].GetComponent<CapsuleCollider>().enabled = false;                    
        }
        shelfStockCounter++;
    }

    void Activator()
    {
        if (shelves[shelfStockCounter].GetComponent<BoxCollider>() != null)
        {
            shelves[shelfStockCounter].GetComponent<BoxCollider>().enabled = true;
        }
        else if (shelves[shelfStockCounter].GetComponent<SphereCollider>() != null)
        {
            shelves[shelfStockCounter].GetComponent<SphereCollider>().enabled = true;
        }
        else if (shelves[shelfStockCounter].GetComponent<CapsuleCollider>() != null)
        {
            shelves[shelfStockCounter].GetComponent<CapsuleCollider>().enabled = true;
        }
        shelfStockCounter++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shopper"))
        {
            shelfStockCounter = 0;
            foreach (GameObject item in shelves)
            {
                if(item.GetComponent<FoodProductScript>().wasGrabbed == false)
                {
                    Activator();
                }
                else
                {
                    shelfStockCounter++;
                }
            } 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Shopper"))
        {
            shelfStockCounter = 0;
            foreach (GameObject item in shelves)
            {
                if (item.GetComponent<FoodProductScript>().wasGrabbed == false)
                {
                    Deactivator();
                }
                else
                {
                    shelfStockCounter++;
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (testMode)
        {
            foreach(GameObject prod in shelves)
            {
                Destroy(prod);
            }
            shelfStockCount = 0;
            shelfStockCounter = 0;

            Shelfer();
            testMode = false;
        }


    }

}


