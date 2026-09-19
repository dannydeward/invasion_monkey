/*

* Author: Marcos Cabana
* Email: marcos.cabana@gmail.com


_________________________________________________________________
* Date: Tue Apr 07 2026
            
*/
using UnityEngine;

public class EnemyBehaviourTest : MonoBehaviour
{
    private float speed;
    private bool movingLeft;
    private Camera cam;
    private EnemiesShoot shoot;
    private float shootTimer;
    private float shootInterval = 1f;

    void Start()
    {
        cam = Camera.main;
        shoot = GetComponent<EnemiesShoot>();

        // Asignamos una velocidad aleatoria entre 2 y 6
        speed = Random.Range(2f, 6f);
        
        // Determinamos dirección inicial: si está a la derecha, va a la izquierda
        movingLeft = transform.position.x > 0;
    }

    void Update()
    {
        // Movimiento constante
        float direction = movingLeft ? -1f : 1f;
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        CheckBounds();

        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            shoot.Shoot();
            shootTimer = 0f;
            shootInterval = ShootRandomly(); // Reinicia el timer
        }
    }

    void CheckBounds()
    {
        Vector3 screenPos = cam.WorldToViewportPoint(transform.position);

        // Si se sale por el lado opuesto (fuera del rango 0 a 1 en el viewport)
        if (screenPos.x < -0.1f || screenPos.x > 1.1f)
        {
            // Decisión al azar: 50% volver, 50% desaparecer
            if (Random.value > 0.5f)
            {
                movingLeft = !movingLeft; // Cambia dirección
            }
            else
            {
                Destroy(gameObject); // Desaparece
            }
        }
    }

    float ShootRandomly()
    {
        shootInterval = Random.Range(1f, 2f); // Dispara cada 0.5 a 2 segundos
        return shootInterval;
    }
}
