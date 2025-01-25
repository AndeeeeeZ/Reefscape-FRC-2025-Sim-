using UnityEngine;
using TMPro; 

/*
 * Manages a single side's score & updates UI
 * Keeps track of different type of scores to display at the end of the match
 */
public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    // Scores
    private int total, coral, processor, net, barge;

    private void Start()
    {
        ResetScore();
    }

    private void ResetScore()
    {
        total = 0;
        coral = 0;
        processor = 0;
        net = 0;
        barge = 0;
        UpdateScoreText();
    }

    public void AddProcessorScore(int score)
    {
        processor += score;
        UpdateScoreText();
    }

    public void AddNetScore(int score)
    {
        net += score; 
        UpdateScoreText();
    }
    public void AddCoralScore(int score)
    {
        coral += score;
        UpdateScoreText();
    }
    public void AddBargeScore(int score)
    {
        barge += score;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        total = processor + net + coral + barge; 
        scoreText.text = total.ToString();
    }
}
