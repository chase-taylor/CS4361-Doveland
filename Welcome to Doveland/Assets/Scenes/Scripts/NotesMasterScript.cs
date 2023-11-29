using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotesTextScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textObj;

    int notes = 0;

    void Start()
    {
        textObj.text = notes.ToString() + " / 6 Notes";
    }

    void AddNote(){
        notes++;
        Start();
        CheckFinished();
    }

    private void CheckFinished(){
        if (notes>=6);
    }
}
