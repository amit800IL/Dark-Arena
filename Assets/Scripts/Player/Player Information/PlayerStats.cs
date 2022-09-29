using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }
    public float health;
    public float speed;
    public float attackPower;
    public PlayerHealthManager healthManager;

    private void Start()
    {
        Instance = this;    
    }

}
