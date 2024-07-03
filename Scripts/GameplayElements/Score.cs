using System;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private PlayerAttack _attack;

    private int _score;

    public event Action<int> Changed;

    private void OnEnable()
    {
        _attack.EnemyDead += Add;
    }

    private void OnDisable()
    {
        _attack.EnemyDead -= Add;
    }

    public void Add()
    {
        _score++;
        Changed?.Invoke(_score);
    }

    public void Restart()
    {
        _score = 0;
        Changed?.Invoke(_score);
    }
}
