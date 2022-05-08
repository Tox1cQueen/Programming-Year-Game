using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRoll : MonoBehaviour
{
    //setting veriables for speed and a downward pushing force
    public float speed = 10.0f;
    private Rigidbody rb;
    public float grav = 1.0f; 

   
    void Update()
    {
        //getting accsess to the riged body
        rb = this.GetComponent<Rigidbody>();
        //adding to the ridig body to make it rool
        rb.velocity = new Vector3(0, -grav, -speed);
        //destroying the object after a sutin time so it is not taking up space
        Destroy(gameObject, 26f);
    }
}
