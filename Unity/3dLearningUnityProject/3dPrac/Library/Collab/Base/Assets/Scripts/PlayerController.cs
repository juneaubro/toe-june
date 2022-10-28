using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject Door;
    public GameObject highPointObject;
    public GameObject getPickup;
    public GameObject Trigger;
    bool inDoorTrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inDoorTrigger == false)
        {
            Vector3 newPos = Door.transform.position;
            Vector3 highPoint = highPointObject.transform.position;
            if (newPos.y > (highPoint.y - 1))
            {
                newPos.y -= 0.006f;

                Door.transform.position = newPos;
            }
        }

        if(Input.GetKeyDown(KeyCode.P))
            SceneManager.LoadScene("SampleScene 1");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "otherDoorTrigger")
        {
            getPickup.SetActive(true);
            StartCoroutine(WaitForSec());
        }
        IEnumerator WaitForSec()
        {
            yield return new WaitForSeconds(5);
            getPickup.SetActive(false);
        }

        if (other.gameObject.tag == "Door")
        {
            inDoorTrigger = true;
            Vector3 newPos = Door.transform.position;
            Vector3 highPoint = highPointObject.transform.position;

            if (newPos.y <= highPoint.y)
            {
                newPos.y += 0.005f;

                Door.transform.position = newPos;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Door")
        {
            inDoorTrigger = false;
        }
    }
}
