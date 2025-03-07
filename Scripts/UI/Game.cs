using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private EndGameScreen _endGameScreen;
    [SerializeField] private StartScreen _startGameScreen;
    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private ObjectPoolBullet _bulletPool;
    [SerializeField] private ObjectPoolEnemy _enemyPool;

    private void OnEnable()
    {
        _startGameScreen.PlayButtonClicked += OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClick;
        _player.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startGameScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClick;
        _player.GameOver -= OnGameOver;
    }

    private void Start()
    {
        _endGameScreen.Close();
        Time.timeScale = 0;
        _startGameScreen.Open();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _endGameScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        _endGameScreen.Close();
        StartGame();
    }

    private void OnPlayButtonClick()
    {
        _startGameScreen.Close();
        _endGameScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _player.Restart();
        _enemySpawner.Restart();
        _playerAttack.Restart();
        _bulletPool.Restart();
        _enemyPool.Restart();
    }
}