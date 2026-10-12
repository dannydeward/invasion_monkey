//Danny Ramirez
//ramdanny@gmail.com
// es la encargada de manejar la escena 2, general las oledas de enemigos, se comunica con el game manager al terminar la escena 
//para que llame al game over o a la escena tres 


using UnityEngine;

public class Escena2Manager : MonoBehaviour
{
    private bool oleadaFinalizada = false;
    private int oleadaActual = 1;

    [Header("Prefabs")]
    [SerializeField] GameObject monkeyPrefab;
    [SerializeField] GameObject capitanPrefab;

    [Header("Power-Up")]
    [SerializeField] GameObject PowerUpDoubleShot; 

    [Header("Posición de aparición (Y)")]
    [SerializeField] float spawnY = 2f;

    void Start() 
    { 
        InvocarOleada1(); 
    }

    void Update()
    {
        if (oleadaFinalizada) return;
        
        int enemigosVivos = GameObject.FindGameObjectsWithTag("Enemies").Length;

        if (enemigosVivos == 0)
        {
            switch (oleadaActual)
            {
                case 1: 
                    oleadaActual = 2; 
                    InvocarOleada2(); 
                    break;
                case 2: 
                    oleadaActual = 3; 
                    InvocarOleada3(); 
                    break;
                case 3:
                oleadaFinalizada = true;
                Debug.Log("¡JUEGO TERMINADO! Has ganado.");
                // Avisar al GameManager
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.NivelCompletado();
                }
                break;
            }

         }
    }

    void InvocarOleada1()
    {
        Debug.Log("¡Oleada 1: 3 Monkeys!");
        for (int i = 0; i < 3; i++)
        {
            float xPos = Random.Range(-3f, 3f);
            Instantiate(monkeyPrefab, new Vector3(xPos, spawnY, 0), Quaternion.identity);
        }
    }

    void InvocarOleada2()
    {
        Debug.Log("¡Oleada 2: 4 Monkeys!");
        for (int i = 0; i < 4; i++)
        {
            float xPos = Random.Range(-3f, 3f);
            Instantiate(monkeyPrefab, new Vector3(xPos, spawnY, 0), Quaternion.identity);
        }
    }

    void InvocarOleada3()
    {
        Debug.Log("¡Oleada 3: Capitán y 3 Escoltas!");
        
      
        GameObject capitan = Instantiate(capitanPrefab, new Vector3(0, spawnY, 0), Quaternion.identity);
        GameObject escolta1 = Instantiate(monkeyPrefab, new Vector3(-1.5f, spawnY, 0), Quaternion.identity);
        GameObject escolta2 = Instantiate(monkeyPrefab, new Vector3(0f, spawnY, 0), Quaternion.identity);
        GameObject escolta3 = Instantiate(monkeyPrefab, new Vector3(1.5f, spawnY, 0), Quaternion.identity);

    
        GameObject[] posiblesPortadores = { escolta1, escolta2, escolta3 };
        int indiceElegido = Random.Range(0, posiblesPortadores.Length);
        GameObject portador = posiblesPortadores[indiceElegido];

        
       // Debug.Log("DEBUG: ¿PowerUpDoubleShot es null? " + (PowerUpDoubleShot == null));
       // Debug.Log("DEBUG: ¿portador es null? " + (portador == null));

        if (portador != null && PowerUpDoubleShot != null) 
        {
            EnimyHeart corazon = portador.GetComponent<EnimyHeart>();
            
         //   Debug.Log("DEBUG: ¿corazon (EnimyHeart) es null? " + (corazon == null));

            if (corazon != null)
            {
                corazon.SetPowerUp(PowerUpDoubleShot);
               // Debug.Log(">>> EL ENEMIGO CON EL POWER-UP ES: " + portador.name + " <<<");
            }
            else
            {
                Debug.LogError("ERROR: El enemigo elegido NO tiene el componente EnimyHeart2 adjunto.");
            }
        }
        else
        {
            Debug.LogError("ERROR: Falló la asignación. Revisa los mensajes 'DEBUG' de arriba para ver qué variable es 'True' (null).");
        }
    }
}