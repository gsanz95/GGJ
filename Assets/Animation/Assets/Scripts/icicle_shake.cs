using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class icicle_shake : MonoBehaviour
{
    public float speed = 1.0f; //how fast it shakes
    public float amount = 1.0f; //how much it shakes
    public float distance = 1.0f;
    public Transform player;
    public Player_Controller player_status;
    public float time_to_fall = 1.0f;
    public float fall_speed = 1.0f;
    public float time_to_destroy = 1.0f;

    private float timer;
    private float disappear;

    Vector2 startingPos;
    bool playernear;
    bool grounded;

    Rigidbody2D rb;

    void Start()
    {
        startingPos.x = transform.position.x;
        startingPos.y = transform.position.y;
        rb = GetComponent<Rigidbody2D>();
        grounded = false;
    }

    void FixedUpdate()
    {
        if (player.transform.position.x >= startingPos.x - distance && player.transform.position.x <= startingPos.x + distance && grounded == false)
        {
            playernear = true;
        }

        if (playernear == true)
        {
            timer += Time.deltaTime;

            transform.position = new Vector2(startingPos.x + Mathf.Sin(Time.time * speed) * amount, transform.position.y);

            if (timer > time_to_fall)
            {
                rb.gravityScale = fall_speed;
                playernear = false;
            }
        }

        if (grounded == true)
        {
            disappear += Time.deltaTime;

            if (disappear > time_to_destroy)
            {
                Destroy(gameObject);
            }
        }
    }

    // Collisions

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            playernear = false;
            grounded = true;
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if (other.gameObject.CompareTag("Player") && grounded == false)
        {
            player.GetComponent<Player_Controller>().killPlayer();
            Destroy(gameObject);
        }
    }
}