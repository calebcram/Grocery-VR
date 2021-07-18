using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Dropped = false;

    public void DropIt()
    {
        Dropped = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Rigidbody>().isKinematic == false)
        {
            Destroy(this);
        }
        if (Dropped)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;

        }
        
    }
}
