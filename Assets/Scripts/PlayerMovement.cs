using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Character controller referenced from: https://www.youtube.com/watch?v=4HpC--2iowE


public class PlayerMovement : MonoBehaviour
{
    //Create reference to character controller
    public CharacterController controller;

    public Transform cam;

    public float speed = 3f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    
    

    //Counter that increments when coins are picked up
    private int coinCounter = 0;


    
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


            //Play Walking animation
            GetComponent<Animator>().SetInteger("AnimatorState", 1);

        }

        else
        {
            //Play Idle Animation
            GetComponent<Animator>().SetInteger("AnimatorState", 0);
        }

    

    }

    //Collision Detection Function
    //If the player touches the coin, the coin is destroyed
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Coin")
        {
            Destroy(col.gameObject);

            //Increment coin counter after colliding with coin
            coinCounter++;
        }

        //If the coin counter equals 10, the scene manager switches to the game over screen
        if(coinCounter == 10)
        {

            //Load Game Over Screen
            SceneManager.LoadScene("End");
        }

    }

}
