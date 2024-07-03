using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T _prefab;
    private Queue<T> _pool;
    private List<T> _activeObjects;

    public IEnumerable<T> PoolObjects => _pool;
    public IEnumerable<T> ActiveObjects => _activeObjects;

    protected void Awake()
    {
        _pool = new Queue<T>();
        _activeObjects = new List<T>();
    }

    public T GetObject()
    {
        if (_pool.Count == 0)
        {
            T newObject = Instantiate(_prefab);
            newObject.gameObject.SetActive(false);
            _pool.Enqueue(newObject);
        }

        T obj = _pool.Dequeue();
        _activeObjects.Add(obj);
        obj.gameObject.SetActive(true);
        return obj;
    }

    public void PutObject(T newObject)
    {
        newObject.gameObject.SetActive(false);
        _activeObjects.Remove(newObject);
        _pool.Enqueue(newObject);
    }

    public virtual void Restart()
    {
        foreach (var item in _activeObjects)
        {
            item.gameObject.SetActive(false);
            _pool.Enqueue(item);
        }

        _activeObjects.Clear();
    }
}