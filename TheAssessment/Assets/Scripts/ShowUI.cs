using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public GameObject UI_Object;
    public AudioClip audioClip;

    void Start()
    {
        UI_Object.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player")) && UI_Object != null)
        {
            UI_Object.SetActive(true);
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
            StartCoroutine("WaitForSec");
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(UI_Object);
        Destroy(gameObject.GetComponent<BoxCollider>());
    }
}
