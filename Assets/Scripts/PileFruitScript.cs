using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileFruitScript : MonoBehaviour
{
    public bool destroyOnExit = false;
    public bool fruitGrabbed = false;
    public bool pileFruitDestroyer = false;
    public bool setToDestroy = false;

    public float minX = 0;
    public float maxX = 0;
    public float minZ = 0;
    public float maxZ = 0;

    private void Start()
    {
        //Debug.Log(transform.position);
    }
    public void fruitGrabber()
    {
        //
        fruitGrabbed = true;
        Destroy(this);
        //Debug.Log("11111111111111111111111111111111111111111111111111111111111111111111");
    }


    public void destroyFruit()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        if (pileFruitDestroyer)
        {
            Destroy(gameObject);
        }
        if (setToDestroy)
        {
            pileFruitDestroyer = true;
        }
        if (destroyOnExit)
        {
            if (transform.position.x < minX || transform.position.x > maxX || transform.position.z < minZ || transform.position.z > maxZ)
            {
                Debug.Log(transform.position);
                Vector3 pos = new Vector3(0, 10, 0);
                transform.position = pos;
                setToDestroy = true;
            }
        }
        else
        {
            Destroy(this);
        }
    }
}
