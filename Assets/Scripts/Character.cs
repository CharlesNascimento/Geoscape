using UnityEngine;

public class Character : MonoBehaviour {

    [SerializeField]
    private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.

    [SerializeField]
    private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.

    [SerializeField]
    private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;

    [SerializeField]
    private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

    private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
    const float k_GroundedRadius = 0.35f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.
    private Transform m_CeilingCheck;   // A position marking where to check for ceilings
    const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
    private Animator m_Anim;            // Reference to the player's animator component.
    private Rigidbody2D m_Rigidbody2D;

    private void Awake()
    {
        // Setting up references.
        m_GroundCheck = transform.Find("GroundCheck");
        m_CeilingCheck = transform.Find("CeilingCheck");
        //m_Anim = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {   
        //m_Anim.SetBool("Ground", m_Grounded);

        // Set the vertical animation
        //m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("OnCollisionEnter2D");
        //if (coll.transform.tag == "Missile")
        {
            foreach (ContactPoint2D missileHit in coll.contacts)
            {
                Vector2 hitPoint = missileHit.point;

                Debug.Log("Contato: " + hitPoint.y + " - Chão: " + coll.transform.position.y);

                if (hitPoint.y > coll.transform.position.y)
                    m_Grounded = true;
                else
                {
                    m_Grounded = false;
                }

                Debug.Log(hitPoint);
            }
        }
    }

    public void Move(float move, bool crouch, bool jump)
    {
        //only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl)
        {
            // The Speed animator parameter is set to the absolute value of the horizontal input.
            //m_Anim.SetFloat("Speed", Mathf.Abs(move));

            // Move the character
            m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);
        }

        //Debug.Log("Jump?");
        // If the player should jump...
        if (m_Grounded && jump/* && m_Anim.GetBool("Ground")*/)
        {
            Debug.Log("Jump!!!");
            // Add a vertical force to the player.
            m_Grounded = false;
            //m_Anim.SetBool("Ground", false);
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }
    }
}
