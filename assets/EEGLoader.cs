using UnityEngine;
using TMPro; // Needed for TextMeshPro
using System.IO;

[System.Serializable]
public class EEGSegment
{
    public int segment;
    public float probability;
    public string recommendation;
}

public class EEGLoader : MonoBehaviour
{
    public TextMeshProUGUI outputText; // ✅ Declare this at the top

    void Start()
    {
        LoadEEGData();
    }

    void LoadEEGData()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "eeg_data.json");
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            EEGSegment[] segments = JsonHelper.FromJson<EEGSegment>(json);

            string fullOutput = "";
            foreach (EEGSegment segment in segments)
            {
                fullOutput += $"Segment {segment.segment}: {segment.recommendation} (Probability: {segment.probability:F2})\n";
            }

            // ✅ Now this works because outputText is declared
            outputText.text = fullOutput;
        }
        else
        {
            Debug.LogError("JSON file not found at path: " + path);
        }
    }
}
