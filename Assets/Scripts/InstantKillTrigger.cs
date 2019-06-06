using UnityEngine;

public class InstantKillTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Messenger.Broadcast("game_over");
        }
    }
}
