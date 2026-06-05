using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public event Action OnTimeUp;

    private float remainingTime;
    private bool isRunning;

    public float RemainingTime => remainingTime;

    private void Update()
    {
        if (!isRunning)
            return;

        remainingTime -= Time.deltaTime;
        HUDController.Instance.UpdateTimer(remainingTime);

        if (remainingTime <= 0f)
        {
            remainingTime = 0f;
            isRunning = false;
            OnTimeUp?.Invoke();
        }
    }

    public void StartTimer(float duration)
    {
        remainingTime = duration;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }
}
