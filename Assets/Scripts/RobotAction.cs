using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RobotAction : MonoBehaviour
{
    [SerializeField]
    private bool debug; 

    [SerializeField]
    private GameObject algaeMark, coralMark;

    // This is an additional "trigger" collider that is bigger than the rigidbody
    // Which gives more range for the player to pick up stuff
    [SerializeField]
    private Collider2D pickUpRange;

    private List<Collider2D> colliders = new List<Collider2D>();

    private bool haveAlgae, haveCoral; 
    private void Start()
    {
        haveAlgae = false;
        haveCoral = false;
        algaeMark.SetActive(haveAlgae); 
        coralMark.SetActive(haveCoral);
    }

    public void DetectGamePiece()
    {
        int contactCount = pickUpRange.Overlap(colliders);
        for (int i = 0; i < contactCount; i++)
        {
            GameObject otherObject = colliders[i].gameObject;
            if (otherObject.CompareTag("Algae"))
            {
                PickUpAlgae(otherObject);

                if (debug)
                    Debug.Log("Algae detected"); 
            }
            else if (otherObject.CompareTag("Coral"))
            {
                PickUpCoral();
                if (debug)
                    Debug.Log("Coral detected");
            }
        }
    }

    public void DetectFieldObject()
    {
        int contactCount = pickUpRange.Overlap(colliders);
        for (int i = 0; i < contactCount; i++)
        {
            GameObject otherObject = colliders[i].gameObject;
            if (otherObject.CompareTag("Processor"))
            {
                RemoveAlgae();
            }
        }
    }

    public void PickUpAlgae(GameObject algae)
    {
        if (!haveAlgae)
        {
            haveAlgae = true;
            algaeMark.SetActive(true);
            DestroyImmediate(algae);

            if (debug)
                Debug.Log("Algae picked up & destroyed");
        }
        else
        {
            Debug.LogWarning("Can't pick up more than 1 algae at a time");
        }
    }

    public void PickUpCoral()
    {
        if (!haveCoral)
        {
            haveCoral = true;
            coralMark.SetActive(true);

            if (debug)
                Debug.Log("Coral picked up");
        }
        else
        {
            Debug.LogWarning("Can't pick up more than 1 coral at a time");
        }
    }

    public void RemoveAlgae()
    {
        if (haveAlgae)
        {
            haveAlgae = false;
            algaeMark.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Robot is not currently holding an algae");
        }
    }


    /*
     * TODO: 
     * Method to remove coral and algae
     * Method to drop-off coral and algae
     */
}
