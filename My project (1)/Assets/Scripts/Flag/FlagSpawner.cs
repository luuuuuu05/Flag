using System.Collections.Generic;
using UnityEngine;

public class FlagSpawner : MonoBehaviour
{
    public GameObject whiteFlagPrefab;
    public GameObject redFlagPrefab;
    public GameObject yellowFlagPrefab;

    public Transform[] spawnPoints;

    private List<Transform> usedPoints = new List<Transform>();

    void Start()
    {
        SpawnFlags();
    }

    void SpawnFlags()
    {
        usedPoints.Clear();

        SpawnMultiple(whiteFlagPrefab, 3);

        SpawnMultiple(redFlagPrefab, 2);

        SpawnMultiple(yellowFlagPrefab, 1);
    }

    void SpawnMultiple(GameObject prefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Transform point = GetRandomPoint();

            Instantiate(
                prefab,
                point.position,
                Quaternion.identity
            );
        }
    }

    Transform GetRandomPoint()
    {
        List<Transform> available =
            new List<Transform>();

        foreach (Transform point in spawnPoints)
        {
            if (!usedPoints.Contains(point))
            {
                available.Add(point);
            }
        }

        int index =
            Random.Range(0, available.Count);

        Transform selected =
            available[index];

        usedPoints.Add(selected);

        return selected;
    }
}