using System.Collections;
using UnityEngine;

public class SpecialBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float damage;

    [SerializeField] private GameObject miniBullet;
    [SerializeField] private Transform[] minSpawnPoints;
    Rigidbody2D specialBulletRB;

    private void OnEnable()
    {
        specialBulletRB=GetComponent<Rigidbody2D>();
        specialBulletRB.velocity = Vector2.down * speed;
    }
    void Start()
    {
        StartCoroutine(nameof(ExplodeSpecialBullet));
    }

    IEnumerator ExplodeSpecialBullet()
    {
        float randomExplodeTime = Random.Range(1.5f, 2.5f);
        yield return new WaitForSeconds(randomExplodeTime);
        for(int i=0;i<minSpawnPoints.Length;i++)
        {
            Instantiate(miniBullet, minSpawnPoints[i].position, minSpawnPoints[i].rotation);
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PlayerStats>(out PlayerStats playerStats))
        {
            playerStats.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed);
    }
}
