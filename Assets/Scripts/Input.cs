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
    private KeyCode interact = KeyCode.Return; 

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

        PickUpUpdate();
        InteractUpdate();
    }

    private void PickUpUpdate()
    {
        if(UnityEngine.Input.GetKeyDown(pickUp) && !isPickUpPressed)
        {
            isPickUpPressed = true;
            robotAction.DetectGamePiece();

            if (debug)
                Debug.Log("Detecting for game pieces");
        }
        else if (UnityEngine.Input.GetKeyUp(pickUp))
        {
            isPickUpPressed = false;
        }
    }

    private void InteractUpdate()
    {
        if (UnityEngine.Input.GetKeyDown(interact) && !isInteractPressed)
        {
            isInteractPressed = true;
            robotAction.DetectFieldObject();

            if (debug)
                Debug.Log("Detecting for field objects");
        }
        else if (UnityEngine.Input.GetKeyUp(interact))
        {
            isInteractPressed = false;
        }
    }

    // Update physics according to input
    private void FixedUpdate()
    {
        robotMovement.Move(isUpPressed, isDownPressed, isLeftPressed, isRightPressed);   
    }
}
