using UnityEngine;

public class MountainsController : MonoBehaviour
{
    private SpriteRenderer mountainRenderer;
    private Color originalColor;

    void Start()
    {
        mountainRenderer = GetComponent<SpriteRenderer>();
        originalColor = mountainRenderer.color;
    }

    void Update()
    {
        float brightness = GameManager.Instance.GetCurrentBrightness();

        // Interpolate between black and the original color based on brightness
        mountainRenderer.color = Color.Lerp(Color.black, originalColor, brightness);
    }
}
