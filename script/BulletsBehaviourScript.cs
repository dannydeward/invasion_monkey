using UnityEngine;

public class BulletsBehaviourScript : MonoBehaviour
{

[SerializeField] float _BulletSpeed= 10f;
[SerializeField] float damage= 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject,1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0f,1f,0f)*Time.deltaTime * _BulletSpeed);
    }



    private void OnCollisionEnter2D(Collision2D collision)
{
    if(collision.gameObject.CompareTag("Enemies"))

    {
    Debug.Log(" Bullet hit  an Enemy!");
    EnimyHeart EnimyHeart= collision.gameObject.GetComponent<EnimyHeart>();

     if(EnimyHeart != null)
    {

        EnimyHeart.TakeDamage(damage);
       

    }
    }

    Destroy(gameObject);

    }


}
