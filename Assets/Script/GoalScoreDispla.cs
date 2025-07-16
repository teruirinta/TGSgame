using TMPro;
using UnityEngine;

public class GoalScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        finalScoreText.text = "Final Score: " + finalScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
