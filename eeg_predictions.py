import json
import random

# Dummy prediction values (replace this with your actual model's predictions)
predictions = [random.random() for _ in range(10)]  # simulate 10 segments

# Define the recommendation function
def recommend(prob):
    if prob < 0.5:
        return "Normal brain activity"
    else:
        return "Abnormal activity detected. Consider neurofeedback therapy."

# Prepare the result dictionary
results = []
for i in range(len(predictions)):
    results.append({
        "segment": i,
        "probability": round(float(predictions[i]), 4),
        "recommendation": recommend(predictions[i])
    })

# Save to JSON in the same folder
with open("eeg_predictions.json", "w") as f:
    json.dump(results, f, indent=4)

print("✅ eeg_predictions.json generated successfully.")
