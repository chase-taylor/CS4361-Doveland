using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    public GameObject collectText, canvas;
    public AudioSource audioSource;
    bool interactable;
    // Start is called before the first frame update
    void Start()
    {
        interactable = false;
    }

    void OnTriggerStay(Collider other){
        if (other.CompareTag("player-camera")){
            collectText.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other){
        if (other.CompareTag("player-camera")){
            collectText.SetActive(false);
            interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(interactable){
            if(Input.GetKeyDown(KeyCode.E)){
                audioSource.Play();
                collectText.SetActive(false);
                canvas.GetComponent<ObjectiveScript>().AddNote();
                gameObject.SetActive(false);
            }
        }
    }
}
