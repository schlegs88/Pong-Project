using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public GameObject ball;
    public float MoveSpeed = 5f;
    private Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(0f, 1f);
        float ballposition = ball.transform.position.y;
        if(transform.position.y < ballposition){
            rb.velocity = MoveSpeed * direction;
        }else{
            rb.velocity = MoveSpeed * direction * -1;
        }
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
