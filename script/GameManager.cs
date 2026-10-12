//Danny Ramirez
//ramdanny@gmail.com
// gamemaneger controla las tres escenas , se comunica con los agentes de las escenas para lanzaslas en el momento adecuado 
// tambien maneja las pantallas de victoria, game over y el botos de vovler al menu que figura en creditos
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void NivelCompletado()
    {
        string escenaActual = SceneManager.GetActiveScene().name;
        Debug.Log($"Escena '{escenaActual}' completada. Cargando siguiente...");

        switch (escenaActual)
        {
            case "invasionmonkey":
                SceneManager.LoadScene("invasionmonkey 2");
                break;
            case "invasionmonkey 2":
                SceneManager.LoadScene("invasionmonkey3");
                break;
            case "invasionmonkey3":
                SceneManager.LoadScene("Victoria");
                break;
        }
    }

    public void GameOver()
    {
        Debug.Log("Cargando Gameover...");
        SceneManager.LoadScene("Gameover");
    }

    public void VolverAlMenu()
    {
        Debug.Log("Volviendo al menú principal");
        SceneManager.LoadScene("main menu");
    }
}