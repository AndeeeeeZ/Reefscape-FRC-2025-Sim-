using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectDistributor : MonoBehaviour
{
    [SerializeField]
    GameObject objectPrefab;

    [SerializeField]
    Vector2[] locations;

    private void Start()
    {
        foreach (var location in locations)
        {
            Instantiate(objectPrefab, new Vector3(location.x, location.y, 0), Quaternion.identity); 
        }
    }
}
