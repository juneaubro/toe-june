using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static CharacterController playerController;
    private bool isPaused = false;

    //// Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    //// Update is called once per frame
    void Update()
    {

         if(Input.GetKeyDown(KeyCode.P))
            SceneManager.LoadScene("SampleScene 1");


        // THIS SHIT IS 4HEAD BUGGED
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            Pause.OnPause();
            isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            Pause.OnContinue();
            isPaused = false;
        }
    }
}
