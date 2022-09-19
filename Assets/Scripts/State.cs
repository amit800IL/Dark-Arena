using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public Transform playerPosition;

    public abstract State RunCurrentState();

}
