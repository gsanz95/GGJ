using UnityEngine;

public class Branch_Collision : MonoBehaviour
{
    public Player_Controller player;

    public float bounding_left = 5.0f;
    public float bounding_right = 5.0f;

    public bool hurt_left;
    public bool hurt_right;

    bool touched;
    float timer;

    void Start()
    {
        touched = false;
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer > 2)
        {
            touched = false;
        }
    }
    // Collisions
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if ((((this.transform.position.x + bounding_left) - coll.collider.transform.position.x) < 0) && touched == false)
            {
                if (hurt_right)
                {
                    player.killPlayer();
                }
            }
            else if ((((this.transform.position.x - bounding_right) - coll.collider.transform.position.x) > 0) && touched == false)
            {
                if (hurt_left)
                {
                    player.killPlayer();
                }
            }
            touched = true;
            timer = 0;
        }
    }
}