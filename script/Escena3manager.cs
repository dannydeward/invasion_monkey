//Danny Ramirez
//ramdanny@gmail.com
// es la encargada de manejar la escena 2, general las oledas de enemigos, se comunica con el game manager al terminar la escena 
//para que llame al game over o victoria




using UnityEngine;

public class Escena3Manager : MonoBehaviour
{
    private bool oleadaFinalizada = false;
    private int oleadaActual = 1;
    private bool esperandoInicio = true; 
    private bool enTransicion = false; 

    [Header("Prefabs de Enemigos")]
    [SerializeField] GameObject monkeyPrefab;
    [SerializeField] GameObject capitanPrefab;
    [SerializeField] GameObject gorilaPrefab;

    [Header("Altura de entrada (fuera de pantalla)")]
    [SerializeField] float entradaY = 8f;

    void Start()
    {
        Invoke(nameof(ActivarConteo), 2f);
        InvocarOleada1();
    }

    void ActivarConteo()
    {
        esperandoInicio = false;
        Debug.Log("Conteo de enemigos activado");
    }

    void Update()
    {
        if (oleadaFinalizada) return;
        if (esperandoInicio) return;

        int enemigosVivos = GameObject.FindGameObjectsWithTag("Enemies").Length;

    
        if (enemigosVivos == 0 && !enTransicion)
        {
            enTransicion = true; // Bloqueamos el conteo temporalmente

            switch (oleadaActual)
            {
                case 1:
                    oleadaActual = 2;
                    Invoke(nameof(InvocarOleada2), 1.5f);
                    break;
                case 2:
                    oleadaActual = 3;
                    Invoke(nameof(InvocarOleada3), 2f);
                    break;
                case 3:
                    oleadaFinalizada = true;
                    Debug.Log("¡JUEGO TERMINADO! Has derrotado al Varón Gorila.");
                    if (GameManager.Instance != null)
                    {
                        GameManager.Instance.NivelCompletado();
                    }
                    break;
            }
        }
       
        else if (enemigosVivos > 0)
        {
            enTransicion = false;
        }
    }

    void InvocarOleada1()
    {
        Debug.Log("¡Oleada 1: 1 Capitán y 2 Monos!");
        Invoke(nameof(InvocarCapitan1), 0.5f);
        Invoke(nameof(InvocarMono1), 1.0f);
        Invoke(nameof(InvocarMono2), 1.5f);
    }

    void InvocarOleada2()
    {
        Debug.Log("¡Oleada 2: 3 Capitanes!");
        Invoke(nameof(InvocarCapitan2_1), 0.5f);
        Invoke(nameof(InvocarCapitan2_2), 1.0f);
        Invoke(nameof(InvocarCapitan2_3), 1.5f);
    }

    void InvocarOleada3()
    {
        Debug.Log("¡Oleada 3: EL JEFE VARÓN GORILA!");
        Invoke(nameof(InvocarGorila), 1.0f);
    }

    void InvocarCapitan1()
    {
        Instantiate(capitanPrefab, new Vector3(0, entradaY, 0), Quaternion.identity);
    }

    void InvocarMono1()
    {
        Instantiate(monkeyPrefab, new Vector3(-2.5f, entradaY, 0), Quaternion.identity);
    }

    void InvocarMono2()
    {
        Instantiate(monkeyPrefab, new Vector3(2.5f, entradaY, 0), Quaternion.identity);
    }

    void InvocarCapitan2_1()
    {
        Instantiate(capitanPrefab, new Vector3(-2.5f, entradaY, 0), Quaternion.identity);
    }

    void InvocarCapitan2_2()
    {
        Instantiate(capitanPrefab, new Vector3(0, entradaY, 0), Quaternion.identity);
    }

    void InvocarCapitan2_3()
    {
        Instantiate(capitanPrefab, new Vector3(2.5f, entradaY, 0), Quaternion.identity);
    }

    void InvocarGorila()
    {
        Instantiate(gorilaPrefab, new Vector3(0, entradaY + 2f, 0), Quaternion.identity);
    }
}