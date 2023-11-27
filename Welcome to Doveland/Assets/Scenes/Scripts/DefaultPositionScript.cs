using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultPositionScript : MonoBehaviour
{

    public Transform player;

    // Update is called once per frame
    void Update()
    {
        //default position moves a bit every frame update so the wulfvook wanders
        transform.position += new Vector3(Random.Range(-5,5)/40f,0,Random.Range(-5,5)/40f);
    }

    void MoveToPlayer(){
        transform.position = player.position;
    }
}
