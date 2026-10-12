//Danny Ramirez
//ramdanny@gmail.com
//desde aqui manejamos loop de l escenario para que las pantallas se repitan 

using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    [Header("Piezas del fondo")]
    [SerializeField] private Transform pieceA;
    [SerializeField] private Transform pieceB;

    [Header("Ajustes de Scroll")]
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float resetYThreshold = -15f; // debajo de este punto, ya no se ve en cámara

    private float gap;

    void Start()
    {
        gap = Mathf.Abs(pieceB.position.y - pieceA.position.y);
    }

    void Update()
    {
        pieceA.position += Vector3.down * speed * Time.deltaTime;
        pieceB.position += Vector3.down * speed * Time.deltaTime;

        float topMost = Mathf.Max(pieceA.position.y, pieceB.position.y);

        if (pieceA.position.y <= resetYThreshold)
            pieceA.position = new Vector3(pieceA.position.x, topMost + gap, pieceA.position.z);

        if (pieceB.position.y <= resetYThreshold)
            pieceB.position = new Vector3(pieceB.position.x, topMost + gap, pieceB.position.z);
    }
}