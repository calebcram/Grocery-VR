using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bagScript : MonoBehaviour
{
   public bool bagWasGrabbed = false;
    public bool bagGrabbed = false;
    bool bagStowable = false;
    private GameObject bagStowingContainer;
    
    // Script to run if grabbed
    public void GrabbedBag()
    {
        //gameObject.GetComponent<Rigidbody>().isKinematic = true;
        bagWasGrabbed = true;
        bagGrabbed = true;
    }
    public void ReleasedItem()
    {
        if (bagStowable)
        {
            bagGrabbed = true;
            transform.parent = bagStowingContainer.transform;
            GetComponent<Rigidbody>().isKinematic = true;
            //transform.SetParent(bagStowingContainer.transform); 


        }
        else
        {
            bagGrabbed = false;
            GetComponent<Rigidbody>().isKinematic = false;
            transform.parent = null;
            //Debug.Log(GetComponent<Rigidbody>().isKinematic);
            //Debug.Log(gameObject.transform.parent.name);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Container"))
        {
            bagStowable = true;
            bagStowingContainer = other.gameObject;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Container"))
        {
            bagStowable = false;
        }
    }

    private void Update()
    {
        if (bagWasGrabbed)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (bagGrabbed)
            {

                rb.isKinematic = true;
            }
            else
            {
                rb.isKinematic = false;
            }
        }





    }
}
