using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SensorDisplay : MonoBehaviour
{
    // Reference to the TextMeshProUGUI UI text component for displaying sensor data
    public TextMeshProUGUI sensorDataText;

    // Example sensor data (replace with actual data sources)
    public int engagementLevel;       // Engagement level sensor data
    public int progress;              // Progress sensor data
    public float temperature;         // Temperature sensor data
    public float lightLevel;          // Light level sensor data
    public bool motionDetected;       // Motion detection sensor data

    private void Start()
    {
        // Check if the text component is assigned
        if (sensorDataText == null)
        {
            Debug.LogError("SensorDataText is not assigned in the Inspector!");
        }
    }

    private void Update()
    {
        // Update the UI text with the latest sensor data
        if (sensorDataText != null)
        {
            sensorDataText.text = $"Engagement Level: {engagementLevel}%\n" +
                                  $"Progress: {progress}%\n" +
                                  $"Temperature: {temperature}°C\n" +
                                  $"Light Level: {lightLevel} lx\n" +
                                  $"Motion Detected: {(motionDetected ? "Yes" : "No")}";
        }
    }
}
