//Danny Ramirez
//ramdanny@gmail.com
// controla el contador de vidas 

using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    [Header("Iconos de Vida")]
    [SerializeField] private Image[] iconosDeVida;

    public void ActualizarVidas(int vidasActuales)
    {
        for (int i = 0; i < iconosDeVida.Length; i++)
        {
            if (i < vidasActuales)
            {
                iconosDeVida[i].gameObject.SetActive(true);
            }
            else
            {
                iconosDeVida[i].gameObject.SetActive(false);
            }
        }
    }
}