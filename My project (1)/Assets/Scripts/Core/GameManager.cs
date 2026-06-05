using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameTimer gameTimer;
    [SerializeField] private ResultPanel resultPanel;
    [SerializeField] private float gameDuration = 60f;

    public GameState CurrentState { get; private set; } = GameState.Waiting;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameTimer.OnTimeUp += EndGame;
        StartGame();
    }

    public void StartGame()
    {
        CurrentState = GameState.Playing;
        ScoreManager.Instance.ResetScore();
        gameTimer.StartTimer(gameDuration);
        resultPanel.Hide();
    }

    public void EndGame()
    {
        CurrentState = GameState.GameOver;
        resultPanel.Show(ScoreManager.Instance.Score);
    }
}
