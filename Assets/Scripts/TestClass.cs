using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// test if gameObject is alive
/// </summary>
public class TestClass : MonoBehaviour
{
    
    private GameObject go;
    public float delay;
    private float count;

    private void Start()
    {
        go = gameObject;
        count = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= delay)
        {
            Debug.Log(go.ToString() + "is alive!");
            count -= delay;
        }
        else
            count += delay * Time.deltaTime;
    }
}
