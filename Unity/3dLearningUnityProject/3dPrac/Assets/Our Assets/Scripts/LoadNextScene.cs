using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{

    public GameObject nextSceneTrigger;
    public GameObject nextScenePortal;
    int i = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            i++;
            if (i == 1)
            {
                SceneManager.LoadScene("FuckMeshes 1");
            }
        }
    }
}
