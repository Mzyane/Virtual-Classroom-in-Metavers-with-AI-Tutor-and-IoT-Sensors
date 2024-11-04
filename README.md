AI Tutor with IoT Sensors for Virtual Classroom (Group 5) Final Project for Oman Tech Mahindra Training

## Overview

This project combines **AI-driven feedback**, **IoT sensor data**, and **virtual classroom** elements to create a responsive and immersive learning environment. The goal is to simulate the benefits of a physical classroom, enabling personalized interaction and real-time adaptation to enhance student engagement and learning outcomes. 

### Key Components

1. **AI Tutor**  
   The AI tutor module provides feedback based on various inputs, including student engagement, progress, and environmental factors. The feedback is personalized to encourage student focus, monitor progress, and adapt the virtual classroom experience.

2. **IoT Sensors**  
   Sensors for **temperature**, **light level**, and **motion detection** collect data in real time to provide contextual feedback that aligns with the student's learning environment. For instance, if lighting is insufficient, the AI tutor may suggest adjustments to improve focus.

3. **Virtual Classroom Environment**  
   The virtual classroom includes **animated interactions** and **sensor-driven responses**, designed to make online learning more engaging and personalized. The system simulates teacher-student greetings, monitors classroom conditions, and adjusts feedback accordingly.

## Features

- **Real-time Feedback**: The AI tutor offers timely feedback based on engagement and progress data.
- **Environment Awareness**: IoT sensors measure ambient temperature, light levels, and detect motion, allowing the AI tutor to provide personalized suggestions based on real-time conditions.
- **Interactive UI**: Displays sensor data values and feedback messages in real-time, adapting every few seconds to maintain focus and engagement.
- **Animated Interactions**: Features animations, such as a teacher-student wave with greeting text, to simulate classroom presence and build connection.

## Project Structure

### AI Tutor

- **Feedback Logic**: Based on engagement level, progress, temperature, light, and motion detection data.
- **Data Processing**: Uses a Flask server (Python) to handle POST requests, compute feedback, and respond with JSON-formatted messages for Unity.
- **Unity Integration**: Uses a coroutine in Unity to send sensor and engagement data to the AI tutor and update feedback text in the UI.

### IoT Sensors

- **Temperature**: Captures room temperature data for comfort-based feedback.
- **Light Level**: Monitors lighting to ensure optimal visual conditions for learning.
- **Motion Detection**: Detects movement to monitor attention and focus.

### Virtual Classroom UI

- **Feedback Display**: Uses TextMeshProUGUI to display feedback messages from the AI tutor in the virtual environment.
- **Sensor Data UI**: Displays sensor values on the screen, such as:
  ```
  Engagement Level: 90
  Progress: 70
  Temperature: 24°C
  Light Level: 50
  Motion Detected: Yes
  ```
- **Interactive Animation**: Teacher-student wave animation with “Hello, Good morning!” text appearing on the UI when a wave gesture is detected.

### Usage

1. **Start Flask Server**: Run the server to enable AI-driven feedback.
2. **Launch Unity Scene**: Start the Unity scene to initiate data collection and feedback display.
3. **Check Feedback**: Observe the feedback text in real time as the AI tutor responds to engagement, progress, and sensor data.

## Future Enhancements

- **Enhanced Personalization**: Add more sensors or data sources to personalize the experience further.
- **Voice Feedback**: Incorporate audio feedback from the AI tutor.
- **Emotion Recognition**: Use facial recognition to assess and respond to students' emotional states.
