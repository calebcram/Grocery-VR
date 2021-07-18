using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartScript : MonoBehaviour
{
    public GameObject cartHandle;
    public bool isHeld = false;
    private float cartHeight;
    public float speed = .01f;
    public float turnSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        cartHeight = transform.position.y;
    }

    public void cartHandleGrabbed()
    {
        isHeld = true;
    }


    public void cartHandleReleased()
    {
        isHeld = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHeld)
        {
            Vector3 pos = new Vector3(cartHandle.transform.position.x, cartHeight, cartHandle.transform.position.z);
            Vector3 rot = new Vector3(0, cartHandle.transform.eulerAngles.y, 0);

            transform.position = pos;
            transform.eulerAngles = rot;
        }
        else
        {
            Vector3 pos = transform.position;
            Vector3 rot = new Vector3(0, cartHandle.transform.eulerAngles.y, 0);

            cartHandle.transform.position = pos;
            cartHandle.transform.eulerAngles = rot;
        }
        float hori = Input.GetAxis("Horizontal");
        float verti = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.E))
        {
            cartHandle.transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            cartHandle.transform.Rotate(Vector3.up * Time.deltaTime * -turnSpeed);
        }
        

        cartHandle.transform.Translate(Vector3.forward * Time.deltaTime * hori * speed);
        cartHandle.transform.Translate(Vector3.up * Time.deltaTime * verti * speed);
        
        //gameObject.transform.position = new Vector3(transform.position.x + (hori * speed),
        //transform.position.y + (verti * speed));
    }
}
