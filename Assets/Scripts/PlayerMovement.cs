using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Create reference to character controller
    public CharacterController controller;

    public Transform cam;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    //Call the Animator
    private Animator anim;

    //private void Awake()
    //{

    //   // anim = this.getComponent<Animator>();

    //}

    // Update is called once per frame
    void Update()
    {
        //Movement controls
        //GetAxis Raw horizontal will control our horizontal movement when pressing the 'A' and 'D' keys
        //GetAxis Raw vertical will control our vertical movement when pressing the 'W' and 'S' keys
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //Vec3 to store driection
        // Apply the input on the x and z axis which is where the player will move (Y-axis will move the player up)
        //Normalizing the vector will accomodate for speed increase if the player press' two buttons at the same time
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;




        if (direction.magnitude >= 0.1f)
        {

            //Move rotation 
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //Angle at which the player rotates
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            //Transform used for rotating
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            //Apply move vector to character controller
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

        }

        //Enable walk animation after inputting keys
        //if (anim != null)
        //    anim.SetBool("isMoving");

    }


}
