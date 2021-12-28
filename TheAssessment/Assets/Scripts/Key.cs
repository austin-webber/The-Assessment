using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private KeyType keyType;

    private void Start()
    {
        // Change item tag to PickUp to detect when we look at it
        gameObject.tag = "PickUp";
    }

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
