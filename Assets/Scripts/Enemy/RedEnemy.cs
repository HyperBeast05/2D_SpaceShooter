using UnityEngine;

public class RedEnemy : Enemy
{
    [SerializeField] private float speed;

    [SerializeField] Transform leftPoint, rightPoint;
    [SerializeField] private float spawnTime;

    private float timer;
    private Animator anim;


    private void OnEnable()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemyRB.velocity = speed * Vector2.down;
        anim = GetComponent<Animator>();
        health = maxHealth;
    }
    void Start()
    {
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            SpawnBullet(leftPoint);
            SpawnBullet(rightPoint);
            timer = 0;
        }
    }
    public void SpawnBullet(Transform spawnPos)
    {
        GameObject bullet = EnemyBulletObjPool.instance.GetBullet();
        bullet.SetActive(true);

        if (bullet != null)
        {
            bullet.transform.SetPositionAndRotation(spawnPos.position, Quaternion.identity);
        }
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PlayerStats>(out PlayerStats playerStats))
        {
            playerStats.TakeDamage(damage);
            AudioManager.instance.PlayExplosion();
            GameObject obj = Instantiate(exploisonPrefab,transform.position,Quaternion.identity);
            Destroy(obj,.2f);
            gameObject.SetActive(false);
        }
    }


    protected override void HurtSequence()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Damage")) return;
        anim.SetTrigger("Damage");
    }

    protected override void DeathSequence()
    {
        base.DeathSequence();
        AudioManager.instance.PlayExplosion();
        GameObject obj = Instantiate(exploisonPrefab, transform.position, Quaternion.identity);
        Destroy(obj, .2f);
        gameObject.SetActive(false);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
