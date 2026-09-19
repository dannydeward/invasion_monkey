using UnityEngine;

public class EnemiesShoot : MonoBehaviour
{
    [Header("Configuración de Disparo")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;

    public void Shoot()
    {
        if (_bulletPrefab != null && _firePoint != null)
        {
            Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
        }
    }
}