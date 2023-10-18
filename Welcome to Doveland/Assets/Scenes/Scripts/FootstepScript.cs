using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepScript : MonoBehaviour
{
    public GameObject concreteFootstep;
    public GameObject grassFootstep;
    public GameObject woodFootstep;
    public GameObject runningConcreteFootstep;
    public GameObject runningGrassFootstep;
    public GameObject runningWoodFootstep;

    private bool isRunning = false;

    // Define layers for different surfaces (assign them in the Unity inspector)
    public LayerMask concreteLayer;
    public LayerMask grassLayer;
    public LayerMask woodLayer;

    private Transform playerTransform;

    public float raycastHeightOffset = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        SetRunningSounds(false);
        SetFootstepSounds(false); // Initially, no footsteps are playing
        playerTransform = transform; // Assuming this script is attached to the player character
    }

    // Update is called once per frame
    void Update()
    {
        HandleFootsteps();

        isRunning = Input.GetKey(KeyCode.LeftShift);
    }

    void HandleFootsteps()
    {
        if (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d"))
        {
            if (!isRunning)
            {
                DetectSurface();
            }
            else
            {
                SetFootstepSounds(false); // If running, stop regular footsteps
                DetectSurface();
            }
        }
        else
        {
            SetRunningSounds(false);
            SetFootstepSounds(false);
        }
    }

   

    void DetectSurface()
    {
        RaycastHit hit;

        Vector3 raycastOrigin = playerTransform.position + Vector3.up * raycastHeightOffset;

        if (Physics.Raycast(raycastOrigin, Vector3.down, out hit, 1.5f))
        {
            Debug.Log("Hit: " + hit.collider.tag);
            Debug.Log("Running" + isRunning);

            if (hit.collider.CompareTag("Concrete"))
            {
                if (isRunning)
                {
                    SetRunningFootstepSounds(true, false, false);
                }
                else
                {
                    SetRunningSounds(false);
                    SetFootstepSounds(true, false, false);
                }
            }
            else if (hit.collider.CompareTag("Grass"))
            {
                if (isRunning)
                {
                    SetRunningFootstepSounds(false, true, false);
                }
                else
                {
                    SetRunningSounds(false);
                    SetFootstepSounds(false, true, false);
                }
            }
            else if (hit.collider.CompareTag("Wood"))
            {
                if (isRunning)
                {
                    SetRunningFootstepSounds(false, false, true);
                }
                else
                {
                    SetRunningSounds(false);
                    SetFootstepSounds(false, false, true);
                }
            }
            else
            {
                SetRunningSounds(false);
                SetFootstepSounds(false);
            }
        }
    }

    void SetFootstepSounds(bool isConcreteActive, bool isGrassActive, bool isWoodActive)
    {
        concreteFootstep.SetActive(isConcreteActive);
        grassFootstep.SetActive(isGrassActive);
        woodFootstep.SetActive(isWoodActive);
    }

    void SetRunningFootstepSounds(bool isConcreteActive, bool isGrassActive, bool isWoodActive)
    {
        runningConcreteFootstep.SetActive(isConcreteActive);
        runningGrassFootstep.SetActive(isGrassActive);
        runningWoodFootstep.SetActive(isWoodActive);
    }

    void SetFootstepSounds(bool isActive)
    {
        concreteFootstep.SetActive(isActive);
        grassFootstep.SetActive(isActive);
        woodFootstep.SetActive(isActive);
    }

    void SetRunningSounds(bool isActive)
    {
        runningConcreteFootstep.SetActive(isActive);
        runningGrassFootstep.SetActive(isActive);
        runningWoodFootstep.SetActive(isActive);
    }
}
