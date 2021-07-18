using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscProductSpawner : MonoBehaviour
{
    public GameObject theProduct;
    public Transform[] productPlacement;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform placement in productPlacement)
        {
            Instantiate(theProduct, placement);
        }
    }

}
