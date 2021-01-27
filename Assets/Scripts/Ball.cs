using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb2;
    public float moveSpeed;
    Tags tags;
    AudioSource audioSource;

    public Racket leftRacket;
    public Racket rightRacket;
    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        rb2.velocity = new Vector2(1, 0) * moveSpeed;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.Play();

        if (collision.gameObject.GetComponent<TagManager>() == null) return;
       
        tags = collision.gameObject.GetComponent<TagManager>().tags;
       
        if (tags == Tags.LEFT_WALL)
            rightRacket.MakeScore();

        if (tags == Tags.RIGHT_WALL)
            leftRacket.MakeScore();

        if (tags == Tags.LEFT_RACKET)
            CalculateReturnVector(1, collision);

        if (tags == Tags.RIGHT_RACKET)
            CalculateReturnVector(-1, collision);
    }

    private void CalculateReturnVector(float x, Collision2D collision)
    {
        //we wanted to find distance from center point to hit point
        float a = transform.position.y - collision.collider.bounds.center.y; 
        float b = collision.collider.bounds.size.y / 2.0f;
        float y = a / b; // we devided distance to vertical size of racket. so we can
        // get  component of return vector.
        
        rb2.velocity = new Vector2(x, y) * moveSpeed;
    }
}
