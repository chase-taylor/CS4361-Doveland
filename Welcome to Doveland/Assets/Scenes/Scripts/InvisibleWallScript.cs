using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWallScript : MonoBehaviour
{
    public GameObject turnBackText;
    public GameObject defaultPos;

    void OnTriggerStay(Collider other){
        if (other.CompareTag("player-camera")){
            turnBackText.SetActive(true);
        }
        if (other.CompareTag("default-pos")){
            defaultPos.GetComponent<DefaultPositionScript>().MoveToPlayer();
        }
    }

    void OnTriggerExit(Collider other){
        if (other.CompareTag("player-camera")){
            turnBackText.SetActive(false);
        }
    }
}
