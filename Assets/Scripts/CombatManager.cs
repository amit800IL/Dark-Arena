using UnityEngine;

public class CombatManager : MonoBehaviour
{
    int Damage;
    int health;
    public GameObject playerRefernce;
    public GameObject enemyRefernce;


    public void getDamage()
    {
        health -= Damage;
    }

    public bool isDead()
    {
        return health <= 0;
    }

    

}
