using TMPro;
using UnityEngine;

public class GoalScreen : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    void Start()
    {
        // �ۑ����ꂽ�X�R�A���擾
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        finalScoreText.text = "Final Score: " + finalScore.ToString();
    }
}
