using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //smooth transitions
    public bool smoothTransition = true;
    public float transitionSpeed = 10f;
    public float transitionRotationSpeed = 500f;

    Vector3 targetGridPos;
    Vector3 prevTargetGridPos;
    Vector3 targetRotation;

    public void RotateLeft() { if (AtRest) targetRotation -= Vector3.up * 90f; }
    public void RotateRight() { if (AtRest) targetRotation += Vector3.up * 90f; }
    public void MoveForwards() { if (AtRest) targetGridPos += transform.forward; }
    public void MoveBackwards() { if (AtRest) targetGridPos -= transform.forward; }
    public void MoveLeft() { if (AtRest) targetGridPos -= transform.right; }
    public void MoveRight() { if (AtRest) targetGridPos += transform.right; }

    //mostly if you want smooth transitions
    bool AtRest
    {
        get
        {
            if (Vector3.Distance(transform.position, targetGridPos) < 0.05f && 
                Vector3.Distance(transform.eulerAngles, targetRotation) < 0.05f)
                return true;
            else return false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        targetGridPos = Vector3Int.RoundToInt(transform.position);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (true) //SHOULD BE CHANGED: If the player is not obstructed by some other object or creature, then they can move otherwise no.
        {
            prevTargetGridPos = targetGridPos;
            
            //for setting grid offset position of player to world, modifications to player (we probably don't need this?)
            Vector3 targetPosition = targetGridPos;

            if (targetRotation.y > 270f && targetRotation.y <= 360) targetRotation.y = 0f;
            if (targetRotation.y < 0) targetRotation.y = 270f;

            if(!smoothTransition)
            {
                transform.position = targetPosition;
                transform.rotation = Quaternion.Euler(targetRotation);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * transitionSpeed);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * transitionRotationSpeed);
            }
            
        }
        else
        {
            targetGridPos = prevTargetGridPos;
        }

    }

}
