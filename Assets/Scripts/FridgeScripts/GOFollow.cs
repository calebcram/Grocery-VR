using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOFollow : MonoBehaviour
{
    public Transform followed;
    Rigidbody rigidy;

    // Start is called before the first frame update
    void Start()
    {
        rigidy = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidy.MovePosition(followed.transform.position);
    }
}
