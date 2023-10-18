using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightControl : MonoBehaviour
{
    public Transform playerCamera;
    public Light flashlight;
    private bool isFlashlightOn = false;
    private Vector3 originalLocalPosition;

<<<<<<< Updated upstream
    public GameObject flashlightClick; // Assign your GameObject with AudioSource component here

=======
>>>>>>> Stashed changes
    public float MinTime = 1f;
    public float MaxTime = 10f;
    public float Timer;

<<<<<<< Updated upstream
    // Get the AudioSource component from the flashlightClick GameObject
    private AudioSource flashlightAudio;
=======
>>>>>>> Stashed changes

    void Start()
    {
        Timer = Random.Range(MinTime, MaxTime);
<<<<<<< Updated upstream
        flashlight.enabled = false;
        originalLocalPosition = flashlight.transform.localPosition;

        // Get the AudioSource component
        flashlightAudio = flashlightClick.GetComponent<AudioSource>();
=======
        flashlight.enabled = isFlashlightOn; // Ensure the flashlight starts in the correct state
        originalLocalPosition = flashlight.transform.localPosition;
>>>>>>> Stashed changes
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
<<<<<<< Updated upstream
            isFlashlightOn = !isFlashlightOn;
            flashlight.enabled = isFlashlightOn;

            // Play the audio when 'F' key is pressed
            flashlightAudio.Play();
        }

        flashlight.transform.position = playerCamera.position;
        flashlight.transform.localPosition = originalLocalPosition;
        flashlight.transform.rotation = playerCamera.rotation;
=======
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

       
>>>>>>> Stashed changes
    }

    void FlickerLight()
    {
        if (Timer > 0)
            Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            flashlight.enabled = !flashlight.enabled;
            Timer = Random.Range(MinTime, MaxTime);
<<<<<<< Updated upstream
=======
           
>>>>>>> Stashed changes
        }
    }
}
