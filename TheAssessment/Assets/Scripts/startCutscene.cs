using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startCutscene : MonoBehaviour
{
    public GameObject Player;
    public GameObject cutsceneCam;
    public GameObject cursor;
    public AudioSource forestAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            forestAudio.Play();
            cursor.SetActive(false);
            cutsceneCam.SetActive(true);
            Player.SetActive(false);
            StartCoroutine(FinishCutscene());
        }
    }

    IEnumerator FinishCutscene()
    {
        yield return new WaitForSeconds(28.017f);
        Debug.Log("quit");
        Application.Quit();
    }
}
