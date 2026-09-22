using TMPro;
using UnityEngine;

public class SetHighScoreText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textHighScore;

    private void Start()
    {
        textHighScore.text = GameManager.Instance.GetHighScore().ToString();
        print(GameManager.Instance.GetHighScore().ToString());
    }
}
