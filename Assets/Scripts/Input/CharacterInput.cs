using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Move2D), typeof(Jump2D))]
public class CharacterInput : MonoBehaviour
{
    private Move2D move2D;
    private Jump2D jump2D;

    private bool shouldJump;
    private bool isMovementBlocked = false;

    private void Awake()
    {
        move2D = GetComponent<Move2D>();
        jump2D = GetComponent<Jump2D>();
    }

    private void Update()
    {
        if (!shouldJump)
        {
            shouldJump = CrossPlatformInputManager.GetButtonDown("Jump");
        }
    }

    private void FixedUpdate()
    {
        if (isMovementBlocked)
        {
            return;
        }

        float horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");

        move2D.Move(horizontalInput);

        if (shouldJump)
        {
            jump2D.Jump();
            shouldJump = false;
        }
    }

    public void SetMovementBlocked(bool isBlocked)
    {
        isMovementBlocked = isBlocked;
    }
}
