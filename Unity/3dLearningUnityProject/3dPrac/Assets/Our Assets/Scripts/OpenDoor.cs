using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    private GameObject door;
    private GameObject highPointObject;
    public GameObject getPickupText;
    bool inDoorTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.Find("Door");
        highPointObject = GameObject.Find("highPointObject");
    }

    // Update is called once per frame
    void Update()
    {
        if (inDoorTrigger == false)
        {
            Vector3 newPos = door.transform.position;
            Vector3 highPoint = highPointObject.transform.position;
            if (newPos.y > (highPoint.y - 1))
            {
                newPos.y -= 0.006f;

                door.transform.position = newPos;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (PickupTrigger.b_pickedUp == false)
            {
                getPickupText.SetActive(true);
                StartCoroutine(WaitForSec());
            } else
            {
                inDoorTrigger = true;
            }
        }
        IEnumerator WaitForSec()
        {
            yield return new WaitForSeconds(4);
            getPickupText.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if(inDoorTrigger == true) 
            { 
                Vector3 newPos = door.transform.position;
                Vector3 highPoint = highPointObject.transform.position;

                if (newPos.y <= highPoint.y)
                {
                    newPos.y += 0.005f;
                }
                door.transform.position = newPos;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            inDoorTrigger = false;
        }
    }
}
