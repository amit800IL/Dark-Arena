using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectsMover : MonoBehaviour
{
    public bool move;
    Vector3 startingPosition;
    bool isMovingToTarget;
    [SerializeField] Transform target;
    [SerializeField] int moveSpeed;

    

    private void Start()
    {
        move = true;
        isMovingToTarget = true;
        startingPosition = transform.position;
        StartCoroutine(brigeTimer());
    }
    IEnumerator brigeTimer()
    {
        while (move)
        {
            if (isMovingToTarget)
            {
               transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, target.position) < 1f)
                {
                    isMovingToTarget = false;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, startingPosition, moveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, startingPosition) < 1f)
                {
                    isMovingToTarget = true;
                }
            }
         
           
            yield return new WaitForEndOfFrame();
        }
     
    }
}
