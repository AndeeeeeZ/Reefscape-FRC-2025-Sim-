using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private float speed;

    private Vector3 targetPoint; 
    private void Start()
    {
        // Target's x & y 
        // Maintain the camera's z value
        targetPoint =
            new Vector3(target.transform.position.x,
                target.transform.position.y,
                transform.position.z);
    }
    private void LateUpdate()
    {
        targetPoint.x = target.transform.position.x;
        targetPoint.y = target.transform.position.y; 

        transform.position = 
            Vector3.Lerp(transform.position, 
                targetPoint, 
                speed * Time.deltaTime);
    }
}
