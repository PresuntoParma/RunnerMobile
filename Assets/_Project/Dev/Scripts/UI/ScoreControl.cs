using TMPro;
using UnityEngine;

public class ScoreControl : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textScore;

    public void UpdateScoreText(int score)
    {
        textScore.text = score.ToString();
    }
}
