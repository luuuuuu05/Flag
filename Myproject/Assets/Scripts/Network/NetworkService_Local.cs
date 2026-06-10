using System;
using UnityEngine;

public class NetworkService_Local : MonoBehaviour, INetworkService
{
    public bool IsConnected => true;

    public event Action OnConnected;
    public event Action OnDisconnected;
    public event Action<string, int> OnScoreReceived;
    public event Action<string> OnPlayerJoined;
    public event Action<GameState> OnGameStateReceived;

    public void Connect(string serverUrl)
    {
        Debug.Log($"[Network] Connect (local stub): {serverUrl}");
        OnConnected?.Invoke();
    }

    public void Disconnect()
    {
        Debug.Log("[Network] Disconnect (local stub)");
        OnDisconnected?.Invoke();
    }

    public void SendScore(string playerId, int score)
    {
        Debug.Log($"[Network] SendScore (local stub): {playerId} = {score}");
    }

    public void SendGameState(GameState state, int score, float remainingTime)
    {
        Debug.Log($"[Network] SendGameState (local stub): {state}, score={score}, time={remainingTime:F1}");
    }

    public void SendPlayerJoined(string playerId)
    {
        Debug.Log($"[Network] SendPlayerJoined (local stub): {playerId}");
    }
}
