using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerInput : MonoBehaviour
{
    public KeyCode forwards = KeyCode.W;
    public KeyCode backwards = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode turnLeft = KeyCode.Q;
    public KeyCode turnRight = KeyCode.E;

    private PlayerController controller;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(forwards)) controller.MoveForwards();
        if (Input.GetKeyUp(backwards)) controller.MoveBackwards();
        if (Input.GetKeyUp(left)) controller.MoveLeft();
        if (Input.GetKeyUp(right)) controller.MoveRight();
        if (Input.GetKeyUp(turnLeft)) controller.RotateLeft();
        if (Input.GetKeyUp(turnRight)) controller.RotateRight();
    }
}
