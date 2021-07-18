using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitPileSpawner : MonoBehaviour
{
    //private Vector3 posOne;
    //private Quaternion rotOne;
    //private bool handInOne;

    //private Vector3 posTwo;
    //private Quaternion rotTwo;
    //private bool handInTwo;

    private GameObject FruitOne;
    private GameObject FruitTwo;
    public GameObject FruitType;
    private bool oneGrabbed = false;
    private bool twoGrabbed = false;
    //public int FruitScale;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Left Hand")
        {
            //Debug.Log("OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO " + FruitOne);
            FruitOne = Instantiate(FruitType, other.transform);
            FruitOne.transform.localPosition = new Vector3(0f, 0f, 0f);
            FruitOne.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            //handInOne = true;
            ////FruitOne = other.gameObject;
            //Debug.Log("WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW " + FruitOne);
        }
        if (other.name == "Right Hand")
        {
            //Debug.Log("000000000000000000000000000000000000 " + FruitTwo);
            FruitTwo = Instantiate(FruitType, other.transform);
            FruitTwo.transform.localPosition = new Vector3(0f, 0f, 0f);
            FruitTwo.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            //handInTwo = true;
            ////FruitTwo = other.gameObject;
            //Debug.Log("yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy " + FruitTwo);
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    //if (other.name == "Left Hand")
    //    //{
    //    //    if (!oneGrabbed)
    //    //    {
    //    //        Destroy(FruitOne);
    //    //    }
    //    //    // handInOne = false;
    //    //    //FruitOne = Instantiate(FruitType, posOne, rotOne);

    //    //}
    //    //else if (other.name == "Right Hand")
    //    //{
    //    //    if (!twoGrabbed)
    //    //    {
    //    //        Destroy(FruitTwo);
    //    //    }
    //    //    ///handInTwo = false;
    //    //}
    //    if (other.CompareTag("Product")){
    //        GameObject OtherGO = other.gameObject;
    //        if (OtherGO.GetComponent<FoodProductScript>().wasGrabbed == false)
    //        {
    //            //Destroy(other.gameObject);
    //            OtherGO.transform.SetParent(null);
    //            //OtherGO.transform.localScale = new Vector3(0, 0, 0);
    //            //OtherGO.transform.position = new Vector3(0, 50, 0);
    //            //OtherGO.GetComponent<PileFruitScript>().destroyFruit();
    //        }
    //    }
    //}

    private void ConjureFruitLeft()
    {

        //Instantiate(FruitType, posOne, rotOne);
    }

    private void ConjureFruitRight()
    {

        //Instantiate(FruitType, posOne, rotOne);
    }

    private void LeftGrab()
    {

    }



    // Update is called once per frame
    void Update()
    {
        //if (handInOne)
        //{
        //    posOne = FruitOne.transform.position;
        //    rotOne = FruitOne.transform.rotation;

        //}
        //if (handInTwo)
        //{
        //    posTwo = FruitTwo.transform.position;
        //    rotTwo = FruitTwo.transform.rotation;
        //}
    }
}
