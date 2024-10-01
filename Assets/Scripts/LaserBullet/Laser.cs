using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] protected GameObject exploisonPrefab;

    Camera mainCam;
    Rigidbody2D laserRB;

    private void OnEnable()
    {
        laserRB = GetComponent<Rigidbody2D>();
        laserRB.velocity = speed * transform.up;
        mainCam = Camera.main;
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if (collision.transform.position.y > Camera.main.ViewportToWorldPoint(new Vector2(0, .9f)).y) return;
            enemy.TakeDamage(damage);
            //GameObject explosion = Instantiate(exploisonPrefab, transform.position, Quaternion.identity);
            //Destroy(explosion, .2f);
            //enemy.gameObject.SetActive(false);
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.y > mainCam.ViewportToWorldPoint(new Vector2(0, 1.1f)).y)
            gameObject.SetActive(false);
    }
}
