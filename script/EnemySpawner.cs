//Danny Ramirez
//ramdanny@gmail.com
//este script controla toda la escena 1  genera las oleadas de enemigos, informa al Gamemanager cuando la escena termino 
// para invoque la escena 2 o llame a game over, tambien asigna el powerup de forma aleatoria aun enemigo en la ultima oleada 



using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Prefab del enemigo")]
    [SerializeField] private GameObject enemyPrefab;

    [Header("Configuración de oleadas (la primera ya está en escena)")]
    [SerializeField] private int[] waveSizes = { 3, 4, 3 };

    [Header("Zona de aparición")]
    [SerializeField] private float spawnY = 12f;      // altura donde aparecen (arriba de cámara)
    [SerializeField] private float minX = -4f;
    [SerializeField] private float maxX = 4f;

    private int currentWaveIndex = 0; // 0 = la oleada 1, que ya está puesta a mano

    void Update()
    {
        int enemiesLeft = GameObject.FindGameObjectsWithTag("Enemies").Length;

        if (enemiesLeft == 0)
        {
            currentWaveIndex++;

            if (currentWaveIndex >= waveSizes.Length)
            {
                LevelWon();
                enabled = false; // apaga este script, ya no hace falta seguir chequeando
                return;
            }

            SpawnWave(waveSizes[currentWaveIndex]);
        }
    }

       void SpawnWave(int amount)
    {
        bool esUltimaOleada = (currentWaveIndex == waveSizes.Length - 1);
        int indiceGanador = -1;
        
        if (esUltimaOleada) {
            indiceGanador = Random.Range(0, amount);
        }

        for (int i = 0; i < amount; i++)
        {
            float randomX = Random.Range(minX, maxX);
            Vector3 spawnPos = new Vector3(randomX, spawnY, 0f);
            
         
            GameObject nuevoEnemigo = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

           
            if (esUltimaOleada && i == indiceGanador) {
                EnimyHeart corazon = nuevoEnemigo.GetComponent<EnimyHeart>();
                if (corazon != null) {
                    corazon.esElElegido = true;
                }
            }
        }
    }

   void LevelWon()
    {
        Debug.Log("¡Nivel completado! Ganaste.");
        enabled = false; 
        // Avisar al GameManager
        if (GameManager.Instance != null)
        {
            GameManager.Instance.NivelCompletado();
        }
    }
}


