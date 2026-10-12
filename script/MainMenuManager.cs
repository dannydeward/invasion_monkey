//Danny Ramirez
//ramdanny@gmail.com
// desde aqui manejamos el menu inicial que permite iniciar a jugar y ver los credtios, llama a la primera escena 


using UnityEngine;
using UnityEngine.SceneManagement; // Importante para cambiar de escena

public class MainMenuManager : MonoBehaviour
{
    [Header("Referencias UI")]
    [SerializeField] private GameObject panelCreditos;

    public void Jugar()
    {
       
        SceneManager.LoadScene("invasionmonkey"); 
    }

    public void MostrarCreditos()
    {
        panelCreditos.SetActive(true);
    }

    public void OcultarCreditos()
    {
        panelCreditos.SetActive(false);
    }

    public void Salir()
    {
        Debug.Log("Juego Cerrado");
        Application.Quit(); 
    }
}