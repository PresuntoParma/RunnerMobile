
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    private int highScore = GameManager.Instance.GetHighScore();
    private int score = GameManager.Instance.GetScore();    
    [SerializeField] private Button bSave;
    [SerializeField] private Button bLoad;
    //[SerializeField] private Button bDelete;
    //[SerializeField] private Button bClear;
   

    public InputField inputPlayerName;
    public Text playerHighScoreValue;
    public Text playerScoreValue;

    [SerializeField] private Text textStatus;

    [SerializeField] private DataManager dataManager;

    private void Awake()
    {
        dataManager = GetComponent<DataManager>();
    }

    private void Start()
    {
       playerHighScoreValue.text = highScore.ToString();
       playerScoreValue.text = score.ToString();

        bSave.onClick.AddListener(ExecuteSave);
        bLoad.onClick.AddListener(ExecuteLoad);
        // bDelete.onClick.AddListener(ExecuteDelete);
        // bClear.onClick.AddListener(ExecuteClear);
        
    }

    private void ExecuteClear()
    {
        inputPlayerName.text = string.Empty;
        playerHighScoreValue.text = string.Empty;
        
    }

    private void ExecuteDelete()
    {
        dataManager.Delete();
    }

    private void ExecuteLoad()
    {
        inputPlayerName.text = PlayerPrefs.GetString(DataManager.PLAYERNAME_KEY);
        playerHighScoreValue.text = PlayerPrefs.GetInt(DataManager.HIGHSCORE_KEY).ToString();
    }

    private void ExecuteSave()
    {
        dataManager.CreateKeys();

        if (inputPlayerName.text != string.Empty && highScore > 0)
        {
            dataManager.Save(highScore, inputPlayerName.text);
            Status("Dados salvo.");
        }
        else
        {
            Status("Não há dados para salvar.");
        }

    }

    private void Status(string msg)
    {
        textStatus.text = msg;
    }
}