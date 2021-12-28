using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    public string itemName = "Some Prefab";

    void Start()
    {
        // Change item tag to PickUp to detect when we look at it
        gameObject.tag = "PickUp";
    }

    public void PickUpItem()
    {
        //gameObject refers to the game object this script(component) is attached to
        Destroy(gameObject);
    }
}
