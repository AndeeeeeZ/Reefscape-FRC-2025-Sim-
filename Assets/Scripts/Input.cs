using UnityEngine;

public class Input : MonoBehaviour
{
    [SerializeField]
    private bool debug; 

    [SerializeField]
    private RobotMovement robotMovement;

    [SerializeField]
    private RobotAction robotAction; 

    private KeyCode up = KeyCode.W;
    private KeyCode down = KeyCode.S;
    private KeyCode left = KeyCode.A;
    private KeyCode right = KeyCode.D;
    private KeyCode pickUp = KeyCode.Space; 

    private bool isUpPressed = false;
    private bool isDownPressed = false;
    private bool isLeftPressed = false;
    private bool isRightPressed = false;
    private bool isPickUpPressed = false;

    private void Update()
    {
        isUpPressed = UnityEngine.Input.GetKey(up);
        isDownPressed = UnityEngine.Input.GetKey(down);
        isLeftPressed = UnityEngine.Input.GetKey(left);
        isRightPressed = UnityEngine.Input.GetKey(right);
        isPickUpPressed = UnityEngine.Input.GetKey(pickUp);

        if (isPickUpPressed)
        {
            robotAction.DetectGamePiece();

            if (debug)
                Debug.Log("Detecting game pieces"); 
        }
    }

    // Update physics according to input
    private void FixedUpdate()
    {
        robotMovement.Move(isUpPressed, isDownPressed, isLeftPressed, isRightPressed);   
    }
}
