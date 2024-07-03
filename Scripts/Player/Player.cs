using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover), typeof(PlayerCollisionHandler), typeof(Score))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private ScoreView _scoreView;
    private PlayerMover _mover;
    private Score _score;
    private PlayerCollisionHandler _handler;
    private Rigidbody2D _rigidbody;

    public event Action GameOver;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _score = GetComponent<Score>();
        _handler = GetComponent<PlayerCollisionHandler>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    public void ProcessCollision()
    {
        GameOver?.Invoke();
        gameObject.SetActive(false);
    }

    public void Restart()
    {
        _mover.Restart();
        _score.Restart();
        gameObject.SetActive(true);
    }
}
