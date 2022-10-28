using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGUI : MonoBehaviour
{
    public GameObject uiObject;
    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(true);
        StartCoroutine(StartWait());
    }
    IEnumerator StartWait()
    {
        yield return new WaitForSeconds(5);
        uiObject.SetActive(false);
        Destroy(uiObject);
    }
}
