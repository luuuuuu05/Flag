using UnityEngine;

public class BodyDamageReceiver : MonoBehaviour
{
    private PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = GetComponentInParent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
            playerHealth?.OnEnterWall();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wall"))
            playerHealth?.OnExitWall();
    }
}
