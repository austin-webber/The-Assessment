using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS SCRIPT DEFINES THE KEY TYPES

public class Key : MonoBehaviour
{
    [SerializeField] private KeyType keyType;

    private void Start()
    {
        // Change item tag to PickUp to detect when we look at it
        gameObject.tag = "PickUp";
    }

    // Creating an enumerator that allows me to assign a type to each key
    public enum KeyType
    {
        Red,
        Green,
        Blue
    }

    public KeyType GetKeyType()
    {
        return keyType;
    }
}
