using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public Transform playerPosition => GameManager.instance.playerTransform;

    public abstract State RunCurrentState();


   



    //public Transform playerPosition()
    //{
    //    return GameManager.instance.playerTransform;
    //}
}
