// creado por danny ramirez, aqui definimos la vida del jugador

using UnityEngine;
using System.Collections;

public class PlayerHeart : MonoBehaviour
{
    [Header("Vidas y Salud / HP")]
    [SerializeField] private int lives = 3;
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    [Header("Reaparición")]
    [SerializeField] private Transform playerRoot;      // Arrastrar el GameObject "Player" (padre)
    [SerializeField] private float invulnerabilityTime = 1f; // Tiempo de inmunidad tras recibir un golpe

    private bool isInvulnerable = false;

    private void Awake()
    {
        // Si no asignaste el playerRoot en el inspector, toma el transform raíz
        if (playerRoot == null)
        {
            playerRoot = transform.root;
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isInvulnerable) return;

        if (collision.gameObject.CompareTag("Enemies"))
        {
            EnimyHeart enemy = collision.gameObject.GetComponent<EnimyHeart>();
            if (enemy != null)
            {
                enemy.TakeDamage(999f); // El enemigo también muere en el choque directo
            }

            TakeHit(25); // Daño directo por chocar contra la nave enemiga
        }
    }

    public void TakeHit(int damage)
    {
        if (isInvulnerable) return;

        currentHealth -= damage;
        Debug.Log("Salud restante: " + currentHealth + " / " + maxHealth + " | Vidas: " + lives);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            LoseLife(); // En lugar de ir directo a GameOver, pierde una vida
        }
        else
        {
            // Opcional: invulnerabilidad breve tras recibir un disparo para no recibir ráfagas seguidas
            StartCoroutine(InvulnerabilityRoutine());
        }
    }

    private void LoseLife()
    {
        lives--;
        Debug.Log("Vidas restantes: " + lives);

        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        // Se mantiene en la posición actual donde murió y solo restaura la salud
        currentHealth = maxHealth; 
        StartCoroutine(InvulnerabilityRoutine());
    }

    private IEnumerator InvulnerabilityRoutine()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(invulnerabilityTime);
        isInvulnerable = false;
    }

    private void GameOver()
    {
        Debug.Log("GAME OVER");
        Time.timeScale = 0f; // Pausa el juego
    }
}