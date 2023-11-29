using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] private float setTime = 10.0f;
    [SerializeField] private TextMeshProUGUI countdownText; 

    private void Start()
    {
        if (countdownText == null)
        {
            Debug.LogError("Countdown Text is not assigned in the inspector!");
        }
        else
        {
            UpdateTimeText();
        }
    }

    private void Update()
    {
        if (setTime > 0)
        {
            setTime -= Time.deltaTime;
            UpdateTimeText();
        }
        else
        {
            setTime = 0;
            Time.timeScale = 0.0f;
            UpdateTimeText();
        }
    }

private void UpdateTimeText()
{
    if (countdownText != null)
    {
        if (setTime <= 10f)
        {
            // Change color to green
            countdownText.color = Color.green;
            
            // Show decimal points when less than 10 seconds remain
            countdownText.text = setTime.ToString("F2"); // F2 format will show two decimal points
        }
        else
        {
            // Reset to default color if you have a default color defined, otherwise it will stay green
            countdownText.color = Color.white; 

            // Format the time as before without decimal points
            int minutes = Mathf.FloorToInt(setTime / 60);
            int seconds = Mathf.FloorToInt(setTime % 60);
            countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
    else
    {
        Debug.LogError("Countdown Text is not assigned in the inspector!");
    }
}

}
