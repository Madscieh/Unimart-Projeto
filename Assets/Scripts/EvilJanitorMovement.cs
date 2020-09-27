using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EvilJanitorMovement : MonoBehaviour
{

    Rigidbody2D body;
    Animator anim;
    SpriteRenderer render;


    /*
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 1f;
    */

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        /*
        Vector3 dir = player.position - transform.position;
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //rb.rotation = angle; //(rotate enemy to face player)!!
        //dir.Normalize();
        movement = dir;
        */


        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        anim.SetFloat("VelocidadeH", Mathf.Abs(horizontal));
        anim.SetFloat("VelocidadeV", vertical);
        if (horizontal < 0)
            render.flipX = true;
        else if (horizontal > 0)
            render.flipX = false;
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }


    /*
    private void FixedUpdate()
    {
        MoveEnemy(movement);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            Destroy(monster);
            Invoke("WinCondition", 3);
        }
    }

    void WinCondition()
    {
        SceneManager.LoadScene("WinCondition");
    }

    void MoveEnemy(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * moveSpeed * Time.deltaTime));
    }
    */
}