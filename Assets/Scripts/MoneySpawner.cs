using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    public GameObject Target;
    public GameObject oneDollar;
    //private GameObject MoneyOne;
    //private GameObject MoneyTwo;
    //public GameObject MoneyType;
    
    //Spawn 1 Dollar Bill Function
    public void GetOneDollar()
    {
        Instantiate(oneDollar.gameObject, Target.transform);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.name == "Left Hand")
    //    {
    //        MoneyOne = Instantiate(MoneyType, other.transform);
    //        MoneyOne.transform.localPosition = new Vector3(0f, 0f, 0f);
    //        MoneyOne.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
    //    }
    //    else if (other.name == "Right Hand")
    //    {
    //        MoneyTwo = Instantiate(MoneyType, other.transform);
    //        MoneyTwo.transform.localPosition = new Vector3(0f, 0f, 0f);
    //        MoneyTwo.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
    //    }
    //}

    //    private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Product"))
    //    {
    //        GameObject OtherGO = other.gameObject;
    //        if (OtherGO.GetComponent<FoodProductScript>().wasGrabbed == false)
    //        {
    //            OtherGO.transform.SetParent(null);
    //        }
    //    }
    //}
}
