//Danny Ramirez
//ramdanny@gmail.com
// con este escript se activa el botos volver al menu de la pantalla game over y victoria 

using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonVolver : MonoBehaviour
{
    public void IrAlMenu()
    {
        SceneManager.LoadScene("main menu");
    }
}