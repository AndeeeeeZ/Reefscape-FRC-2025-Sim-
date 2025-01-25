using UnityEngine;
public class Processor : MonoBehaviour
{
    [SerializeField]
    private bool debug; 

    [SerializeField]
    private ScoreManager blueScore, redScore;

    private readonly int scorePerAlgae = 6; 

    // Each algae in processor scores 6 points in both auto and teleop
    public void Score(Team team)
    {
        if (team == Team.BLUE)
        {
            blueScore.AddProcessorScore(scorePerAlgae);

            if (debug)
                Debug.Log("Blue scored in processor"); 
        }
        else if (team == Team.RED)
        {
            redScore.AddProcessorScore(scorePerAlgae);
            if (debug)
                Debug.Log("Red scored in processor");
        }
        else
        {
            Debug.LogWarning("Unable to detect the scoring robot's team");
        }

    }
}
