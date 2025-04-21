using UnityEngine;

public class StarsController : MonoBehaviour
{
    public float starSpeed = 0.1f; // Speed of star movement
    public float starsFadeAt = 0.5f; // Time of day when stars start to fade
    
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        var color = spriteRenderer.color;
        color.a = 1 - GameManager.Instance.GetCurrentBrightness();
        spriteRenderer.color = color;
    }
}
