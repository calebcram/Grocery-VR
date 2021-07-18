using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasInFrontOfPlayer : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject body;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = cam.transform.position + cam.transform.forward * 0.5f;
        transform.position = new Vector3(pos.x, pos.y, pos.z);

        Vector3 targetPos = new Vector3(cam.transform.position.x, transform.position.y, cam.transform.position.z);

        transform.LookAt(targetPos);
    }
}
