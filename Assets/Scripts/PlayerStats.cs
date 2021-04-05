using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 200;

    public static int lives;
    public int startLives = 20;

    public static int rounds;

    private void Start()
    {
        rounds = 0;
        money = startMoney;
        lives = startLives;
    }
}
