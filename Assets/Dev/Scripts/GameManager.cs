using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private KeyboardControls player;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowRewardedAd()
    {
        PauseGame();
        AdsInitializer.Instance.ShowRewardedAd();
    }

    public void GiveReward()
    {
        player.GasImpulse();
        ResumeGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}