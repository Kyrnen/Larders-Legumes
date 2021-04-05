using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //smooth transitions
    public bool smoothTransition = true;
    public float transitionSpeed = 10f;
    public float transitionRotationSpeed = 500f;

    public bool inCombat = false;
    public bool engaged = false;
    public bool hasAttacked = false;
    
    public bool blockedForwards = false;
    public bool blockedBackwards = false;
    public bool blockedLeft = false;
    public bool blockedRight = false;

    Vector3 targetGridPos;
    Vector3 prevTargetGridPos;
    Vector3 targetRotation;

    RaycastHit hitForwards;
    RaycastHit hitBackwards;
    RaycastHit hitLeft;
    RaycastHit hitRight;
    public Player player;

    public void RotateLeft() { if (AtRest && !engaged) targetRotation -= Vector3.up * 90f; }
    public void RotateRight() { if (AtRest && !engaged) targetRotation += Vector3.up * 90f; }
    public void MoveForwards() { if (AtRest && !engaged && !blockedForwards) targetGridPos += transform.forward; }
    public void MoveBackwards() { if (AtRest && !engaged && !blockedBackwards) targetGridPos -= transform.forward; }
    public void MoveLeft() { if (AtRest && !engaged && !blockedLeft) targetGridPos -= transform.right; }
    public void MoveRight() { if (AtRest && !engaged && !blockedRight) targetGridPos += transform.right; }

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
        player = GetComponent<Player>();
        targetGridPos = Vector3Int.RoundToInt(transform.position);
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        CheckBlocks();
        if (!engaged)
            MovePlayer();
        else
        {
            inCombat = true;
            DealDamage(player.attackPower);
        }
    }

    public void DealDamage(int attack)
    {
        if (hitForwards.collider.gameObject.tag == "Enemy")
        {
            if (Input.GetMouseButtonDown(0))
            {
                hitForwards.collider.gameObject.GetComponent<Enemy>().GetComponent<Enemy>().TakeDamage(attack);
            }
        }
    }

    void CheckBlocks()
    {

        if (Physics.Raycast(transform.position, this.transform.forward, out hitForwards, 3f) && hitForwards.collider.gameObject.tag == "Enemy" ||
           Physics.Raycast(transform.position, -this.transform.forward, out hitBackwards, 3f) && hitBackwards.collider.gameObject.tag == "Enemy" ||
           Physics.Raycast(transform.position, -this.transform.right, out hitLeft, 3f) && hitLeft.collider.gameObject.tag == "Enemy" ||
           Physics.Raycast(transform.position, this.transform.right, out hitRight, 3f) && hitRight.collider.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Sighted");
            engaged = true;
        }
        else
        {
            Debug.Log("No enemy in vicinity");
            engaged = false;
        }

        if (Physics.Raycast(transform.position, this.transform.forward, out hitForwards, 3f) && 
            hitForwards.collider.gameObject.tag == "Wall")
        {
            Debug.Log("Obstuction ahead");
            blockedForwards = true;
        }
        else
        {
            Debug.Log("No obstructions ahead");
            blockedForwards = false;
        }

        if (Physics.Raycast(transform.position, -this.transform.forward, out hitBackwards, 3f) && 
            hitBackwards.collider.gameObject.tag == "Wall")
        {
            Debug.Log("Obstuction behind");
            blockedBackwards = true;
        }
        else
        {
            Debug.Log("No obstructions behind");
            blockedBackwards = false;
        }

        if (Physics.Raycast(transform.position, -this.transform.right, out hitLeft, 3f) && 
            hitLeft.collider.gameObject.tag == "Wall")
        {
            Debug.Log("Obstuction left");
            blockedLeft = true;
        }
        else
        {
            Debug.Log("No obstructions left");
            blockedLeft = false;
        }

        if (Physics.Raycast(transform.position, this.transform.right, out hitRight, 3f) && 
            hitRight.collider.gameObject.tag == "Wall")
        {
            Debug.Log("Obstuction right");
            blockedRight = true;
        }
        else
        {
            Debug.Log("No obstructions right");
            blockedRight = false;
        }
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
