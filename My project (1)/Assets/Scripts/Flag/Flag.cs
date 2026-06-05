using UnityEngine;

public class Flag : MonoBehaviour, ICollectable
{
    public int score = 30;

    public int ScoreValue => score;

    public GameObject GameObject => gameObject;

    public void OnCollected() { }
}
