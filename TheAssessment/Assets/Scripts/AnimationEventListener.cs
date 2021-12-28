using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS SCRIPT DEFINES SEVERAL PUBLIC METHODS THAT THE END CUTSCENE CALLS AT DIFFERENT KEYFRAMES TO ENABLE AND DISABLE TEXT

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
