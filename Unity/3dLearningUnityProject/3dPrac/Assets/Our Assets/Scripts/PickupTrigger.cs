using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupTrigger : MonoBehaviour
{

    public GameObject Player;
    public GameObject getOutOfHere;
    public GameObject Trigger;
    public GameObject otherTrigger;
    private int i = 0;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            i++;
            if (i == 1)
            {
                Vector3 newSize = Player.transform.localScale;
                newSize = new Vector3(.25f, .25f, .25f);
                Player.transform.localScale = newSize;
                PlayerController.playerController.height = 0.2f;
                StartCoroutine(WaitForSec2());
                Trigger.SetActive(true);
                otherTrigger.SetActive(false);
                getOutOfHere.SetActive(true);
            }

        }

        IEnumerator WaitForSec2()
        {
            yield return new WaitForSeconds(2);
            Destroy(gameObject);
            Destroy(getOutOfHere);
        }
    }
}
