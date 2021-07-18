using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceCollide : MonoBehaviour
{
    // Start is called before the first frame update
    int FCCounter = 0;


    // Update is called once per frame
    void Update()
    {
        if(FCCounter < 200)
        {
            FCCounter++;
            if(gameObject.GetComponent<BoxCollider>() == null)
            {
                if (gameObject.GetComponent<SphereCollider>() == null)
                {
                    if (gameObject.GetComponent<CapsuleCollider>() != null)
                    {
                        if (gameObject.GetComponent<CapsuleCollider>().enabled == false)
                        {
                            gameObject.GetComponent<CapsuleCollider>().enabled = true;
                        }
                    }
                }
                else
                {
                    if (gameObject.GetComponent<SphereCollider>().enabled == false)
                    {
                        gameObject.GetComponent<SphereCollider>().enabled = true;
                    }
                }
            }
            else
            {
                if (gameObject.GetComponent<BoxCollider>().enabled == false)
                {
                    gameObject.GetComponent<BoxCollider>().enabled = true;
                }

            }
        }else
        {
            FCCounter = 0;
            this.enabled = false;
        }

    }
}
