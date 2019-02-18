using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying_Object : MonoBehaviour
{
    Rigidbody2D rb;

    public float triggerSize;
    private bool isPlayerInRange;
    public float flyingSpeed;

    private CircleCollider2D flyTrigger;

    void Start()
    {
        isPlayerInRange = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Awake()
    {
        flyTrigger = GetComponent<CircleCollider2D>();
        flyTrigger.isTrigger = true;
        Renderer r = GetComponent<Renderer>();
        flyTrigger.radius = r.bounds.size.x * triggerSize;
    }

    void FixedUpdate()
    {
        FlyTowards();
    }

    void FlyTowards()
    {
        if(isPlayerInRange)
            rb.transform.Translate(flyingSpeed * Time.fixedDeltaTime, 0f, 0f);
    }

    void OnTriggerEnter2D(Collider2D colInfo)
    {
        if (colInfo.CompareTag("Player"))
            isPlayerInRange = true;
    }
}
