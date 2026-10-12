//Danny Ramirez
//ramdanny@gmail.com
/** dese aqui le damo movimiento al power up para que caiga despacio por la pantalal y pueda ser tomado por el jugador**/

using UnityEngine;

public class PowerUpMovement : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 1.5f;

    private float minScreenY;

    void Start()
    {
        float camDistance = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, camDistance));
        minScreenY = bottomLeft.y - 1f;
    }

    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        if (transform.position.y < minScreenY)
        {
            Destroy(gameObject);
        }
    }
}