using System;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class ReefSceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject coral;

    // Left reef
    [SerializeField]
    private GameObject[] reefParts;
    private bool[] status; // False = warning

    private Vector2 pos;
    private int currentPartIndex;

    private KeyCode Action = KeyCode.Space;

    private void Start()
    {
        status = new bool[reefParts.Length];
        Array.Fill(status, true); 
    }

    private void Update()
    {
        pos = coral.transform.position;
        CheckPosition();

        // Check "Action" input
        if (UnityEngine.Input.GetKeyDown(Action))
        {
            if (currentPartIndex >= 0 && currentPartIndex < reefParts.Length)
            { 
                reefParts[currentPartIndex].GetComponent<SpriteResolver>().SetCategoryAndLabel(reefParts[currentPartIndex].GetComponent<SpriteResolver>().GetCategory(), "Warning");
                status[currentPartIndex] = false; 
            }
            else
                Debug.LogWarning("Coral not currently on a reef part"); 
        }

    }

    // Check which part the coral icon is currently on
    private void CheckPosition()
    {
        // Reset index
        currentPartIndex = -1;

        for (int i = 0; i < reefParts.Length; i++)
        {
            // If the current part is not marked as warning or full
            if (status[i])
            {
                GameObject part = reefParts[i];

                BoxCollider2D collider = part.GetComponent<BoxCollider2D>();
                if (collider == null)
                    Debug.LogWarning("Reef part did NOT contain a collider");

                SpriteResolver spriteResolver = part.GetComponent<SpriteResolver>();
                if (spriteResolver == null)
                    Debug.LogWarning("Reef part did NOT contain a spriteResolver");

                if (collider.OverlapPoint(pos))
                {
                    spriteResolver.SetCategoryAndLabel(spriteResolver.GetCategory(), "Selected");
                    currentPartIndex = i;
                }
                else
                {
                    spriteResolver.SetCategoryAndLabel(spriteResolver.GetCategory(), "Normal");
                }
            }
        }
    }
}
