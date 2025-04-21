using UnityEngine;

public class MoonController : MonoBehaviour
{
    public float speed = 2.0f; // Speed of the moon's movement
    public Transform startingPosition; // Starting position of the moon
    public Transform endingPosition;   // Ending position of the moon
    public float arcHeight = 2.5f;     // Height of the arc

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        UpdateColor();
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        var time = GameManager.Instance.GetTimeOfDay();

        // Calculate horizontal position using linear interpolation
        float x = Mathf.Lerp(startingPosition.position.x, endingPosition.position.x, time);

        // Calculate vertical position using a sine wave for the arc
        float y = Mathf.Lerp(startingPosition.position.y, endingPosition.position.y, time)
                  + Mathf.Sin(time * Mathf.PI) * arcHeight;

        // Update the moon's position
        transform.position = new Vector3(x, y, transform.position.z);
    }

    private void UpdateColor()
    {
        // Get the current brightness from the GameManager
        float brightness = GameManager.Instance.GetCurrentBrightness();

        // Adjust the moon's alpha based on brightness (fully visible at night, invisible during the day)
        var color = spriteRenderer.color;
        color.a = 1.0f - brightness; // Alpha decreases as brightness increases
        spriteRenderer.color = color;
    }
}
