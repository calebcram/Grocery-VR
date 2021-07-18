using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayMoney : MonoBehaviour
{
    [SerializeField] private PayScreen payScreen;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Penny")) {
            payScreen.total -= 0.01f;
            DoStuff(other.gameObject);
        }

        if (other.CompareTag("Nickel")) {
            payScreen.total -= 0.05f;
            DoStuff(other.gameObject);
        }

        if (other.CompareTag("Dime")) {
            payScreen.total -= 0.10f;
            DoStuff(other.gameObject);
        }

        if (other.CompareTag("Quarter")) {
            payScreen.total -= 0.25f;
            DoStuff(other.gameObject);
        }

        if (other.CompareTag("1Dollar")) {
            payScreen.total -= 1.00f;
            DoStuff(other.gameObject);
        }

        if (other.CompareTag("5Dollar")) {
            payScreen.total -= 5.00f;
            DoStuff(other.gameObject);
        }

        if (other.CompareTag("10Dollar")) {
            payScreen.total -= 10.00f;
            DoStuff(other.gameObject);
        }

        if (other.CompareTag("20Dollar")) {
            payScreen.total -= 20.00f;
            DoStuff(other.gameObject);
        }

        if (other.CompareTag("50Dollar")) {
            payScreen.total -= 50.00f;
            DoStuff(other.gameObject);
        }

        
    }

    private void DoStuff(GameObject a) {
        a.SetActive(false);
        payScreen.outPutText.text = ($"{payScreen.total:c}");
        payScreen.CheckIfEnough();
    }
}
