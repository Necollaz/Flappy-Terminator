using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover), typeof(PlayerCollisionHandler), typeof(ScoreCounter))]
public class Player : MonoBehaviour
{
    private PlayerMover _mover;
    private ScoreCounter _scoreCounter;
    private PlayerCollisionHandler _handler;

    public event Action GameOver;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _handler = GetComponent<PlayerCollisionHandler>();
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
    }

    public void Reset()
    {
        _mover.Reset();
        //_scoreCounter.Reset();
    }
}
