using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeMenu : MonoBehaviour
{
    public void PressPlay()
    {
        GameManager.manager.PressPlay();
    }

    public void PressQuit()
    {
        Application.Quit();
    }
}
