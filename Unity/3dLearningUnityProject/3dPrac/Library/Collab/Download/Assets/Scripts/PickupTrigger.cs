using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTrigger : MonoBehaviour
{

    public GameObject Player;
    public GameObject getOutOfHere;
    public GameObject Trigger;
    public GameObject otherTrigger;

    // Start is called before the first frame update
    private void Start()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        { 

            Vector3 newSize = Player.transform.localScale;
            newSize = new Vector3(.25f, .25f, .25f);
            Player.transform.localScale = newSize;
            PlayerController.playerController.height = 1f;
            PlayerController.playerController.radius = .25f;

            StartCoroutine(WaitForSec2());

            Trigger.SetActive(true);
            otherTrigger.SetActive(false);

            getOutOfHere.SetActive(true);
        }

        IEnumerator WaitForSec2()
        {
            yield return new WaitForSeconds(3);
            Destroy(getOutOfHere);
            Destroy(gameObject);
        }
    }
}
