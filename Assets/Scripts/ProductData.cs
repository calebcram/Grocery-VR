using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductData : MonoBehaviour
{
    public enum CATEGORY {
        SNACKS, 
        DAIRY, 
        FRUITS, 
        VEGETABLES, 
        DRYGOODS, 
        MEAT, 
        FROZENGOODS, 
        HYGIENE, 
        BAKERY, 
        COFFEE, 
        OTHER
    } 
    
    //TODO
    public Vector3 dimensions = Vector3.zero;
    public Vector3 positioningOffset = new Vector3(0, 0.5f, 0);

    public CATEGORY category;
    public float price = 0;
    public float density = 1.0f;

    [HideInInspector] public bool hasBeenScanned;
    [HideInInspector] public bool hasBeenPurchased ;


    // Start is called before the first frame update
    void Start()
    {
        hasBeenScanned = false;
        hasBeenPurchased = false;
    }
}
