using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodProductScript : MonoBehaviour
{
    private bool bagged = false;
    public bool wasGrabbed = false;
    public bool isGrabbed = false;
    bool stowable = false;
    private GameObject stowingContainer;

    
    // Script to run if grabbed
    public void GrabbedItem()
    {

        wasGrabbed = true;
        isGrabbed = true;
    }
    public void ReleasedItem()
    {
        if (stowable)
        {
            isGrabbed = true;
            GetComponent<Rigidbody>().isKinematic = true;

            transform.parent = stowingContainer.transform;
            if (stowingContainer.CompareTag("Bag"))
            {
                bagged = true;
                gameObject.layer = LayerMask.NameToLayer("Untouchable");

            }

        }
        else
        {
            isGrabbed = false;
            GetComponent<Rigidbody>().isKinematic = false;
            //transform.parent = null;
            //Debug.Log(GetComponent<Rigidbody>().isKinematic);
            //Debug.Log(gameObject.transform.parent.name);
            gameObject.GetComponent<ForceCollide>().enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Container"))
        {
            stowable = true;
            stowingContainer = other.gameObject;
        }
        if (other.CompareTag("Bag"))
        {
            if (gameObject.GetComponent<ProductData>() != null) { 
                if (gameObject.GetComponent<ProductData>().hasBeenScanned)
                {
                    stowable = true;
                    stowingContainer = other.gameObject;
                    
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Container")|| other.CompareTag("Bag"))
        {
            stowable = false;
        }
    }

    private void Update()
    {
        if (wasGrabbed)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (isGrabbed)
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