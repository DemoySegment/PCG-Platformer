using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController characterController;

    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    public bool isGrounded;
    public static bool isMoving;

    private Vector3 lastPosition = new Vector3(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //GroundCheck
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        //Resetting the default velocity
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //calculate move direction , right is red line, forward is blue (from editor)
        Vector3 move = transform.right * x + transform.forward * z;


        characterController.Move(speed * Time.deltaTime * move);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            //actually jumping
            velocity.y = Mathf.Sqrt (jumpHeight * -2f * gravity);
        }

        //falling down

        velocity.y += gravity*Time.deltaTime;

        //executing the jump
         characterController.Move(velocity * Time.deltaTime);


        if(lastPosition != gameObject.transform.position && isGrounded == true)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        lastPosition = gameObject.transform.position;
    }
}
