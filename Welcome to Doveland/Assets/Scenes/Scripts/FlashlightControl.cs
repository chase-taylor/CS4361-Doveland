using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightControl : MonoBehaviour
{
    public Transform playerCamera;
    public Light flashlight;
    private bool isFlashlightOn = false;
    private Vector3 originalLocalPosition;

    public float MinTime = 1f;
    public float MaxTime = 10f;
    public float Timer;


    void Start()
    {
        Timer = Random.Range(MinTime, MaxTime);
        flashlight.enabled = isFlashlightOn; // Ensure the flashlight starts in the correct state
        originalLocalPosition = flashlight.transform.localPosition;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isFlashlightOn = !isFlashlightOn; // Toggle the flashlight state

            // Toggle the flashlight on or off
            flashlight.enabled = isFlashlightOn;
        }

        // Position the flashlight at the camera's position
        flashlight.transform.position = playerCamera.position;

        // Restore the original local position (to avoid moving it up or down)
        flashlight.transform.localPosition = originalLocalPosition;

        // Rotate the flashlight to match the camera's rotation
        flashlight.transform.rotation = playerCamera.rotation;

       
    }

    void FlickerLight()
    {
        if (Timer > 0)
            Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            flashlight.enabled = !flashlight.enabled;
            Timer = Random.Range(MinTime, MaxTime);
           
        }
    }
}
