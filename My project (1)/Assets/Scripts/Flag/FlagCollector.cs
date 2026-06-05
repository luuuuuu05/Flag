using UnityEngine;

public class FlagCollector : MonoBehaviour
{
    public float collectDistance = 1.0f;

    [SerializeField] private MonoBehaviour playerInputSource;
    private IPlayerInput playerInput;

    private void Awake()
    {
        if (playerInputSource != null)
            playerInput = playerInputSource as IPlayerInput;
    }

    void Update()
    {
        bool triggerPressed = playerInput != null
            ? playerInput.CollectTriggered
            : Input.GetKeyDown(KeyCode.J);

        if (triggerPressed)
            TryCollect();
    }

    void TryCollect()
    {
        if (GameManager.Instance != null
            && GameManager.Instance.CurrentState != GameState.Playing)
            return;

        Flag[] flags = FindObjectsOfType<Flag>();

        foreach (var flag in flags)
        {
            float distance =
                Vector3.Distance(
                    transform.position,
                    flag.transform.position);

            if (distance < collectDistance)
            {
                ICollectable collectable = flag;

                FlagType flagType = flag.GetComponent<FlagType>();
                int scoreValue = flagType != null
                    ? flagType.GetScore()
                    : collectable.ScoreValue;

                ScoreManager.Instance.AddScore(scoreValue);

                collectable.OnCollected();
                Destroy(collectable.GameObject);

                FlagSpawner.Instance.FlagCollected();

                break;
            }
        }
    }
}
