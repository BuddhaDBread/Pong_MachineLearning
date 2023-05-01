using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float speed;                             
    public Vector3 direction;                       
    private Rigidbody rb;                           

    private float timeElapsed = 0f;                 
    private float speedIncreaseInterval = 5f;       
    public float speedIncreaseAmount = 0.5f;        
    public AudioManager audioManager;               

    private void Start()
    {
        // set the initial direction of the ball randomly
        float randomNum = Random.Range(-0.5f, 0.5f);
        if (randomNum > 0)
            randomNum = 0.5f;
        else
            randomNum = -0.5f;

        // get the Rigidbody component of the ball
        this.rb = GetComponent<Rigidbody>();
        // set the direction of the ball
        this.direction = new Vector3(-0.5f, 0, randomNum);
    }

    private void Update()
    {
        // move the ball in its current direction at its current speed
        transform.position += direction * speed * Time.deltaTime;

        // keep track of time elapsed since last speed increase
        timeElapsed += Time.deltaTime;
        // if it's time to increase speed, increase it and reset the timer
        if (timeElapsed >= speedIncreaseInterval)
        {
            speed += speedIncreaseAmount;
            timeElapsed = 0f;
        }
    }

    private void FixedUpdate()
    {
        // move the ball in its current direction at its current speed (fixed time step)
        this.rb.MovePosition(this.rb.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // if the ball hits the side of the play area, bounce off it by changing direction
        if (other.CompareTag("side"))
        {
            direction.z = -direction.z;
        }
        // if the ball hits a racket, play a sound effect and bounce off it by changing direction
        if (other.CompareTag("Racket"))
        {
            audioManager.Play("Hit");
            direction.x = -direction.x;
        }
    }
}
