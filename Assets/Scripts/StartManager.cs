using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public string highPlayer;

    public static StartManager Instance;

    public InputField playername;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadRecord();
    }



    public void StartNew()
    {
        MainManager.playerNameStr = playername.text;
        SceneManager.LoadScene(1);
    }


    

    [System.Serializable]
    class SaveData
    {
        public int score;
        public string highPlayer;
    }


    public void LoadRecord()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            score = data.score;
            highPlayer = data.highPlayer;

        }
    }

}

