//danny Ramirez
//ramdanny@gmail.com
//con este escrip se trabaja el scroll en pantalla 


using UnityEngine;


public class ScrollBackground : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed = 0.2f;
    private SpriteRenderer _sr;

    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 offset = _sr.material.mainTextureOffset;
        offset.y += _scrollSpeed * Time.deltaTime;
        _sr.material.mainTextureOffset = offset;
    }
}   