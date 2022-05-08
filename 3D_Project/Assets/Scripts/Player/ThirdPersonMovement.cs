using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{   //coode to use the old controller to get input from player to the player game object
    public CharacterController controller;
    //able to use the camera for oreientation and co-ordinates
    public Transform camera;
    //veriables for player speed and turning that are puplic so you can change them in the insptor
    private float turnSmoothVelocity;

    public PlayerScriptableObject playerScriptableObject;

    //hides cursor on play
    void Start()
    {
      //  Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //able to store the information of what way the player is moving
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //to check if the player odject is moving
        if(direction.magnitude >= 0.1f)
        {
            //able to store the information of what way the player should be oriented to be looking the way they are moving. And to change what is stright basted on the camera 
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle,ref turnSmoothVelocity , playerScriptableObject.turning);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            //to make it so the player game object turns its "modle" to the way it is moving instead of staping to look in that direction
            Vector3 moveDir = Quaternion.Euler(0f,targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * playerScriptableObject.speed * Time.deltaTime);

        }


    }
}
