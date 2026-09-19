using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] Transform _nozzle;
    
    [SerializeField] GameObject _bulletPrefab; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
{
    if(Input.GetKeyDown(KeyCode.Space))

    {
        Instantiate(_bulletPrefab, _nozzle.position, Quaternion.identity);

    }
}
}
