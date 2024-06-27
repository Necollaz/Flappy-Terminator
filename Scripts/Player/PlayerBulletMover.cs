using System.Collections;
using UnityEngine;

[RequireComponent(typeof (PlayerBullet))]
public class PlayerBulletMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private PlayerBullet _bullet;
    private Coroutine _coroutine;

    private void Awake()
    {
        _bullet = GetComponent<PlayerBullet>();
    }

    private void OnEnable()
    {
        _coroutine = StartCoroutine(Move());
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator Move()
    {
        while (enabled)
        {
            transform.Translate(_bullet.Direction * _speed * Time.deltaTime);
            yield return null;
        }
    }
}
