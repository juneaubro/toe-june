using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupTrigger : MonoBehaviour
{
    public GameObject getOutOfHere;
    public GameObject Trigger;
    public GameObject otherTrigger;
    private int i = 0;
    PlayerController playerController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            i++;
            if (i == 1)
            {
                Vector3 newSize = playerController.gameObject.transform.localScale;
                newSize = new Vector3(.25f, .25f, .25f);
                playerController.gameObject.transform.localScale = newSize;
                PlayerController.playerController.height = 0.2f;
                StartCoroutine(WaitForSec2());
                Trigger.SetActive(true);
                otherTrigger.SetActive(false);
                getOutOfHere.SetActive(true);
                gameObject.SetActive(false);
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
