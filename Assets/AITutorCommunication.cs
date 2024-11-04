using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class AITutorCommunication : MonoBehaviour
{
    public TextMeshProUGUI feedbackText;   // Text UI for feedback
    public int engagementLevel;            // Simulated engagement data
    public int progress;                   // Simulated progress data
    public float temperature;              // Simulated temperature data
    public float lightLevel;               // Simulated light level data
    public bool motionDetected;            // Simulated motion detection data

    private List<string> feedbackMessages = new List<string>();  // Stores feedback messages
    private int currentFeedbackIndex = 0;                        // Tracks the current feedback message index

    private void Start()
    {
        if (feedbackText == null)
        {
            Debug.LogError("FeedbackText is not assigned in the Inspector!");
        }
        else
        {
            feedbackText.text = "Waiting for feedback..."; // Default message
        }

        StartCoroutine(SendDataToAITutor());
        StartCoroutine(DisplayFeedbackMessages());
    }

    IEnumerator SendDataToAITutor()
    {
        while (true)
        {
            // Create data payload for JSON
            StudentData data = new StudentData
            {
                engagement_level = engagementLevel,
                progress = progress,
                temperature = temperature,
                light_level = lightLevel,
                motion_detected = motionDetected
            };

            string json = JsonUtility.ToJson(data);
            Debug.Log("Sending data: " + json); // Log the data being sent

            // Set up UnityWebRequest to send POST request
            UnityWebRequest www = new UnityWebRequest("http://127.0.0.1:5001/ai-tutor", "POST");
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            // Send request and wait for feedback
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                // Get feedback and split into individual messages
                string jsonResponse = www.downloadHandler.text;
                FeedbackResponse response = JsonUtility.FromJson<FeedbackResponse>(jsonResponse);
                Debug.Log("Feedback received: " + response.feedback); // Debug log

                // Update feedback messages list
                feedbackMessages = new List<string>(response.feedback.Split('.')); // Split feedback by periods
                feedbackMessages.RemoveAll(string.IsNullOrWhiteSpace);             // Remove empty messages
            }
            else
            {
                Debug.LogError("Failed to get feedback: " + www.error);
                feedbackMessages.Clear();
                feedbackMessages.Add("Failed to retrieve feedback. Please check your connection.");
            }

            yield return new WaitForSeconds(5);  // Fetch new feedback every 5 seconds
        }
    }

    IEnumerator DisplayFeedbackMessages()
    {
        while (true)
        {
            if (feedbackMessages.Count > 0)
            {
                // Display the current feedback message
                feedbackText.text = feedbackMessages[currentFeedbackIndex];
                currentFeedbackIndex = (currentFeedbackIndex + 1) % feedbackMessages.Count;
            }
            else
            {
                feedbackText.text = "Waiting for feedback...";
            }

            yield return new WaitForSeconds(2);  // Display each message for 2 seconds
        }
    }
}

[System.Serializable]
public class StudentData
{
    public int engagement_level;
    public int progress;
    public float temperature;
    public float light_level;
    public bool motion_detected;
}

[System.Serializable]
public class FeedbackResponse
{
    public string feedback;
}
