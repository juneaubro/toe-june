using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private GameObject player;
    private GameObject item;

    public bool itemHeld;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        item = GameObject.FindGameObjectWithTag("PickupItem");

        itemHeld = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.Equals(item))
        {
            itemHeld = true;
            GameObject.Destroy(item);
        }
    }
}
