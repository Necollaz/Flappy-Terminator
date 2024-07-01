using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    public Vector2 Direction { get; set; }
    public float Speed { get => _speed; set => _speed = value; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.isKinematic = true;
    }

    private void FixedUpdate()
    {
        Move();
    }

    protected virtual void Move()
    {
        transform.Translate(Direction * _speed * Time.deltaTime);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out RemoverBullets _))
        {
            gameObject.SetActive(false);
        }
        else
        {
            HandleSpecificCollision(collision);
        }
    }

    protected abstract void HandleSpecificCollision(Collider2D collision);
}
