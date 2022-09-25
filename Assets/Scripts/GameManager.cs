using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform playerTransform;
    public GameObject player;
    public void Awake()
    {
        instance = this;
    }
}
