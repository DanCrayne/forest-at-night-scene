using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timeOfDay; // 0 = midnight, 0.5 = noon, 1 = next midnight
    public float totalTimePassed;
    public static GameManager Instance;

    [SerializeField]
    private float currentBrightness;

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

        currentBrightness = Mathf.Sin(timeOfDay * Mathf.PI * 2);
    }

    public float GetCurrentBrightness()
    {
        return Mathf.Sin(timeOfDay * Mathf.PI);
    }

    public int GetCurrentHourOfDay()
    {
        int totalMinutes = Mathf.FloorToInt(timeOfDay * 1440); // 1440 minutes in a day
        int hours = totalMinutes / 60;
        return hours;
    }
}
