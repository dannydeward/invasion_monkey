
/** autor: danny Ramirez 
   e-mail : ramdanny@gmail.com
   @desc[estoy haciendo el scritp para movimiento de la nave]*/

using UnityEngine;

public class playermoved : MonoBehaviour
{
    [SerializeField]  float _speed = 5f;
    float _vert= 0f;
     float _hor = 0f;

     Vector2  _move;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
     
    {
        _vert = Input.GetAxis("Vertical");
        _hor=  Input.GetAxis("Horizontal");

  _move= new Vector2(_hor, _vert);
  _move=_move.normalized; 
        transform.Translate(new Vector3(_move.x, _move.y, 0f) * Time.deltaTime * _speed);
    }
}

