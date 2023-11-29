using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreenScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI objectiveText;
    int notes = 0;
    int timer = 0;
    public int maxTime = 360;

    public void Start(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if(PlayerPrefs.HasKey("notes")){
            notes = PlayerPrefs.GetInt("notes");
        }
        if(PlayerPrefs.HasKey("timer")){
            timer = PlayerPrefs.GetInt("timer");
        }
        timer = maxTime - timer;
        objectiveText.text = $"You collected {notes}/6 notes in {timer/60:0}:{timer%60:00}";
    }

    public void RestartButton(){
        SceneManager.LoadScene("mainstreet");
    }

    public void MainMenuButton(){
        SceneManager.LoadScene("mainmenu");
    }
}

