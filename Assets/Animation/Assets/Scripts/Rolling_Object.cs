using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling_Object : MonoBehaviour
{
    Rigidbody2D rb;

    public float triggerSize;
    private bool isPlayerInRange;
    public float flyingSpeed;

    private BoxCollider2D flyTrigger;

    void Start()
    {
        isPlayerInRange = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Awake()
    {
        flyTrigger = GetComponent<BoxCollider2D>();
        flyTrigger.isTrigger = true;
        Renderer r = GetComponent<Renderer>();
        flyTrigger.size = new Vector2(r.bounds.size.x, r.bounds.size.y) * triggerSize;
    }

    void FixedUpdate()
    {
        FlyTowards();
    }

    void FlyTowards()
    {
        if (isPlayerInRange)
            rb.transform.Translate(flyingSpeed * Time.fixedDeltaTime, 0f, 0f);
    }

    void OnTriggerEnter2D(Collider2D colInfo)
    {
        if (colInfo.CompareTag("Player"))
            isPlayerInRange = true;
    }

    void OnCollisionEnter2D(Collision2D colInfo)
    {
        if (colInfo.collider.CompareTag("Player"))
            colInfo.gameObject.GetComponent<Player_Controller>().killPlayer();
    }

}
