using UnityEngine;

[RequireComponent(typeof(Collider))]
public class WallDamage : MonoBehaviour
{
    void Reset()
    {
        // 自动挂 Collider
        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            col.isTrigger = true;  // 设置 Trigger
        }

        // 自动设置 Tag
        gameObject.tag = "Wall";
    }
}