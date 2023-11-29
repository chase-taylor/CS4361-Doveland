using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyWulfvook : MonoBehaviour
{

    public Transform playerTransform;
    public GameObject playerObject;
    public Transform defaultPos;
    public AudioSource deathSound;
    Transform target;

    BoxCollider boxCollider;
    NavMeshAgent nav;
    Animator animator;
    int maxRange = 25;
    RaycastHit hit;
    public bool playerHiding = false;
    Rigidbody rigid;

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
        float dist = Vector3.Distance(playerTransform.position, transform.position);
        if (dist < 2){
            if (!deathSound.isPlaying) deathSound.Play();
            StartCoroutine(death(0.5f));
        }
        if (dist<maxRange && Physics.Raycast(transform.position, (playerTransform.position - transform.position), 
            out hit, maxRange)&&!playerHiding){
            if(hit.transform == playerTransform)
                target = playerTransform;
        }  
        else
            target = defaultPos;
    
        nav.SetDestination(target.position);
        transform.LookAt(new Vector3(target.position.x,transform.position.y,target.position.z));
        transform.Rotate(Vector3.up, 90.0f);
    }

    IEnumerator death(float seconds){
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("gameover");
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
            
    public void stopChase()
    {
        playerHiding = true;
    }

    public void startChase()
    {
        playerHiding = false;
    }
    
}
