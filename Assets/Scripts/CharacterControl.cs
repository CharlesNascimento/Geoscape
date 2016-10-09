using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Character))]
public class CharacterControl : MonoBehaviour {

    public static CharacterControl instance;

    private Character m_Character;
    private bool m_Jump;
    private bool isMovementBlocked = false;

    private void Awake()
    {
        instance = this;
        m_Character = GetComponent<Character>();
    }

    private void Update()
    {
        if (!m_Jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }
    }

    private void FixedUpdate()
    {
        if(isMovementBlocked) return;
        // Read the inputs.
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        // Pass all parameters to the character control script.
        m_Character.Move(h, crouch, m_Jump);
        m_Jump = false;
    }

    public void SetMovementBlocked(bool isBlocked) {
        isMovementBlocked = isBlocked;
    }
}
