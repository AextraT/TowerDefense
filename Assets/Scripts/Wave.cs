using UnityEngine;

[System.Serializable]
public class Wave
{
    public Enemies[] enemies;
    public float timeBetweenEnemies;
}

[System.Serializable]
public class Enemies
{
    public GameObject enemy;
    public int count;
    public float rate;
}
