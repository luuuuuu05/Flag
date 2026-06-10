using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private CanvasGroup damageOverlay;
    [SerializeField] private float damagePerSecond = 66.7f;
    [SerializeField] private float healPerSecond = 200f;

    private float currentHealth;
    private int wallContactCount;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (wallContactCount > 0)
        {
            currentHealth -= damagePerSecond * Time.deltaTime;
            if (currentHealth <= 0f)
            {
                currentHealth = 0f;
                Die();
            }
        }
        else if (currentHealth < maxHealth)
        {
            currentHealth += healPerSecond * Time.deltaTime;
            if (currentHealth > maxHealth)
                currentHealth = maxHealth;
        }

        if (damageOverlay != null)
            damageOverlay.alpha = Mathf.Clamp01(1f - currentHealth / maxHealth);
    }

    public void OnEnterWall()
    {
        wallContactCount++;
    }

    public void OnExitWall()
    {
        if (wallContactCount > 0)
            wallContactCount--;
    }

    private void Die()
    {
        GameManager.Instance?.EndGame();
    }
}
