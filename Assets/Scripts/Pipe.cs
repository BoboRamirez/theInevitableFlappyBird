using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private float pipeSpeed;

    private void Start()
    {
        pipeSpeed = ConfigData.pipeMoveSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        ShiftLeft();
    }

    private void ShiftLeft()
    {
        transform.position += Vector3.left * pipeSpeed * Time.deltaTime * GameManager.Difficulty;
        if (transform.position.x <= -10)
            Destroy(gameObject);
    }

}
