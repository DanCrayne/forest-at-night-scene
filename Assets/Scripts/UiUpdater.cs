using TMPro;
using UnityEngine;

public class UiUpdater : MonoBehaviour
{
    public TMP_Text timeText;

    void Update()
    {
        timeText.text = $"{FormatTime24Hr(GameManager.Instance.GetTimeOfDay())}";
    }
    private string FormatTime24Hr(float timeOfDay)
    {
        int totalMinutes = Mathf.FloorToInt(timeOfDay * 1440); // 1440 minutes in a day
        int hours = totalMinutes / 60;
        int minutes = totalMinutes % 60;
        return $"{hours:D2}:{minutes:D2}"; // Format as HH:mm
    }
}
