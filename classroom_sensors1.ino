const int lightSensorPin = A0;      // Light sensor connected to A0
const int tempSensorPin = A1;       // Temperature sensor connected to A1
const int pirSensorPin = 2;         // PIR motion sensor connected to D2

void setup() {
    Serial.begin(9600);             // Initialize serial communication at 9600 baud rate
    pinMode(pirSensorPin, INPUT);   // Set PIR sensor as input
}

void loop() {
    // Read data from the light sensor (Photoresistor)
    int lightValue = analogRead(lightSensorPin);

    // Read data from the temperature sensor (TMP36 or LM35)
    int tempValue = analogRead(tempSensorPin);
    float voltage = (tempValue / 1024.0) * 5.0;
    float temperatureC = (voltage - 0.5) * 100;  // Convert the voltage to temperature in Celsius

    // Read data from the PIR motion sensor
    int motionDetected = digitalRead(pirSensorPin);

    // Print the sensor values to the Serial Monitor
    Serial.print("Light Level: ");
    Serial.print(lightValue);
    Serial.print(" | Temperature: ");
    Serial.print(temperatureC);
    Serial.print(" °C | Motion Detected: ");
    Serial.println(motionDetected == HIGH ? "Yes" : "No");

    delay(2000);  // Wait 2 seconds before reading again
}
