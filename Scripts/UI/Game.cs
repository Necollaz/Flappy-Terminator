using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private StartScreen _startGameScreen;
    [SerializeField] private EndGameScreen _endGameScreen;

    private void OnEnable()
    {
        _startGameScreen.PlayButtonClicked += Play;
        _endGameScreen.RestartButtonClicked += Restart;
        _player.GameOver += GameOver;
    }

    private void OnDisable()
    {
        _startGameScreen.PlayButtonClicked -= Play;
        _endGameScreen.RestartButtonClicked -= Restart;
        _player.GameOver -= GameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startGameScreen.Open();
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        _endGameScreen.Open();
    }

    private void Restart()
    {
        _endGameScreen.Close();
        StartGame();
    }

    private void Play()
    {
        _startGameScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _player.Reset();
        _enemySpawner.Reset();
    }
}
