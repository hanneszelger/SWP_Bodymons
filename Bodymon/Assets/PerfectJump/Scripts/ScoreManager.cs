using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text currentScoreLabel, highScoreLabel, currentScoreGameOverLabel, highScoreGameOverLabel;

    int currentScore, highScore;
    // Start is called before the first frame update

    //init and load highscore
    void Start()
    {
        if (!PlayerPrefs.HasKey("HighScore"))
            PlayerPrefs.SetInt("HighScore", 0);

        highScore = PlayerPrefs.GetInt("HighScore");

        UpdateHighScore();
        ResetCurrentScore();
    }

    //save and update highscore
    void UpdateHighScore()
    {
        if (currentScore > highScore)
            highScore = currentScore;

        highScoreLabel.text = highScore.ToString();
        PlayerPrefs.SetInt("HighScore", highScore);
    }

    //update currentscore
    public void UpdateScore(int value)
    {
        currentScore += value;
        currentScoreLabel.text = currentScore.ToString();
    }

    //reset current score
    public void ResetCurrentScore()
    {
        currentScore = 0;
        UpdateScore(0);
    }

    //update gameover scores
    public void UpdateScoreGameover()
    {
        UpdateHighScore();

        currentScoreGameOverLabel.text = currentScore.ToString();
        highScoreGameOverLabel.text = highScore.ToString();
    }
}
