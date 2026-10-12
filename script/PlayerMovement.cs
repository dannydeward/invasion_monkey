
/** autor: danny Ramirez 
   e-mail : ramdanny@gmail.com
   aqui  tenemos el scrip que maneja todos lo movimientos de perruelo y le damos limite a la pantalla**/

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    [Header("Límites de la pantalla")]
    [SerializeField] float _minX = -4f;
    [SerializeField] float _maxX = 4f;
    [SerializeField] float _minY = -5f;
    [SerializeField] float _maxY = 5f;

    void Update()
    {
        float vert = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");
        
        Vector2 move = new Vector2(hor, vert).normalized;
        
        // Movemos al jugador
        transform.Translate(move * Time.deltaTime * _speed);

        // Evitamos que Perruelo se salga de la pantalla
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, _minX, _maxX);
        pos.y = Mathf.Clamp(pos.y, _minY, _maxY);
        transform.position = pos;
    }
}

