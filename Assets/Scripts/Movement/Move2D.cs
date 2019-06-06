using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Move2D : MonoBehaviour
{
    #region Fields

    /// <summary>
    /// The fastest the player can travel in the x axis.
    /// </summary>
    [SerializeField]
    private float m_MaxSpeed = 10f;

    /// <summary>
    /// Whether or not a player can steer while jumping.
    /// </summary>
    [SerializeField]
    private bool m_AirControl = false;

    /// <summary>
    /// A mask determining what is ground to the character.
    /// </summary>
    [SerializeField]
    private LayerMask m_WhatIsGround;

    private new Rigidbody2D rigidbody2D;

    #endregion

    #region Properties

    public bool IsGrounded { get; set; }

    #endregion

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contactPoint in collision.contacts)
        {
            Vector2 hitPoint = contactPoint.point;
            IsGrounded = hitPoint.y > collision.transform.up.y;
            //Debug.Log("isGrounded?" + IsGrounded);
        }
    }

    public void Move(float move)
    {
        if (IsGrounded || m_AirControl)
        {
            rigidbody2D.AddForce(new Vector2(move * m_MaxSpeed, 0));
        }
    }
}
