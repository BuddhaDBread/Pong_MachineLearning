using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    public MoveToGoalAgent agent;
    public BallControl ballControl;
    public GameMaster gameMaster;

    private void OnTriggerEnter(Collider other)
    {
        //Condition when the AI agent Wins
        if (other.TryGetComponent<Score>(out Score score))
        {
            //player loses
            gameMaster.GetComponent<AudioManager>().Play("Lose");
            gameMaster.agentScoreCount++;
            agent.AddReward(+1f);
            agent.EndEpisode();
        }
        //Condition when the AI agent Loses
        if (other.TryGetComponent<Wall>(out Wall wall))
        {
            //player wins
            gameMaster.GetComponent<AudioManager>().Play("Win");
            gameMaster.playerScoreCount++;
            agent.AddReward(-50f);
            agent.EndEpisode();
        }
    }
}
