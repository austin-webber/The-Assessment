using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS SCRIPT ALLOWS THE PLAYER TO PICK UP KEYS OF DIFFERENT TYPES

public class KeyHolder : MonoBehaviour
{
    public List<Key.KeyType> keyList;
    public FPSController playerController;
    public AudioClip audioClip;

    private void Awake()
    {

        // Instantiate a list of keys on Awake
        keyList = new List<Key.KeyType>();
    }

    public void AddKey(Key.KeyType keyType)
    {
        // function to add a key to the list
        Debug.Log("Added Key: " + keyType);
        keyList.Add(keyType);
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        // function to remove a key from the list
        keyList.Remove(keyType);
    }

    public bool ContainsKey(Key.KeyType keyType)
    {
        // function to check if a certain key is in the list
        return keyList.Contains(keyType);
    }

    private void Update()
    {
        // Detect if the player is looking at an item
        RaycastHit hit;
        // Returns a ray going from the camera object through the middle of the viewport (hence the 0.5 on the x and 0.5 on the y)
        Ray ray = playerController.playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out hit, 2.5f))
        {
            GameObject objectHit = hit.transform.gameObject;
            Key key = objectHit.GetComponent<Key>();

            // If the object the ray hits is able to be picked up, and the Player presses F, add the key to a Key List, destroy the object, and play an audio clip
            if (objectHit.CompareTag("PickUp"))
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("You are pressing F on a key");
                    AudioSource.PlayClipAtPoint(audioClip, transform.position);
                    AddKey(key.GetKeyType());
                    Destroy(key.gameObject);
                }
            }
        }
        
        
    }
}
