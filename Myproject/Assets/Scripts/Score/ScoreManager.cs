using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int Score;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        HUDController.Instance.UpdateScore(0);
    }

    public void ResetScore()
    {
        Score = 0;
        HUDController.Instance.UpdateScore(0);
    }

    public void AddScore(int value)
    {
        Score += value;

        HUDController.Instance.UpdateScore(Score);

        Debug.Log("当前分数：" + Score);
    }
}
