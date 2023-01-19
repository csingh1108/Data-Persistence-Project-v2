using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;

public class MenuUIHandler : MonoBehaviour

{
    // Warning game object meant to appear if name input field is empty
    public GameObject warningText;
    //Designate the input field to capture name input
    [SerializeField] TextMeshProUGUI playerNameInput;

    // Text fields to display high score winner between sessions
    [SerializeField] TextMeshProUGUI bestPlayerName;
    [SerializeField] TextMeshProUGUI highScoreText;

    // Vars that store winner data
    private static int highScore;
    private static string bestPlayer;

    // Start is called before the first frame update
    public void StartGame()
    {

        // Only allow one instance of player data manager
        if (PlayerDataManager.Instance.playerName == "")
        {
            warningText.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    // Sets Player name in data manager once it is entered into input field
    public void SetPlayerName()
    {
        PlayerDataManager.Instance.playerName = playerNameInput.text;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }

    // Sets the winner info 
    public void Awake()
    {
        LoadRank();
        bestPlayerName.text = "Name: " + bestPlayer;
        highScoreText.text = "Score: " + highScore;
        
    }

    // Grabs winner info from existing json
    public void LoadRank()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayer = data.storedBestPlayer;
            highScore = data.storedHighScore;
        }
        
    }
    // Declares vars from json that script will extract
[System.Serializable]
class SaveData
    {
        public int storedHighScore;
        public string storedBestPlayer;
    }
}
