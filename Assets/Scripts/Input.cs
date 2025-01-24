using UnityEngine;

public class Input : MonoBehaviour
{
    [SerializeField]
    private RobotMovement robot;

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
        isPickUpPressed |= UnityEngine.Input.GetKey(pickUp);
    }

    private void FixedUpdate()
    {
        robot.Move(isUpPressed, isDownPressed, isLeftPressed, isRightPressed);
    }
}
