using UnityEngine;

public class AdsRewardHelper : MonoBehaviour
{
    [SerializeField] private KeyboardControls player;

    [SerializeField] private GameObject gameOverPanel;

    private void Start()
    {
        AdsManager.Instance.PlayerGasImpulse += player.GasImpulse;
        AdsManager.Instance.PlayerGasImpulse += CloseGameOverPanel;
    }

    public void CloseGameOverPanel()
    {
        gameOverPanel.SetActive(false);
    }
}
