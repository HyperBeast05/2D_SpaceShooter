using UnityEngine;

public class BossStats : Enemy
{

    [SerializeField] private BossController bossController;
    [SerializeField] private Animator anim;

    private void OnEnable()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        health = maxHealth;

    }

    protected override void HurtSequence()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Dmg")) return;
        anim.SetTrigger("Damage");
    }

    protected override void DeathSequence()
    {
        base.DeathSequence();
        bossController.ChangeState(BossState.Death);
        AudioManager.instance.PlayExplosion();
        GameObject obj = Instantiate(exploisonPrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        Destroy(obj, .2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerStats>(out PlayerStats playerStats))
        {
            playerStats.TakeDamage(damage);
        }
    }
    void Start()
    {

    }

    void Update()
    {

    }
}
