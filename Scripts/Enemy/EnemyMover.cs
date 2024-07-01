using System.Collections;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Coroutine _coroutine;

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
            transform.Translate(Vector3.left * _speed * Time.deltaTime);

            yield return null;
        }
    }
}
