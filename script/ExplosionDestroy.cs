//Danny Ramirez
//ramdanny@gmail.com
// e es que activa las explosiones tando de la sbalas como de los enemies



using UnityEngine;
public class ExplosionDestroy : MonoBehaviour {
    [SerializeField] private float destroyDelay = 1.5f;
    void Start() { Destroy(gameObject, destroyDelay); }
}
