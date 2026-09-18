using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private float trueScore;
    private int score;
    private int highScore;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);

        Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeScore(float ammount)
    {
        trueScore += ammount;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public float GetScore()
    {
        score = (int)trueScore;

        return score;
    }

    public int GetHighScore()
    {
        return highScore;
    }
}