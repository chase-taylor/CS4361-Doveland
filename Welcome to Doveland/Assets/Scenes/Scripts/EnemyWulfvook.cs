using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWulfvook : MonoBehaviour
{

    public Transform target;
    public Transform home;
    Rigidbody rigid;
    BoxCollider boxCollider;
    NavMeshAgent nav;
    Animator animator;
    public bool playerHiding = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        if (playerHiding == true)
        {
            nav.SetDestination(home.position);
            transform.LookAt(home);

        }
        else
        {
            nav.SetDestination(target.position);
            transform.LookAt(target);
        }
        
        transform.Rotate(Vector3.up, 90.0f);
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

    void StartCrawlAnimation()
    {
        animator.SetTrigger("Crawl");
    }

    public void stopChase()
    {
        playerHiding = true;
    }

    public void startChase()
    {
        playerHiding = false;
    }
    
}
