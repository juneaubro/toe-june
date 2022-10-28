using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static void OnPause()
    {
        GameObject.Find("MainCamera").GetComponent<MouseLook>().enabled = false;
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public static void OnContinue()
    {
        GameObject.Find("MainCamera").GetComponent<MouseLook>().enabled = true;
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
