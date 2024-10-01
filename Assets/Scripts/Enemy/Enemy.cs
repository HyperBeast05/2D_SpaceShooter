using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float damage;
    [SerializeField] protected GameObject exploisonPrefab;
    [SerializeField] protected int scoreValue;

    protected float health;
    protected Rigidbody2D enemyRB;
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        HurtSequence();
        if (health <= 0)
        {
            DeathSequence();
        }
          
        
    }


    protected virtual void HurtSequence()
    {

    }

    protected virtual void DeathSequence()
    {
        EndGameManager.instance.UpdateScore(scoreValue); ;
    }
}
