using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setActive : MonoBehaviour
{

    public GameObject EndScreen;
    public GameObject Tower;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            EndScreen.gameObject.SetActive(true);
            Tower.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EndScreen.gameObject.SetActive(false);
    }


}
