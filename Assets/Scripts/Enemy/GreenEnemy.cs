using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class GreenEnemy : Enemy
{
    [SerializeField] private float speed;

    Animator anim;
    void OnEnable()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemyRB.velocity = speed * Vector2.down;
        anim=GetComponent<Animator>();
        health = maxHealth;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PlayerStats>(out PlayerStats playerStats))
        {
            playerStats.TakeDamage(damage);
            AudioManager.instance.PlayExplosion();
            GameObject obj = Instantiate(exploisonPrefab,transform.position,Quaternion.identity);
            Destroy(obj, .2f);
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
