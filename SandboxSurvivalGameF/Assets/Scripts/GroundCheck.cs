using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {
    public static bool isGrounded;

    private void OnTriggerEnter(Collider other) {
        if (other)
            isGrounded = true;
    }

    private void OnTriggerExit(Collider other) {
        if (other)
            isGrounded = false;
    }
}
