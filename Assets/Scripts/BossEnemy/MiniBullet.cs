using UnityEngine;

public class MiniBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private GameObject explosionPrefab;
    Rigidbody2D bulletRB;

    private void OnEnable()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        bulletRB.velocity = speed * transform.up;
    }
    void Start()
    {
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerStats>(out PlayerStats playerStats))
        {
            playerStats.TakeDamage(damage);
            AudioManager.instance.PlayExplosion();
            GameObject obj = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(obj, .2f);
            gameObject.SetActive(false);
        }
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
