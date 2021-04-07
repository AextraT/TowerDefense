using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float startHealth = 100f;
    private float health;
    public int worth = 20;

    public Transform canvas;
    public Transform partToRotate;

    public GameObject deathEffect;

    public Image healthBar;

    private void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void takeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

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