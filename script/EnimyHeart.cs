using UnityEngine;

public enum EnemyMovementType
{
    PatrolZigZag,   // Bamboleo suave horizontal
    CircleOrbit     // Vuelo en giros circulares
}

public class EnimyHeart : MonoBehaviour
{
    [Header("Salud")]
    [SerializeField] private float _healt = 40f;

    [Header("Ajustes Generales de Vuelo")]
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float stopYPosition = 3.0f;

    [Header("Tipo de Movimiento")]
    [SerializeField] private EnemyMovementType movementType;

    // Variables internas de control
    private float startX;
    private float startY;
    private float randomTimeOffset;
    private float individualSpeed;
    private bool reachedPosition = false;

    // Límites de pantalla
    private float minScreenX;
    private float maxScreenX;
    private float minScreenY;

     private EnemiesShoot shoot;
    private float shootTimer;
    private float shootInterval;

    void Start()
    {
        startX = transform.position.x;
        startY = stopYPosition;

        randomTimeOffset = Random.Range(0f, 100f);
        individualSpeed = speed + Random.Range(-0.4f, 0.4f);

        movementType = (EnemyMovementType)Random.Range(0, System.Enum.GetValues(typeof(EnemyMovementType)).Length);

        float camDistance = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, camDistance));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, camDistance));

        float margin = 0.5f;
        minScreenX = bottomLeft.x + margin;
        maxScreenX = topRight.x - margin;
        minScreenY = bottomLeft.y - 1f;
       shoot = GetComponent<EnemiesShoot>();
       shootInterval = Random.Range(0.5f, 1f);
    }

    void Update()
    {
        float customTime = Time.time + randomTimeOffset;

        // FASE 1: Todos entran bajando hasta su posición inicial en Y
        if (!reachedPosition)
        {
            transform.position += Vector3.down * individualSpeed * Time.deltaTime;

            if (transform.position.y <= stopYPosition)
            {
                reachedPosition = true;
                startY = transform.position.y;
            }
            return;
        }

        // FASE 2: Movimiento continuo, sin pausas
        switch (movementType)
        {
            case EnemyMovementType.PatrolZigZag:
                ExecuteZigZag(customTime);
                break;

            case EnemyMovementType.CircleOrbit:
                ExecuteCircle(customTime);
                break;
        }

        if (shoot != null)
{
    shootTimer += Time.deltaTime;
    if (shootTimer >= shootInterval)
    {
        shoot.Shoot();
        shootTimer = 0f;
        shootInterval = Random.Range( 0.5f, 1f);
    }
}

        // Límite en X (por si acaso)
        float clampedX = Mathf.Clamp(transform.position.x, minScreenX, maxScreenX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        // Red de seguridad: si por algún motivo se escapa por abajo, se destruye
        if (transform.position.y < minScreenY)
        {
            Destroy(gameObject);
        }
    }

    private void ExecuteZigZag(float time)
    {
        float horizontalOffset = Mathf.Sin(time * 2.0f) * 2.2f;
        float verticalOffset = Mathf.Cos(time * 3.0f) * 0.3f;
        transform.position = new Vector3(startX + horizontalOffset, startY + verticalOffset, transform.position.z);
    }

    private void ExecuteCircle(float time)
    {
        float x = startX + Mathf.Cos(time * 2.0f) * 1.5f;
        float y = startY + Mathf.Sin(time * 2.0f) * 0.8f;
        transform.position = new Vector3(x, y, transform.position.z);
    }

    public void TakeDamage(float damage)
    {
        _healt -= damage;
        Debug.Log("Enimy Heart= " + _healt);

        if (_healt <= 0f)
        {
            Debug.Log("Enimy is death");
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}