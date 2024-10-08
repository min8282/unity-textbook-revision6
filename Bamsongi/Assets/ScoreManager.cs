using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // 점수를 표시할 텍스트
    private int score = 0; // 점수는 0으로 초기화

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int value)
    {
        score += value; // 점수 추가
        UpdateScoreText(); // 텍스트 업데이트
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Count: " + score.ToString();
        }
    }
}
