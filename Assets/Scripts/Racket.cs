using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Racket : MonoBehaviour
{
    Rigidbody2D rb2;
    public float moveSpeed = 15;
    public string axisName;
    public Text scoreText;

    int score;


    private void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }
    protected virtual void FixedUpdate()
    {
        // I need to control the rackets using keyboard. Simply w or up arrow to move  in +y;
        // s and down arrow to move in -y

        float moveAxis = Input.GetAxis(axisName); // the value returs 1 and -1 and in between.

        rb2.velocity = new Vector2(0, moveAxis) * moveSpeed;
    }

    public virtual void MakeScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
