using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float health = 100f;
    public int worth = 20;

    public GameObject deathEffect;

    private void Start()
    {
        speed = startSpeed;
    }

    public void takeDamage(float amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    public void Slow(float amount)
    {
        speed = startSpeed * (1 - amount);
    }

    private void Die()
    {
        GameObject deathParticles = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(deathParticles, 2f);

        PlayerStats.money += worth;
        Destroy(gameObject);
    }
}