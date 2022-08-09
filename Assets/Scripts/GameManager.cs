using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public int highScore;
    public string playerName;
    public string bestPlayer;
    public string s_highScore;


    private void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        SceneManager.LoadScene(0);
        DontDestroyOnLoad(gameObject);
        var instanceOfSaveData = new SaveData();
        instanceOfSaveData.LoadStats();


    }

    [System.Serializable]
   public class SaveData
    {
 
        public string saveName;
        public string saveScore;

       public void SaveStats()
        {
            GameManager.instance.s_highScore = GameManager.instance.highScore.ToString();
            SaveData data = new SaveData();
            data.saveName = GameManager.instance.bestPlayer;
            data.saveScore = GameManager.instance.s_highScore;

            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        }
        
        public void LoadStats()
        {
            string path = Application.persistentDataPath + "/savefile.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                SaveData data = JsonUtility.FromJson<SaveData>(json);

                GameManager.instance.bestPlayer = data.saveName;
                GameManager.instance.highScore = int.Parse(data.saveScore);
            }
        }



    }


}


