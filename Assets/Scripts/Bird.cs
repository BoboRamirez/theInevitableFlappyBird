using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{
    [SerializeField] float jumpHeight;
    private Rigidbody2D rb;
    public bool IsAlive { get; private set; }
    //private GameObject bird = null;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * jumpHeight / 2f);
        rb.freezeRotation = true;
        IsAlive = true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //dead bird
        if (rb.transform.position.y <= -5.5 || rb.transform.position.x <= -10 || rb.transform.position.x >= 10)
        {
            //if bird is out of bound without hitting the pipe, show gameover popup
            if (IsAlive)
                GameManager.manager.HandleBirdDeath();
            Maydaymayday();
            Destroy(gameObject);
        }
        else if(rb.transform.position.y > 7f)
        {
            rb.position = new Vector2(rb.position.x, 7f);
        }
    }
    /// <summary>
    /// fly while bird is alive
    /// </summary>
    /// <param name="inputCtx">new input system param</param>
    public void Flap(InputAction.CallbackContext inputCtx)
    {
        if(inputCtx.phase == InputActionPhase.Started && IsAlive)
        {
            rb.AddForce(Vector2.up * jumpHeight);
        }
    }
    /// <summary>
    /// make bird lose control
    /// </summary>
    private void Maydaymayday()
    {
        IsAlive = false;
        rb.freezeRotation=false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Pipe")
        {
            Maydaymayday();
            GameManager.manager.HandleBirdDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Pipe")
        {
            GameManager.manager.Score();
        }
    }
}
