using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
  public Text nameTextDisplay;

    public void Awake()
    {
        if (GameManager.instance.playerName != "")
        {
            nameTextDisplay.text = GameManager.instance.playerName;
            Debug.Log("playerName" + GameManager.instance.playerName + " was read by StartMenu"); //this printed in console
            
        }

    }


    public void ReadStringInput(string name)
    {
        GameManager.instance.playerName = name;
        Debug.Log(name);

    }

    public void StartDaGame()
    {
        SceneManager.LoadScene(1);
    }


}
