using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NoiseSphereScript : MonoBehaviour
{
    public GameObject noiseSphere;
    public Transform defaultPos;
    int radius;
    bool occupied = false;

    void Update() {
        if(occupied)
            defaultPos.position = transform.position;
    }

    private void Enable() {
        noiseSphere.SetActive(true);
    }
    private void Disable() {
        noiseSphere.SetActive(false);
    }
    public void Handle(bool isMoving, bool isRunning) {
        if (isMoving){
            Enable();
            radius = isRunning ? 80 : 40;
            noiseSphere.transform.localScale = new Vector3(radius,radius,radius);
        } else Disable();
    }
    public void Enter() {
        occupied = true;
    }
    public void Exit() {
        occupied = false;
    }
}