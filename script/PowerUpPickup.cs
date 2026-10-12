/**danny ramirez
ramdanny@gmail.com
aqui activamos las armas de los power up, el arma doble en la escena uno y el arma triple en la escena 2 **/



using UnityEngine;
using UnityEngine.SceneManagement; 

public class PowerUpPickup : MonoBehaviour
{
    
    public bool esArmaNueva = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShooting shooter = other.GetComponentInParent<PlayerShooting>();
            if (shooter != null)
            {
                // Detectamos en qué escena estamos
                int escenaActual = SceneManager.GetActiveScene().buildIndex;

                
                if (escenaActual == 1)
                {
                    shooter.ActivarDisparoDoble(); 
                    Debug.Log("-> Power-Up: Disparo Doble (Escena 1)");
                }
               
                else
                {
                    if (esArmaNueva)
                    {
                        shooter.ActivarArmaNueva(); // Triple disparo
                        Debug.Log("-> Power-Up: Arma Nueva (Triple)");
                    }
                    else
                    {
                        shooter.ActivarDisparoDoble(); // Disparo doble normal
                        Debug.Log("-> Power-Up: Disparo Doble");
                    }
                }
            }
            Destroy(gameObject);
        }
    }
}