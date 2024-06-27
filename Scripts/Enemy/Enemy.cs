using UnityEngine;

[RequireComponent(typeof(EnemyAttack))]
public class Enemy : MonoBehaviour
{
    private EnemyAttack _attack;

    private void Awake()
    {
        _attack = GetComponent<EnemyAttack>();
    }

    public void Restart()
    {
        _attack.Restart();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerBullet _) || collision.TryGetComponent(out Player _))
        {
            Restart();
            gameObject.SetActive(false);
        }
    }
}
