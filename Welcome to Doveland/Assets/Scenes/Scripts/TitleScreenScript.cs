using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenScript : MonoBehaviour
{
    public void Start(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void StartButton(){
        SceneManager.LoadScene("mainstreet");
    }
    public void ExitButton(){
        Application.Quit();
    }
}
