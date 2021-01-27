using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RacketAI : Racket
{
    public float refVal;
    int score;
    Rigidbody2D rb2;

    public Transform ball;
    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    protected override void FixedUpdate()
    {
        float distance = Mathf.Abs(ball.position.y - transform.position.y);

        if (distance > refVal)
        {
            if (ball.position.y < transform.position.y)
            {
                rb2.velocity = new Vector2(0, -1) * moveSpeed;
            }
            else
            {
                rb2.velocity = new Vector2(0, 1) * moveSpeed;
            }
        }
      //  else
        //    rb2.velocity = Vector2.zero;
    }


}
