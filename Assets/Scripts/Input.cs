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
    private KeyCode interact = KeyCode.J; 

    private bool isUpPressed = false;
    private bool isDownPressed = false;
    private bool isLeftPressed = false;
    private bool isRightPressed = false;
    private bool isPickUpPressed = false;
    private bool isInteractPressed = false;

    private void Update()
    {
        // TODO: make pick up & interact only work once when pressed (run onces per press and releaes)

        isUpPressed = UnityEngine.Input.GetKey(up);
        isDownPressed = UnityEngine.Input.GetKey(down);
        isLeftPressed = UnityEngine.Input.GetKey(left);
        isRightPressed = UnityEngine.Input.GetKey(right);
        isPickUpPressed = UnityEngine.Input.GetKey(pickUp);
        isInteractPressed = UnityEngine.Input.GetKey(interact);

        if (isPickUpPressed)
        {
            robotAction.DetectGamePiece();

            if (debug)
                Debug.Log("Detecting game pieces"); 
        }

        if (isInteractPressed) {
            robotAction.DetectFieldObject();
        }
    }

    // Update physics according to input
    private void FixedUpdate()
    {
        robotMovement.Move(isUpPressed, isDownPressed, isLeftPressed, isRightPressed);   
    }
}
