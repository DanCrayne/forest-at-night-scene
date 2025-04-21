using UnityEngine;

public static class TimeOfDayConstants
{
    public const float DayDuration = 1f; // Full day cycle (24 hours)

    public const float Midnight = 0f; // 12:00 AM
    public const float Dawn = 0.25f; // 6:00 AM
    public const float Noon = 0.5f; // 12:00 PM
    public const float Sunset = 0.75f; // 6:00 PM
    public const float NextMidnight = 1f; // 12:00 AM next day
}
