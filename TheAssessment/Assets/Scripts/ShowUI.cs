using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS SCRIPT ALLOWS UI TEXT TO POP UP AND DISAPPEAR AFTER ENTERING A TRIGGER AREA

public class ShowUI : MonoBehaviour
{
    public GameObject UI_Object;
    public AudioClip audioClip;

    void Start()
    {
        // Set the UI object to false to start
        UI_Object.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player")) && UI_Object != null)
        {
            // When the player enters the trigger, activate the UI object, and start a coroutine
            UI_Object.SetActive(true);
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
            StartCoroutine("WaitForSec");
        }
    }

    // Defines a coroutine that waits for 5 seconds before destroying the UI object and the trigger
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(UI_Object);
        Destroy(gameObject.GetComponent<BoxCollider>());
    }
}
