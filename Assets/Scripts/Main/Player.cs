using UnityEngine;

public class Player
{
    private static Player _instance;
    public static Player Instance => _instance ??= new Player();

    public int Money { get; private set; } = 1000;

    private Player() { }

    public void AddMoney(int amount) => Money += amount;

    public bool SpendMoney(int amount)
    {
        if (Money >= amount)
        {
            Money -= amount;
            return true;
        }
        return false;
    }
}
