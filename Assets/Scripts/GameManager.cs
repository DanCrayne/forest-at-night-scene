using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float totalTimePassed;
    public static GameManager Instance;

    [SerializeField]
    private float currentBrightness; // for debugging in editor

    [SerializeField]
    private float timeOfDay;


    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object alive across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instance
        }
    }

    void Update()
    {
        timeOfDay += Time.deltaTime / 60f; // One minute = full day
        if (timeOfDay > 1f) timeOfDay -= 1f; // Loop back to 0 after a full day
    }

    /// <summary>
    /// Returns the time of day as a float between 0 and 1.
    /// 0 - midnight, 0.5 midday, 1 - next midnight.
    /// </summary>
    /// <returns>A value between 0 and 1 representing the current time of day</returns>
    public float GetTimeOfDay()
    {
        return timeOfDay;
    }

    /// <summary>
    /// Returns the current brightness between 0 and 1 - 0 being dark and 1 light
    /// </summary>
    /// <returns>A float representing the current brightness</returns>
    public float GetCurrentBrightness()
    {
        var brightness = Mathf.Sin(timeOfDay * Mathf.PI);
        currentBrightness = brightness; // for viewing in editor
        return brightness;
    }

    /// <summary>
    /// Returns the current hour of the day as an integer between 0 and 23
    /// </summary>
    /// <returns>An integer representing the current hour of a 24 hour day</returns>
    public int GetCurrentHourOfDay()
    {
        int totalMinutes = Mathf.FloorToInt(timeOfDay * 1440); // 1440 minutes in a day
        int hours = totalMinutes / 60;
        return hours;
    }
}
