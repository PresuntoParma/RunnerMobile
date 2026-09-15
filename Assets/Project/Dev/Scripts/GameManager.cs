using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private KeyboardControls player;

    // ADICIONADO: painel de Game Over
    [SerializeField] private GameObject gameOverPanel;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowRewardedAd()
    {
        AdsInitializer.Instance.ShowRewardedAd();
    }

    public void GiveReward()
    {
        player.GasImpulse();

        // ADICIONADO: fecha a tela de Game Over
        gameOverPanel.SetActive(false);

        // ADICIONADO: retoma o jogo
        ResumeGame();
    }

    // ADICIONADO
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    // ADICIONADO
    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}