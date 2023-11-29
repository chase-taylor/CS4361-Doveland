using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreTextObj;

    public void Start(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Setup(int notes){
        gameObject.SetActive(true);
        scoreTextObj.text = notes.ToString() + "/6 Notes Collected";
    }

    public void RestartButton(){
        SceneManager.LoadScene("mainstreet");
    }

    public void MainMenuButton(){
        SceneManager.LoadScene("mainmenu");
    }
}
