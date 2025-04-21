using UnityEngine;
using UnityEngine.Jobs;

public class StarsController : MonoBehaviour
{
    public float starSpeed = 2f; // Speed of star movement
    public Transform startingPosition;
    public Transform endingPosition;
    
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        UpdateStarOpacity();
        MoveAcrossSky();
    }

    void UpdateStarOpacity()
    {
        var color = spriteRenderer.color;
        color.a = 1 - GameManager.Instance.GetCurrentBrightness();
        spriteRenderer.color = color;
    }

    void MoveAcrossSky()
    {
        // Calculate a normalized time value that loops between 0 and 1
        float normalizedTime = Mathf.PingPong(GameManager.Instance.GetTotalElapsedTime() * starSpeed / 100, 1.0f);

        // Interpolate the position of the stars between the starting and ending positions
        transform.position = Vector3.Lerp(startingPosition.position, endingPosition.position, normalizedTime);
    }
}
