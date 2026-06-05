using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagSpawner : MonoBehaviour
{
    public static FlagSpawner Instance;

    public GameObject goldFlagPrefab;

    public GameObject[] flagPrefabs;

    public Transform[] spawnPoints;

    private readonly List<GameObject> activeFlags =
        new();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnFlag();
    }

    public void SpawnFlag()
    {
        int index =
            Random.Range(0, spawnPoints.Length);

        Transform point =
            spawnPoints[index];

        GameObject prefab =
            flagPrefabs.Length > 0
                ? flagPrefabs[Random.Range(0, flagPrefabs.Length)]
                : goldFlagPrefab;

        GameObject flag =
            Instantiate(
                prefab,
                point.position,
                Quaternion.identity);

        activeFlags.Add(flag);
    }

    public void FlagCollected()
    {
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2f);

        SpawnFlag();
    }
}
