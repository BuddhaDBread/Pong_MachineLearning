using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class MoveToGoalAgent : Agent
{
    [SerializeField] private BallControl ball;
    public Transform playerTransform;

    // This function is called at the start of each new episode
    public override void OnEpisodeBegin()
    {
        // Set the starting positions for the player and ball
        transform.localPosition = new Vector3(5.52f, 0.5f, 0f);
        ball.transform.localPosition = new Vector3(0f, 0.5f, 0f);
        playerTransform.localPosition = new Vector3(-5.51f, 0.5f, 0f);

        // Randomly set the direction and speed of the ball
        float randomNum = Random.Range(-0.5f, 0.5f);
        if (randomNum > 0)
            randomNum = 0.5f;
        else
            randomNum = -0.5f;
        ball.speed = 3.5f;
        ball.direction = new Vector3(-0.5f, 0, randomNum).normalized;
    }

    // This function is called once per frame
    private void Update()
    {
        // Ensure that the player stays within the bounds of the game
        if (transform.localPosition.z >= 2.98f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 2.98f);
        }
        else if (transform.localPosition.z <= -3.02f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -3.02f);
        }
    }

    // This function is called to collect observations from the environment
    public override void CollectObservations(VectorSensor sensor)
    {
        // Add the position of the player and ball to the observation vector
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(ball.transform.localPosition);
    }

    // This function is called when actions are received from the agent
    public override void OnActionReceived(ActionBuffers actions)
    {
        // Get the value of the continuous action for movement along the z-axis
        float moveZ = actions.ContinuousActions[0];

        // Move the player based on the received actions
        float moveSpeed = 5f;
        transform.localPosition += new Vector3(0, 0, moveZ) * Time.deltaTime * moveSpeed;
    }

    // This function is used for manual testing of the agent's behavior
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions; ;
        continuousActions[0] = Input.GetAxisRaw("Vertical");
    }

    // This function is called when the player collides with a trigger
    private void OnTriggerEnter(Collider other)
    {
        // If the player collides with the goal, give it a reward
        if (other.TryGetComponent<Goal>(out Goal goal))
        {
            AddReward(+1f);
        }
    }
}
