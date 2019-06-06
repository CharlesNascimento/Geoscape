using UnityEngine;

[RequireComponent(typeof(Move2D))]
public class Jump2D : MonoBehaviour
{
    /// <summary>
    /// Amount of force added when the player jumps.
    /// </summary>
    [SerializeField]
    private float jumpForce = 400f;

    private Move2D move2D;

    private new Rigidbody2D rigidbody2D;

    private void Start()
    {
        move2D = GetComponent<Move2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (move2D.IsGrounded)
        {
            move2D.IsGrounded = false;
            rigidbody2D.AddForce(new Vector2(0f, jumpForce));
        }
    }
}
