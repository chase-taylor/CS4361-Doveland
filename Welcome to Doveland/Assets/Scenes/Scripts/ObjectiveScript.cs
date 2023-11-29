using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ObjectiveScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI notesText;
    public TMPro.TextMeshProUGUI timerText;
    public GameObject wulfvook;
    public float timer = 360.0f;
    float maxTime;
    int notes = 0;
    int lastmins = 5;

    void Start()
    {
        timerText.color = Color.white;
        UpdateTimer();
        maxTime = timer;
        UpdateNotes();
    }

    void Update()
    {
        if (timer>0) timer -= Time.deltaTime;
        UpdateTimer();
    }

    public void AddNote(){
        notes++;
        wulfvook.GetComponent<UnityEngine.AI.NavMeshAgent>().speed += 0.2f;
        print("Wulfvook speed: " + wulfvook.GetComponent<UnityEngine.AI.NavMeshAgent>().speed.ToString());
        UpdateNotes();
    }

    private void UpdateTimer(){
        PlayerPrefs.SetInt("timer", (int)timer);
        if (timer <= 10){ //show timer in green with decimal points if <= 10 seconds remain
            timerText.color = Color.green;
            timerText.text = timer.ToString("F2");
        } else {//else show in minutes:seconds format
            int mins = (int)timer/60;
            timerText.text = mins.ToString() + ":" + ((int)timer%60).ToString("D2");
            if (mins<lastmins){
                lastmins=mins;
                wulfvook.GetComponent<UnityEngine.AI.NavMeshAgent>().speed += 0.2f;
                print("Wulfvook speed: " + wulfvook.GetComponent<UnityEngine.AI.NavMeshAgent>().speed.ToString());
            }
        }
        if (timer<=0) SceneManager.LoadScene("victoryscreen");
    }

    private void UpdateNotes(){
        PlayerPrefs.SetInt("notes", notes);
        notesText.text = notes.ToString() + " / 6 Notes";
        if (notes>=6) StartCoroutine(notesVictory(0.5f));
    }

    IEnumerator notesVictory(float seconds){
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("victoryscreen");
    }
}
