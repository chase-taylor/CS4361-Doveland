using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI notesText;
    public TMPro.TextMeshProUGUI timerText;
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
        notesText.text = notes.ToString() + "/6 Notes Collected";
        timerText.text = $"Survived for {timer/60:0}:{timer%60:00}";
    }

    public void RestartButton(){
        SceneManager.LoadScene("mainstreet");
    }

    public void MainMenuButton(){
        SceneManager.LoadScene("mainmenu");
    }
}
