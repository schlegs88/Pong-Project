using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{

    public float initialSpeed = 5f; // Initial speed of the ball

    public float startDirection = 1f;
    private Rigidbody2D rb;
    
    public float rotationalSpeed = 1000f;
    void Update(){
        
    }
    void Start()
    {
        // Initialize Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        float randomNess = Random.Range(-1f, 1f);
        // Set initial velocity
        Vector2 initialDirection = new Vector2(startDirection, randomNess).normalized;
        rb.velocity = initialDirection * initialSpeed;
        rb.angularVelocity = 0f;
    }

    void OnCollisionEnter2D()
    {
        float randomNess;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = rb.velocity * 1.1f;
        randomNess = Random.Range(-3f, 3f);
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y+randomNess);
    }
}
