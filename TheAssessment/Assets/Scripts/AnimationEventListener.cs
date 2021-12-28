using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventListener : MonoBehaviour
{
    public GameObject welcomeText;
    public GameObject passedText;
    public GameObject joinUsText;
    public GameObject theEndText;

    public void WelcomeTextEnable()
    {
        welcomeText.SetActive(true);
    }

    public void PassedTextEnable()
    {
        passedText.SetActive(true);
    }

    public void JoinUsTextEnable()
    {
        joinUsText.SetActive(true);
    }

    public void WelcomeTextDisable()
    {
        welcomeText.SetActive(false);
    }

    public void PassedTextDisable()
    {
        passedText.SetActive(false);
    }

    public void JoinUsTextDisable()
    {
        joinUsText.SetActive(false);
    }

    public void TheEndTextEnable()
    {
        theEndText.SetActive(true);
    }
}
