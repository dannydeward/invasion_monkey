/**danny ramirez
ramdanny@gmail.com
desde este scritp se controlan los disparos del jugados con las tres armas que maneja, la basica d ela escena 1, la de disparo doble
en la escena dos y la de disparo triple en la escena tres**/


using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Arma Básica")]
    [SerializeField] Transform _nozzle;           // Punta del avión (disparo simple)
    [SerializeField] GameObject _bulletPrefab;    // Bala normal

    [Header("Disparo Doble (Alas)")]
    [SerializeField] Transform _nozzleIzquierdo;
    [SerializeField] Transform _nozzleDerecho;
    
    [Header("Arma Nueva (Triple Disparo)")]
    [SerializeField] Transform arma1;             // Ala izquierda nueva
    [SerializeField] Transform arma2;             // Ala derecha nueva  
    [SerializeField] Transform arma3;             // Punta del avión nueva
    [SerializeField] GameObject bulletPrefabNuevaArma; // Bala potente
    
    [Header("Estado del Arma")]
    [SerializeField] private bool disparoDobleActivo = false;
    [SerializeField] private bool armaNuevaActiva = false;
    
    [Header("Configuración de Escena")]
    public bool iniciarConDisparoDoble = false;
    
    [Header("Cadencia de Disparo")]
    [SerializeField] float fireRate = 0.2f;
    private float nextFireTime = 0f;

    void Start()
    {
        // Ocultar los nozzles de la nueva arma al inicio
        if (arma1 != null) arma1.gameObject.SetActive(false);
        if (arma2 != null) arma2.gameObject.SetActive(false);
        if (arma3 != null) arma3.gameObject.SetActive(false);
        
        if (iniciarConDisparoDoble)
        {
            ActivarDisparoDoble();
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Disparar();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Disparar()
    {
       
        if (armaNuevaActiva && arma1 != null && arma2 != null && arma3 != null)
        {
            Instantiate(bulletPrefabNuevaArma, arma1.position, Quaternion.identity);
            Instantiate(bulletPrefabNuevaArma, arma2.position, Quaternion.identity);
            Instantiate(bulletPrefabNuevaArma, arma3.position, Quaternion.identity);
        }
        else if (disparoDobleActivo && _nozzleIzquierdo != null && _nozzleDerecho != null)
        {
            Instantiate(_bulletPrefab, _nozzleIzquierdo.position, Quaternion.identity);
            Instantiate(_bulletPrefab, _nozzleDerecho.position, Quaternion.identity);
        }

        else
        {
            Instantiate(_bulletPrefab, _nozzle.position, Quaternion.identity);
        }
    }

    public void ActivarDisparoDoble()
    {
        disparoDobleActivo = true;
        Debug.Log("¡Alas desplegadas! Disparo doble activado.");
    }

  
    public void ActivarArmaNueva()
    {
        armaNuevaActiva = true;
        
     
        if (arma1 != null) arma1.gameObject.SetActive(true);
        if (arma2 != null) arma2.gameObject.SetActive(true);
        if (arma3 != null) arma3.gameObject.SetActive(true);
        
        Debug.Log("¡ARMA NUEVA DESBLOQUEADA! Triple disparo activo.");
    }
}