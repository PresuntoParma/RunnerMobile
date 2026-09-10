using UnityEngine;
using UnityEngine.Advertisements; // Importa a API de anúncios do Unity
// Classe responsável por inicializar e gerenciar anúncios
// Implementa três interfaces para lidar com eventos de inicialização, carregamento e exibição de anúncios
public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsShowListener, IUnityAdsLoadListener
{
    // IDs dos jogos para cada plataforma, configuráveis pelo Inspector
    [SerializeField] string androidGameId;
    [SerializeField] string iOSGameId;
    [SerializeField] bool testMode = true; // Define se os anúncios estarão em modo de teste
    private string gameId; // ID do jogo usado na plataforma atual
    private string interstitialAdUnitId = "Interstitial_Android"; // ID do anúncio intersticial
    private string rewardedAdUnitId = "Rewarded_Android"; // ID do anúncio recompensado
  
 // Chamado automaticamente quando o script é carregado
 void Awake()
    {
        InitializeAds(); // Inicializa o sistema de anúncios
    }
    // Inicializa o Unity Ads
    public void InitializeAds()
    {
        // Define o ID do jogo de acordo com a plataforma
#if UNITY_IOS
 gameId = iOSGameId;
#else
        gameId = androidGameId;
#endif
        // Verifica se o sistema de anúncios ainda não foi inicializado e se é suportado na plataforma
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, testMode, this); // Inicializa e passa "this" para receber callbacks
        }
    }
    // Carrega um anúncio intersticial
    public void LoadInterstitialAd()
    {
        Advertisement.Load(interstitialAdUnitId, this); // Usa a interface IUnityAdsLoadListener para callbacks
    }
    // Mostra o anúncio intersticial carregado
    public void ShowInterstitialAd()
    {
        Advertisement.Show(interstitialAdUnitId, this); // Usa a interface IUnityAdsShowListener para callbacks
    }
    
 // Carrega um anúncio recompensado
 public void LoadRewardedAd()
    {
        Advertisement.Load(rewardedAdUnitId, this);
    }
    // Mostra o anúncio recompensado carregado
    public void ShowRewardedAd()
    {
        Advertisement.Show(rewardedAdUnitId, this);
    }
    // -------- Implementação das interfaces --------
    // Chamado quando a inicialização dos anúncios é bem-sucedida
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        LoadInterstitialAd(); // Carrega anúncio intersticial
        LoadRewardedAd(); // Carrega anúncio recompensado
    }
    // Chamado quando a inicialização dos anúncios falha
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
    // Chamado quando um anúncio é carregado com sucesso
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);
    }
    // Chamado quando o carregamento do anúncio falha
 
 public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }
    // Chamado quando ocorre erro ao mostrar um anúncio
    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }
    // Chamado quando o anúncio começa a ser exibido
    public void OnUnityAdsShowStart(string adUnitId) { }
    // Chamado quando o usuário clica no anúncio
    public void OnUnityAdsShowClick(string adUnitId) { }
    // Chamado quando o anúncio termina de ser exibido
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        // Se o anúncio exibido foi o recompensado e foi completado
        if (adUnitId.Equals(rewardedAdUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Rewarded ad completed! Give reward to player.");
            // Aqui você deve adicionar a lógica para dar a recompensa ao jogador
        }
    }
}