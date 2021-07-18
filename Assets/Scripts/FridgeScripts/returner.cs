using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Restores transform to a previous position
/// </summary>
public class returner : MonoBehaviour
{
    public GameObject follower;
    bool isGrabbed = false;

    public void Grabbed()
    {
        isGrabbed = true;
    }
    public void NotGrabbed()
    {
        restoreTransform();
        Rigidbody rb = follower.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        isGrabbed = false;
    }
    public void restoreTransform()
    {
        transform.position = follower.transform.position; //new Vector3(0, 0, 0);
        transform.eulerAngles = follower.transform.eulerAngles; //new Vector3(0, 0, 0);
    }
    //private void Update()
    //{
    //    if(isGrabbed)
    //    {
    //        Grabbed
    //    }
    //}
}
