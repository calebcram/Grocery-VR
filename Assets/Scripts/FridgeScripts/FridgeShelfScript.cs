using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeShelfScript : MonoBehaviour
{
    public GameObject theDoor;
    public float doorAngle;
    public bool doorAngleUpdate = false;

    private bool doorOpen = false;

    public bool testMode = false;
    public int fridgeShelfAmount = 4;

    //space x and y modifies shelf spacing
    public float spaceX = 0.25f;
    public float spaceY = 0.25f;

    //!!!!!array length should be = to fridgeShelfAmount 
    public int[] fridgeStockRepeatAmount = new int[4];//
    public float[] offsetX = new float[4];// 
    public float[] offsetY = new float[4];//
    public float[] offsetZ = new float[4];//
    public float[] fridgeShelfHeight = new float[4];//
    public GameObject[] fridgeStockItem = new GameObject[4];// 
    //!!!!!


    private GameObject[] shelf;
    public GameObject[] fridgeStock;

    public BoxCollider shelfActivatorCollider;
    public float collisionBoxWidth = 1;
    public float collisionOffsetX = 0;

    private int fridgeStockCount = 0;
    private int fridgeStockCounter = 0;



    // Start is called before the first frame update
    private void Start()
    {
        //Initializes shelf based on the values entered into the inspector
        Shelfer();

    }



    private void Shelfer()
    {
        //Builds a shelf based on imputs. 
        for (int i = 0; i < fridgeShelfAmount; i++)
        {
            fridgeStockCount += fridgeStockRepeatAmount[i];
        }
        fridgeStock = new GameObject[fridgeStockCount];
        for (int i = 0; i < fridgeShelfAmount; i++)
        {
            for (int j = 0; j < fridgeStockRepeatAmount[i]; j++)
            {
                fridgeStock[fridgeStockCounter] = GameObject.Instantiate(fridgeStockItem[i], gameObject.transform);
                if (!Mathf.Approximately(fridgeShelfHeight[i], 0))
                {
                    fridgeStock[fridgeStockCounter].transform.localPosition = new Vector3(j * spaceX + ((j) * offsetX[i]), fridgeShelfHeight[i], offsetZ[i]);
                }
                else
                {
                    fridgeStock[fridgeStockCounter].transform.localPosition = new Vector3(j * spaceX + ((j) * offsetX[i]), 0 - ((i - 1) * spaceY + offsetY[i]), offsetZ[i]);
                }
                Deactivator();

            }
        }
        //Modifies the dimensions of the box collider to detect the shopper.  If it does not the Items will not be interctable.
        shelfActivatorCollider.size = new Vector3(collisionBoxWidth, shelfActivatorCollider.size.y, shelfActivatorCollider.size.z);
        shelfActivatorCollider.center = new Vector3((collisionBoxWidth / 2 - 0.5f) + collisionOffsetX, shelfActivatorCollider.center.y, shelfActivatorCollider.center.z);
    }

    void Deactivator()
    {
        //turns off box, sphere and capsule coliders that were spawend on the shelves.
        if (fridgeStock[fridgeStockCounter].GetComponent<BoxCollider>() != null)
        {
            fridgeStock[fridgeStockCounter].GetComponent<BoxCollider>().enabled = false;
        }
        else if (fridgeStock[fridgeStockCounter].GetComponent<SphereCollider>() != null)
        {
            fridgeStock[fridgeStockCounter].GetComponent<SphereCollider>().enabled = false;
        }
        else if (fridgeStock[fridgeStockCounter].GetComponent<CapsuleCollider>() != null)
        {
            fridgeStock[fridgeStockCounter].GetComponent<CapsuleCollider>().enabled = false;
        }
        fridgeStockCounter++;
    }

    void Activator()
    {
        //turns on box, spher,e and capsule coliders that were spawend on the shelves.

        if (fridgeStock[fridgeStockCounter].GetComponent<BoxCollider>() != null)
        {
            fridgeStock[fridgeStockCounter].GetComponent<BoxCollider>().enabled = true;
        }
        else if (fridgeStock[fridgeStockCounter].GetComponent<SphereCollider>() != null)
        {
            fridgeStock[fridgeStockCounter].GetComponent<SphereCollider>().enabled = true;
        }
        else if (fridgeStock[fridgeStockCounter].GetComponent<CapsuleCollider>() != null)
        {
            fridgeStock[fridgeStockCounter].GetComponent<CapsuleCollider>().enabled = true;
        }
        fridgeStockCounter++;
    }

    private void OnTriggerEnter(Collider other)
    {
        //allows door "openess" to be measured
        if (other.CompareTag("Shopper"))
        {
            doorAngleUpdate = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        //encourages the door to close, and no longer measures hore open the door is.
        if (other.CompareTag("Shopper"))
        {
            if (doorAngle >= 0.1f)
            {
                theDoor.GetComponent<HingeJoint>().useSpring = true;
            }
            else
            {
                doorAngleUpdate = false;
            }

        }
    }

    void Update()
    {
        //Test changes made to inputs while the game is running.
        if (testMode)
        {
            foreach (GameObject prod in fridgeStock)
            {
                Destroy(prod);
            }
            fridgeStockCount = 0;
            fridgeStockCounter = 0;

            Shelfer();
            testMode = false;
        }
        //updates door open measurments
        if (doorAngleUpdate)
        {
            doorAngle = theDoor.transform.localEulerAngles.y;
            //Debug.Log(doorAngle);
        }

        //regulates what the doors are doing so you can only grab items when the door is "open"
        if (doorOpen) {
            if (doorAngle<15)
            {
                doorOpen = false;

                //deactivate products
                fridgeStockCounter = 0;
                foreach (GameObject item in fridgeStock)
                {
                    if (item.GetComponent<FoodProductScript>().wasGrabbed == false)
                    {
                        Deactivator();
                    }
                    else
                    {
                        fridgeStockCounter++;
                    }
                }

            }
        }
        else
        {
            if (doorAngle >= 15)
            {
                doorOpen = true;

                //activate products
                fridgeStockCounter = 0;
                foreach (GameObject item in fridgeStock)
                {
                    if (item.GetComponent<FoodProductScript>().wasGrabbed == false)
                    {
                        Activator();
                    }
                    else
                    {
                        fridgeStockCounter++;
                    }
                }
            }
            else if(theDoor.GetComponent<HingeJoint>().useSpring == true){
                if (doorAngle < 0.1f)
                {
                    theDoor.GetComponent<HingeJoint>().useSpring = false;
                    doorAngleUpdate = false;
                }
            }

        }


    }

}