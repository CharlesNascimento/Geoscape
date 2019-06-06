using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class VelocityRestrictor : MonoBehaviour
{
    [SerializeField]
    private float maxVelocity = 10f;

    private new Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = Vector3.ClampMagnitude(rigidbody2D.velocity, maxVelocity);
    }
}
