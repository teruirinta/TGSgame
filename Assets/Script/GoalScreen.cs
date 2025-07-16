using TMPro;
using UnityEngine;

public class GoalScreen : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    void Start()
    {
        // •Û‘¶‚³‚ê‚½ƒXƒRƒA‚ðŽæ“¾
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        finalScoreText.text = "Final Score: " + finalScore.ToString();
    }
}
