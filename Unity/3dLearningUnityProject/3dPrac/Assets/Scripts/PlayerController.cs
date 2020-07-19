using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Door;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        Vector3 pos = Door.transform.position;

        if(collision.gameObject.tag == "Door")
        {

            Debug.Log(":)");

            pos.y = 2f;
            //if (pos.y < 2f) 
            //{
            //    pos.y += 0.1f;
            //}
        }
    }

    private void OnTriggerExit(Collider asd)
    {
        Vector3 pos = Door.transform.position;

        if(asd.gameObject.tag == "Door")
        {

            Debug.Log(":(");

            if(pos.y > 0f)
            {
                pos.y -= 0.1f;
            }
        }
    }
}
