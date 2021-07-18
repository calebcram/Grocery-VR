using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfSensor : MonoBehaviour
{
    private bool isAttached = false;
    public GameObject PlayerRig;
    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    private void init()
    {
        if (PlayerRig != null)
        {
            Vector3 pos = new Vector3(PlayerRig.transform.position.x, transform.position.y, PlayerRig.transform.position.z);
            transform.position = pos;
            transform.parent = PlayerRig.transform;
            isAttached = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(isAttached == false)
        {
            init();
        }
        else
        {
            enabled = false;
        }
    }
}
