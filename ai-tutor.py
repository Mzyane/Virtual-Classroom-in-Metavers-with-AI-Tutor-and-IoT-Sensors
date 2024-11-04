from flask import Flask, jsonify, request

app = Flask(__name__)

@app.route('/ai-tutor', methods=['POST'])
def ai_tutor():
    # Receive data from Unity
    data = request.get_json()
    engagement_level = data.get("engagement_level", 0)
    progress = data.get("progress", 0)
    temperature = data.get("temperature", 0.0)
    light_level = data.get("light_level", 0.0)
    motion_detected = data.get("motion_detected", False)

    # AI logic to generate feedback
    feedback = []

    # Engagement feedback
    if engagement_level < 50:
        feedback.append("It seems like you’re distracted. Try focusing on the material, and take breaks if needed.")
    elif progress < 70:
        feedback.append("You’re doing well, but there’s still room for improvement! Keep going.")
    else:
        feedback.append("Excellent progress! Keep up the great work!")

    # Temperature feedback
    if temperature < 20:
        feedback.append("The temperature is quite low. Make sure you are comfortable.")
    elif temperature > 30:
        feedback.append("It's quite hot. Consider cooling your environment.")

    # Light level feedback
    if light_level < 300:
        feedback.append("The light level is low. Ensure you have enough lighting to see clearly.")
    elif light_level > 800:
        feedback.append("The light level is quite high. You might want to adjust your lighting to avoid strain.")

    # Motion detection feedback
    if motion_detected:
        feedback.append("Motion detected! Stay focused on your tasks.")

    # Ensure feedback is not empty
    if not feedback:
        feedback.append("No specific feedback available at this time.")

    return jsonify({"feedback": " ".join(feedback)})

if __name__ == '__main__':
    app.run(port=5001)
