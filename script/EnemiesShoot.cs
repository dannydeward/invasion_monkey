//Danny Ramirez
//ramdanny@gmail.com
// este scrip maneja los disparos,  del enemigo , activa los firepoint el firepoint inicial que se usa en la escena 1 y dos  y el segundo firepint que s eusa en al escena3 que lo usa el varon gorila 


using UnityEngine;

public class EnemiesShoot : MonoBehaviour
{
    [Header("Configuración de Disparo")]
    [SerializeField] private GameObject _bulletPrefab;
    
    [SerializeField] private Transform _firePoint; 
    
      [SerializeField] private Transform _firePoint2; 

    public void Shoot()
    {
        if (_bulletPrefab == null) return;

      
        if (_firePoint != null)
        {
            Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
        }

        
        if (_firePoint2 != null)
        {
            Instantiate(_bulletPrefab, _firePoint2.position, Quaternion.identity);
        }
    }
}