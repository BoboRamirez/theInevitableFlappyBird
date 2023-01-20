using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverMenu : MonoBehaviour
{
    private Canvas instance = null;
    private void Awake()
    {
        instance = GetComponent<Canvas>();
        if (instance == null)
            Debug.Log("overMenu: " + "Cannot find any Canvas!");
    }

    public void PressReplay()
    {
        GameManager.manager.PressReplay();
    }

    public void PressQuit()
    {
        Application.Quit();
    }
}
