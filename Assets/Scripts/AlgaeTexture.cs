using UnityEngine;

public class AlgaeTexture : MonoBehaviour
{
    [SerializeField]
    private float rollingMagnitude; 

    private Material material;
    private Rigidbody2D rd;
    private float offsetX, offsetY = 0f;
    private Vector2 velocity; 

    private void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        material = rd.GetComponent<SpriteRenderer>().material;

        if (rd == null)
        {
            Debug.LogWarning("Algae unable to detect rigidbody 2D component"); 
        }
        if (material == null)
        {
            Debug.LogWarning("Algae unable to detect material"); 
        }
    }

    private void FixedUpdate()
    {
        velocity = rd.linearVelocity;
        offsetX += - velocity.x * rollingMagnitude; 
        offsetY += - velocity.y * rollingMagnitude;

        material.SetFloat("_OffsetX", offsetX);
        material.SetFloat("_OffsetY", offsetY);
    }
}
