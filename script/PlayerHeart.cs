//Danny Ramirez
//ramdanny@gmail.com
// con este escrip manejamos la vida del jugador , su tres vidas, su renacimiento . tiempo d einvulnerabilidad,



using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHeart : MonoBehaviour
{
    [Header("Vidas y Salud / HP")]
    [SerializeField] private int lives = 3;
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    [Header("Reaparición")]
    [SerializeField] private Transform playerRoot;
    [SerializeField] private float invulnerabilityTime = 1f;

    [Header("UI de Vidas")] 
    [SerializeField] private LifeUI lifeUI;

    private bool isInvulnerable = false;

    private void Awake()
    {
        if (playerRoot == null)
        {
            playerRoot = transform.root;
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
        
        // <-- NUEVO: Inicializar los iconos al empezar la escena
        if (lifeUI != null)
        {
            lifeUI.ActualizarVidas(lives);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isInvulnerable) return;

        if (collision.gameObject.CompareTag("Enemies"))
        {
            EnimyHeart enemy = collision.gameObject.GetComponent<EnimyHeart>();
            if (enemy != null)
            {
                enemy.TakeDamage(999f);
            }
            TakeHit(25);
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
            LoseLife();
        }
        else
        {
            StartCoroutine(InvulnerabilityRoutine());
        }
    }

      public void LoseLife()
{
    lives--;
    Debug.Log("Vidas restantes: " + lives);
    
    if (lifeUI != null)
    {
        lifeUI.ActualizarVidas(lives);
    }

    if (lives <= 0)
    {
        Debug.Log("GAME OVER - Deteniendo enemigos...");
        
    
        EnemySpawner spawner = FindObjectOfType<EnemySpawner>();
        if (spawner != null)
        {
            spawner.enabled = false;
        }
        
        if (GameManager.Instance != null)
        {
            GameManager.Instance.GameOver();
        }
        else
        {
            SceneManager.LoadScene("Gameover");
        }
    }
    else
    {
        Respawn();
    }
}

    private void Respawn()
    {
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
        Time.timeScale = 0f;
    }
}