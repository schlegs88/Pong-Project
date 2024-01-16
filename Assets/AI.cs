using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public GameObject ball;
    public float MoveSpeed = 5f;
    public float Smoothing = 0.99f;
    public float buffer = 0.01f;
    private Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        float ballposition = ball.transform.position.y;
        if(transform.position.y > -2.9 | transform.position.y < 3.9)
        {
            if(transform.position.y < ballposition)
            {
                rb.velocity = Vector2.Lerp(rb.velocity, new Vector2(0f, MoveSpeed), Smoothing);
            }
            else if (transform.position.y > ballposition)
            {
                // Smoothly interpolate the velocity
                rb.velocity = Vector2.Lerp(rb.velocity, new Vector2(0f, MoveSpeed * -1), Smoothing);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        Debug.Log("Ball position: " + ball.transform.position.y);
        Debug.Log("Paddle position: " + transform.position.y);
        ClampPlayerPosition();
    }

    void ClampPlayerPosition()
    {
        float sizeFix = 1.10f;
        if (spriteRenderer != null)
        {
            // Calculate sprite bounds in world coordinates
            float minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + spriteRenderer.bounds.extents.x*sizeFix;
            float maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - spriteRenderer.bounds.extents.x*sizeFix;

            float minY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + spriteRenderer.bounds.extents.y*sizeFix;
            float maxY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - spriteRenderer.bounds.extents.y*sizeFix;

            // Clamp the player's position
            float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);

            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }
}
