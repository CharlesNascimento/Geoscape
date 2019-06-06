using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D");
        if (collision.collider.transform.CompareTag("Player"))
        {
            Debug.Log("Was with player");
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("OnCollisionExit2D");

        if (collision.collider.transform.CompareTag("Player"))
        {
            Debug.Log("Was with player");
            collision.collider.transform.SetParent(null);
        }
    }
}
