using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    private int score = 0;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    public OnTrigger onTrigger;

    private void Start()
    {
        onTrigger = GameObject.FindGameObjectWithTag("Goal").GetComponent<OnTrigger>();
        onTrigger.scoreCounter = this;
        UpdateScoreText();
    }

    public void IncrementScore()
    {
        score++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
    
    public int getScore()
    {
        return score;
    }
}
