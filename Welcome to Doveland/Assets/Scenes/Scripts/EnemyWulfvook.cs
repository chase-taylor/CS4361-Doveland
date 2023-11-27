using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWulfvook : MonoBehaviour
{

    public Transform playerTransform;
    public GameObject playerObject;
    public Transform defaultPos;
    Transform target;
    Rigidbody rigid;
    BoxCollider boxCollider;
    NavMeshAgent nav;
    Animator animator;
    int maxRange = 25;
    RaycastHit hit;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        target = playerTransform;
    }

    void Update()
    {
        float dist;
        if ((dist = Vector3.Distance(playerTransform.position, transform.position))<maxRange&&
        Physics.Raycast(transform.position, (playerTransform.position - transform.position), out hit, maxRange)){
            if(hit.transform == playerTransform)
                target = playerTransform;
        }  
        else if(dist>maxRange+5)
            target = defaultPos;
    
        nav.SetDestination(target.position);
        transform.LookAt(target);
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

    void OnTriggerEnter(Collider other) {
        if (other.tag=="NoiseSphere") {
            playerObject.GetComponent<NoiseSphereScript>().Enter();
            print("Enter");
        }
            
    }

    void OnTriggerExit(Collider other) {
        if (other.tag=="NoiseSphere") {
            playerObject.GetComponent<NoiseSphereScript>().Exit();
            print("Exit");
        }
            
    }
    
}
