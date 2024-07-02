using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T _prefab;
    private Queue<T> _pool;

    public IEnumerable<T> PoolObjects => _pool;

    protected void Awake()
    {
        _pool = new Queue<T>();
    }

    public T GetObject()
    {
        if (_pool.Count == 0)
        {
            T newObject = Instantiate(_prefab);
            newObject.gameObject.SetActive(false);
            _pool.Enqueue(newObject);
        }

        return _pool.Dequeue();
    }

    public void PutObject(T newObject)
    {
        newObject.gameObject.SetActive(false);
        _pool.Enqueue(newObject);
    }

    public virtual void Reset()
    {
        foreach (var item in _pool)
            item.gameObject.SetActive(false);
    }
}