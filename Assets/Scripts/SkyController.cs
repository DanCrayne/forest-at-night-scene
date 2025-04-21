using UnityEngine;

public class SkyController : MonoBehaviour
{
    public Material skyMaterial;

    void Update()
    {
        Color skyColor = CalculateSkyColor();
        skyMaterial.SetColor("_SkyColor", skyColor);
    }

    public int DawnStarts = 6;
    public int DawnEnds = 8;
    public int DayStarts = 9;
    public int DayEnds = 16;
    public int DuskStarts = 17;
    public int DuskEnds = 18;

    public Color DeepNight = new Color(0.02f, 0.05f, 0.15f);
    public Color Dawn = new Color(0.8f, 0.5f, 0.3f);
    public Color Daylight = new Color(0.53f, 0.81f, 0.92f);
    public Color Sunset = new Color(0.9f, 0.4f, 0.2f);

    private float DawnStartsFloat => DawnStarts / 24f;
    private float DawnEndsFloat => DawnEnds / 24f;
    private float DayStartsFloat => DayStarts / 24f;
    private float DayEndsFloat => DayEnds / 24f;
    private float DuskStartsFloat => DuskStarts / 24f;
    private float DuskEndsFloat => DuskEnds / 24f;

    Color CalculateSkyColor()
    {
        var currentTime = GameManager.Instance.GetTimeOfDay();

        // Midnight → Dawn
        if (currentTime >= DawnStartsFloat && currentTime <= DawnEndsFloat)
        {
            //Debug.Log("Dawn");
            return Color.Lerp(
                DeepNight,
                Dawn,
                (currentTime - DawnStartsFloat) / (DawnEndsFloat - DawnStartsFloat)
            );
        }
        // Dawn → Daylight
        else if (currentTime >= DawnEndsFloat && currentTime <= DayStartsFloat)
        {
            //Debug.Log("Dawn → Daylight");
            return Color.Lerp(
                Dawn,
                Daylight,
                (currentTime - DawnEndsFloat) / (DayStartsFloat - DawnEndsFloat)
            );
        }
        // Daylight
        else if (currentTime >= DayStartsFloat && currentTime <= DayEndsFloat)
        {
            //Debug.Log("Day");
            return Daylight;
        }
        // Daylight → Sunset 
        else if (currentTime >= DayEndsFloat && currentTime <= DuskStartsFloat)
        {
            //Debug.Log("Daylight → Sunset");
            return Color.Lerp(
                Daylight,
                Sunset,
                (currentTime - DayEndsFloat) / (DuskStartsFloat - DayEndsFloat)
            );
        }
        // Sunet → Deep Night
        else if (currentTime >= DuskStartsFloat && currentTime <= DuskEndsFloat)
        {
            //Debug.Log("Dusk");
            return Color.Lerp(
                Sunset,
                DeepNight,
                (currentTime - DuskStartsFloat) / (DuskEndsFloat - DuskStartsFloat)
            );
        }
        // Deep Night
        else
        {
            //Debug.Log("Night");
            return DeepNight;
        }
    }
}
