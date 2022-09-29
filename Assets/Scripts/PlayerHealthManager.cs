using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthManager : MonoBehaviour
{
    public UnityEvent onTakeDamage;
    public void TakeDamage(int Damage)
    {
        PlayerStats.Instance.health -= Damage;
        onTakeDamage.Invoke();
    }
}
