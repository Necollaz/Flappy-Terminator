using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    public Vector2 Direction { get; set; }

    private void Update()
    {
        transform.Translate(Direction * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            player.ProcessCollision();
            player.gameObject.SetActive(false);
        }

        gameObject.SetActive(false);
    }
}
