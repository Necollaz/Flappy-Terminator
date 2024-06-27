using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected Transform Container;

    private List<T> _pool;

    protected IEnumerable<T> Pool => _pool;

    protected void Awake()
    {
        _pool = new List<T>();
    }

    public virtual void Restart()
    {
        foreach (var item in _pool)
            item.gameObject.SetActive(false);
    }

    protected T GetObject(T prefab)
    {
        T result = _pool.FirstOrDefault(item => !item.gameObject.activeSelf);

        if(result == null)
        {
            result = Instantiate(prefab, Container);
            result.gameObject.SetActive(false);
            _pool.Add(result);
        }

        return result;
    }

    protected T GetObject(List<T> prefab)
    {
        T result = _pool.FirstOrDefault(item => !item.gameObject.activeSelf);

        if(result == null)
        {
            int index = Random.Range(0, prefab.Count);
            result = Instantiate(prefab[index], Container);
            result.gameObject.SetActive(false);
            _pool.Add(result);
        }

        return result;
    }
}
