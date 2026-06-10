using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    public static HUDController Instance;

    public TMP_Text scoreText;
    public TMP_Text timerText;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateScore(int score)
    {
        scoreText.text = $"Score : {score}";
    }

    public void UpdateTimer(float seconds)
    {
        if (timerText == null)
            return;

        int mins = Mathf.FloorToInt(seconds / 60f);
        int secs = Mathf.FloorToInt(seconds % 60f);
        timerText.text = $"Time : {mins:00}:{secs:00}";
    }
}
