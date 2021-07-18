using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductInfoScript : MonoBehaviour
{
    public string productName = "";
    public float price = 0;
    public float weight = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(productName == "")
        {
            productName = gameObject.name;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
