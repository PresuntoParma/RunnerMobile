
using UnityEngine;


public class DataManager : MonoBehaviour
{

   
    public const string HIGHSCORE_KEY = "PlayerHighScore";
    public const string PLAYERNAME_KEY = "PlayerName";

    public void CreateKeys()
    {
        if (PlayerPrefs.HasKey(HIGHSCORE_KEY) && PlayerPrefs.HasKey(PLAYERNAME_KEY)) return;

        PlayerPrefs.SetInt(HIGHSCORE_KEY, 0);
        PlayerPrefs.SetString(PLAYERNAME_KEY, string.Empty);
    }

    public void Save(int highScore, string playerName)
    {
        PlayerPrefs.SetInt(HIGHSCORE_KEY, highScore);
        PlayerPrefs.SetString(PLAYERNAME_KEY, playerName);
    }

    public void Delete()
    {
        PlayerPrefs.DeleteAll();
    }
}
