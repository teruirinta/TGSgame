using TMPro;
using UnityEngine;

public class GoalScreen : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    void Start()
    {
        // 保存されたスコアを取得
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        finalScoreText.text = "Final Score: " + finalScore.ToString();
    }
}
