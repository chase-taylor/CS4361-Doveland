using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ObjectiveScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI notesText;
    public TMPro.TextMeshProUGUI timerText;
    public float timer = 360.0f;
    int notes = 0;

    void Start()
    {
        UpdateTimer();
        UpdateNotes();
    }

    void Update()
    {
        if (timer>0) timer -= Time.deltaTime;
        UpdateTimer();
    }

    void AddNote(){
        notes++;
        UpdateNotes();
    }

    private void UpdateTimer(){
        PlayerPrefs.SetInt("timer", (int)timer);
        timerText.text = ((int)timer/60).ToString() + ":" + ((int)timer%60).ToString("D2");
        if (timer<=0) SceneManager.LoadScene("victoryscreen");
    }

    private void UpdateNotes(){
        PlayerPrefs.SetInt("notes", notes);
        notesText.text = notes.ToString() + " / 6 Notes";
        if (notes>=6) SceneManager.LoadScene("victoryscreen");
    }
}
