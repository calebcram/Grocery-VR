using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayCard : MonoBehaviour
{
    [SerializeField] private PayScreen payScreen;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Card")) {
            payScreen.total -= payScreen.total;
            DoStuff(other.gameObject);
        }
    }

    private void DoStuff(GameObject a) {
        a.SetActive(false);
        payScreen.outPutText.text = ($"{payScreen.total:c}");
        payScreen.CheckIfEnough();
    }
}
