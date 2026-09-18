using System;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    

    public Action PlayerGasImpulse;

    public static AdsManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);

        Instance = this;
    }

    public void ShowRewardedAd()
    {
        AdsInitializer.Instance.ShowRewardedAd();
    }

    public void GiveReward()
    {
        PlayerGasImpulse();
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
