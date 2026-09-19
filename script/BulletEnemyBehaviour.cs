using UnityEngine;

public class BulletEnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 3f;
    [SerializeField] private int _damage = 3; // Variable de daño que verás en el Inspector

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.Translate(Vector3.down * _bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHeart playerHeart = collision.gameObject.GetComponent<PlayerHeart>();
            if (playerHeart != null)
            {
                playerHeart.TakeHit(_damage); // Enviamos el daño exacto de esta bala
            }
            Destroy(gameObject);
        }
    }
}