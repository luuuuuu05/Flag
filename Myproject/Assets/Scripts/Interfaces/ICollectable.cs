using UnityEngine;

public interface ICollectable
{
    int ScoreValue { get; }
    GameObject GameObject { get; }
    void OnCollected();
}
