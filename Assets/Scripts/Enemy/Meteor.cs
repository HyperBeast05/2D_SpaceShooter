using UnityEngine;
using UnityEngine.SceneManagement;

public class Meteor : Enemy
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float rotateSpeed;

    [SerializeField] private ScriptableObjExample powerUp;

    float speed;

    private void Awake()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        enemyRB.velocity = speed * Vector2.down;
    }

    private void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerStats>(out var stats))
        {
            stats.TakeDamage(damage);
            AudioManager.instance.PlayExplosion();
            GameObject explosion = Instantiate(exploisonPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, .2f);
            gameObject.SetActive(false);
        }
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    protected override void HurtSequence()
    {
        base.HurtSequence();
    }

    protected override void DeathSequence()
    {
        base.DeathSequence();
        AudioManager.instance.PlayExplosion();
        GameObject explosion = Instantiate(exploisonPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, .2f);
        if (SceneManager.GetActiveScene().buildIndex > 3)
        {
            if (powerUp != null)
                powerUp.SpawnerPowerUp(transform.position);
        }

        gameObject.SetActive(false);
    }
}