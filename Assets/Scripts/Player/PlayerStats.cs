using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private Image healthBar;
    [SerializeField] private Animator playerAnim;
    [SerializeField] private Shield shield;

    LaserSpawner spawner;

    public float Health { get; private set; }

    bool canplayAnim = true;

    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
        spawner = GetComponent<LaserSpawner>();
    }

    void Start()
    {
        Health = maxHealth;
        healthBar.fillAmount = Health / maxHealth;
        EndGameManager.instance.gameOver = false;
    }

    void Update()
    {

    }



    public void TakeDamage(float damage)
    {

        if (shield.protection) return;
        Health -= damage;
        healthBar.fillAmount = Health / maxHealth;
        if (canplayAnim)
        {
            playerAnim.SetTrigger("Damage");
            StartCoroutine(nameof(AntiSpawnAnimation));

        }
        spawner.DecreaseUpgradeShootPoint();
        if (Health <= 0)
        {
            EndGameManager.instance.gameOver = true;
            Destroy(gameObject, .2f);
        }
    }

    public void AddHealth(int healthAmount)
    {
        Health += healthAmount;
        healthBar.fillAmount = Health / maxHealth;
        if (Health >= maxHealth)
        {
            Health = maxHealth;
            healthBar.fillAmount = Health / maxHealth;
        }
    }

    IEnumerator AntiSpawnAnimation()
    {
        canplayAnim = false;
        yield return new WaitForSeconds(.15f);
        canplayAnim = true;
    }
}
