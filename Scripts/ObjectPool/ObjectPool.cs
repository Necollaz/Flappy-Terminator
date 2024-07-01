using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T _prefab;
    private Queue<T> _pool;

    public IEnumerable<T> PoolObjects { get; private set; }

    protected void Awake()
    {
        _pool = new Queue<T>();
        PoolObjects = _pool;
    }

    public T GetObject()
    {
        if (_pool.Count == 0)
        {
            T newObject = Instantiate(_prefab);
            PutObject(newObject);
        }

        T obj = _pool.Dequeue();
        obj.gameObject.SetActive(true);
        return obj;
    }

    public void PutObject(T newObject)
    {
        newObject.gameObject.SetActive(false);
        _pool.Enqueue(newObject);
    }

    protected void Reset()
    {
        foreach (var obj in _pool)
        {
            Destroy(obj.gameObject);
        }

        _pool.Clear();
    }
}