using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private float timeBetweenWaves = 5f;
    [SerializeField]
    private float timeBetweenEnemies = 0.5f;

    private float countdown = 5f;

    [SerializeField]
    private Text waveCountdownTimer;

    private int waveIndex = 0;

    void Update()
    {
        if(EnemiesAlive > 0)
        {
            return;
        }

        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0, Mathf.Infinity);
        waveCountdownTimer.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.rounds++;

        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.enemies.Length; i++)
        {
            Enemies enemies = wave.enemies[i];
            for (int j = 0; j < enemies.count; j++)
            {
                SpawnEnemy(enemies.enemy);
                yield return new WaitForSeconds(1f / enemies.rate);
            }

            yield return new WaitForSeconds(timeBetweenEnemies);
        }

        waveIndex++;

        if(waveIndex == waves.Length)
        {
            Debug.Log("TERMINE! BRAVO!");
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
