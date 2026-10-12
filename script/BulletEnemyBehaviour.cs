//Danny Ramirez 
//ramdanny@gmail.com
// este scrip tiene como funcion dirigir las balas del enemigo, tiene la velocidad, el daño y y las explosiones al colicionar con balas del jugador y con el jugador, ademas la autodestruye una vez que pasa de largo 



using UnityEngine;

public class BulletEnemyBehaviour : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float damage = 10f;
    [SerializeField] GameObject explosionPrefab;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }
            Destroy(collision.gameObject); // Destruir la bala del jugador
            Destroy(gameObject); // Destruir esta bala enemiga
            return;
        }

      
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }

      
        PlayerHeart playerHeart = collision.gameObject.GetComponent<PlayerHeart>();
        if (playerHeart != null)
        {
            playerHeart.TakeHit((int)damage);
        }

        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}