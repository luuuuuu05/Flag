using System.Collections.Generic;
using UnityEngine;

public class FlagSpawner : MonoBehaviour
{
    // 单例实例
    public static FlagSpawner Instance { get; private set; }

    public GameObject whiteFlagPrefab;
    public GameObject redFlagPrefab;
    public GameObject yellowFlagPrefab;

    public Transform[] spawnPoints;

    private List<Transform> usedPoints = new List<Transform>();

    private void Awake()
    {
        // 单例赋值，防止多实例
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

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
        List<Transform>
            available =
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

    // 新增：被收集时调用的方法
    public void FlagCollected()
    {
        // 这里根据你的业务逻辑编写后续逻辑
        // 示例：清空占用点位、重新生成旗帜等，按需扩展
        usedPoints.Clear();
        SpawnFlags();
    }
}