using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float sizeFix = 1.10f;
    public float bottomFix = 1.9f;
    public float speed = 4f;
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found!");
        }
    }
    // Update is called once per frame
    void Update()
    {
        float moveIn = Input.GetAxis("Vertical");

        // Calculate the movement vector
        Vector3 movement = new Vector3(0f, moveIn, 0f) * speed * Time.deltaTime;

        // Apply the movement to the GameObject
        transform.Translate(movement); 
        ClampPlayerPosition();
    }
    
    void ClampPlayerPosition()
    {
        if(spriteRenderer != null)
        {
            // Calculate sprite bounds in world coordinates
            float minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + spriteRenderer.bounds.extents.x*sizeFix;
            float maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - spriteRenderer.bounds.extents.x*sizeFix;

            float minY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + spriteRenderer.bounds.extents.y*bottomFix;
            float maxY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - spriteRenderer.bounds.extents.y*sizeFix;

            // Clamp the player's position
            float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }
}
