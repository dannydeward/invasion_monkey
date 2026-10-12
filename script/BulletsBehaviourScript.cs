//Danny Ramirez
//ramdannygmnail.com
// este script controla la bala del jugador, el daño que causa, su velocidad, la autodestrucicon y y las explosiones al colicionar con el enemigo o con balas enemigas


using UnityEngine;

public class BulletsBehaviourScript : MonoBehaviour
{
    [SerializeField] float _BulletSpeed = 10f;
    [SerializeField] float damage = 10f;
    [SerializeField] float capitanDamage = 5f; 
    [SerializeField] GameObject explosionPrefab;

    void Start()
    {
        Destroy(gameObject, 2f); 
    }

    void Update()
    {
        transform.Translate(new Vector3(0f, 1f, 0f) * Time.deltaTime * _BulletSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si choca con una bala enemiga, explotar ambas
        if (collision.gameObject.CompareTag("BulletEnemy"))
        {
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }
            Destroy(collision.gameObject); // Destruir la bala enemiga
            Destroy(gameObject); // Destruir esta bala
            return;
        }

        // Si NO es un enemigo ni una bala enemiga, ignorar
        if (!collision.gameObject.CompareTag("Enemies"))
        {
            return; 
        }

        // Si tocó un enemigo
        Debug.Log("Bullet hit an Enemy!");
        
        EnimyHeart EnimyHeart = collision.gameObject.GetComponent<EnimyHeart>();
        if (EnimyHeart != null)
        {
            EnimyHeart.TakeDamage(damage);
        }
        else
        {
            EnimyHeart enemyHeart = collision.gameObject.GetComponent<EnimyHeart>();
            if (EnimyHeart != null)
            {
                EnimyHeart.TakeDamage(capitanDamage);
            }
        }

        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}