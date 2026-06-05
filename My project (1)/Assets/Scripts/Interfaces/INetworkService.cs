using System;

public interface INetworkService
{
    bool IsConnected { get; }

    void Connect(string serverUrl);
    void Disconnect();

    void SendScore(string playerId, int score);
    void SendGameState(GameState state, int score, float remainingTime);
    void SendPlayerJoined(string playerId);

    event Action OnConnected;
    event Action OnDisconnected;
    event Action<string, int> OnScoreReceived;
    event Action<string> OnPlayerJoined;
    event Action<GameState> OnGameStateReceived;
}
