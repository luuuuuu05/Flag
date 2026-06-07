using UnityEngine;

[RequireComponent(typeof(Collider))]
public class WallDamage : MonoBehaviour
{
    private void Awake()
    {
        Collider col = GetComponent<Collider>();
        col.isTrigger = true;
        gameObject.tag = "Wall";
    }
}
