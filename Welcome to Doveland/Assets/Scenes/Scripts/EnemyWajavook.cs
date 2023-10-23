using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWajavook : MonoBehaviour
{

    public Transform target;
    Rigidbody rigid;
    BoxCollider boxCollider;
    NavMeshAgent nav;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        nav.SetDestination(target.position);
        transform.LookAt(target);

    }

    void FreezeVelocity()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
        
    }
    void FixedUpdate() 
    {
        FreezeVelocity();
    }
    
}
