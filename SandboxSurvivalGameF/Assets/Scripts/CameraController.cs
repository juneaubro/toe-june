using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float lookSpeed = 3;
    private Vector2 rotation = Vector2.zero;
    public Transform cameraHolder;

    void Awake() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Look();
    }

    void Look() {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.x = Mathf.Clamp(rotation.x, -20f, 20f);
        transform.eulerAngles = new Vector2(0, rotation.y) * lookSpeed;
        cameraHolder.transform.localRotation = Quaternion.Euler(rotation.x * lookSpeed, 0, 0);
    }
}
