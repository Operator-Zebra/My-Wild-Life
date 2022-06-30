using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    public Camera playerCamera;
    public Camera managerCamera;
    public GameObject playerCam;
    public Collider PlayerCollider;
    public Collider CrouchCollider;
    public Collider ProneCollider;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    //Varriables for Crouch and Prone
    private bool IsStanding = true;
    private bool IsCrouched = false;
    private bool IsProne = false;
    public bool HuntMode = true;
    public bool ManageMode = false;

    //Varriables for Peaking
    private bool IsPeakingLeft = false;
    private bool IsPeakingRight = false;
    private bool PeakIdle = true;
    
    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    void Update()
    {

        //Crouch Movement

        if (Input.GetKeyDown(KeyCode.LeftControl)&& IsStanding == true && HuntMode == true)
        {
            PlayerCollider.enabled = false;
            CrouchCollider.enabled = true;
            ProneCollider.enabled = false;

            Vector3 CamMove = new Vector3(0.0f, -0.55f, 0.0f);
            playerCam.transform.Translate(CamMove);

            IsStanding = false;
            IsCrouched = true;
            IsProne = false;

        }
        else if (Input.GetKeyDown(KeyCode.LeftControl)&& IsCrouched == true && HuntMode == true)
        {
            Vector3 CamMove = new Vector3(0.0f, 0.55f, 0.0f);
            playerCam.transform.Translate(CamMove);

            IsCrouched = false;
            IsStanding = true;
            IsProne = false;
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl)&& IsProne == true && HuntMode == true)
        {
            Vector3 CamMove = new Vector3(0.0f, 0.55f, 0.0f);
            playerCam.transform.Translate(CamMove);

            IsCrouched = true;
            IsProne = false;
            IsStanding = false;
        }

        
        //Prone Movement

        if (Input.GetKeyDown(KeyCode.Z)&& IsStanding == true && HuntMode == true)
        {
            PlayerCollider.enabled = false;
            CrouchCollider.enabled = false;
            ProneCollider.enabled = true;

            Vector3 CamMove = new Vector3(0.0f, -1.1f, 0.0f);
            playerCam.transform.Translate(CamMove);

            IsProne = true;
            IsCrouched = false;
            IsStanding = false;
        }
        else if (Input.GetKeyDown(KeyCode.Z)&& IsCrouched == true && HuntMode == true)
        {
            Vector3 CamMove = new Vector3(0.0f, -0.55f, 0.0f);
            playerCam.transform.Translate(CamMove);

            IsProne = true;
            IsCrouched = false;
            IsStanding = false;
        }
          else if (Input.GetKeyDown(KeyCode.Z)&& IsProne == true && HuntMode == true)
        {
            Vector3 CamMove = new Vector3(0.0f, 1.1f, 0.0f);
            playerCam.transform.Translate(CamMove);
            IsProne = false;
            IsCrouched = false;
            IsStanding = true;
        }
        
       
        

      //Return to standing from Crouched or Prone

        
        if (Input.GetKeyDown(KeyCode.Space)&& IsCrouched == true && HuntMode == true)
        {
            PlayerCollider.enabled = true;
            CrouchCollider.enabled = false;
            ProneCollider.enabled = false;

            Vector3 CamMove = new Vector3(0.0f, 0.55f, 0.0f);
            playerCam.transform.Translate(CamMove);

            IsCrouched = false;
            IsStanding = true;
            IsProne = false;
        } 
        else if (Input.GetKeyDown(KeyCode.Space)&& IsProne == true && HuntMode == true)
        {
            Vector3 CamMove = new Vector3(0.0f, 1.1f, 0.0f);
            playerCam.transform.Translate(CamMove);
            IsProne = false;
            IsCrouched = false;
            IsStanding = true;
        }
        

        //RTS vs FPS camera switcher

        if (Input.GetKeyDown(KeyCode.M) && HuntMode == true)
        {   
            HuntMode = false;
            Cursor.visible = true;
            managerCamera.enabled = true;
            playerCamera.enabled = false;
            ManageMode = true;

        }
        else if (Input.GetKeyDown(KeyCode.M) && HuntMode == false)
        {
            HuntMode = true;
            Cursor.visible = false;
            managerCamera.enabled = false;
            playerCamera.enabled = true;
            ManageMode = false;
        }

        //Lean player left and right

        //Idle to left lean
        if (Input.GetKeyDown(KeyCode.Q) && PeakIdle == true)
        {
            Vector3 CamMove = new Vector3(-0.5f, 0.0f, 0.0f);
            playerCam.transform.Translate(CamMove);

            playerCam.transform.rotation = new Quaternion(-30,0, 0, 0);
            
            IsPeakingLeft = true;
            IsPeakingRight = false;
            PeakIdle = false;
            
        } 
        //Idle to right lean
        else if (Input.GetKeyDown(KeyCode.E) && PeakIdle == true)
        {
            Vector3 CamMove = new Vector3(0.5f, 0.0f, 0.0f);
            playerCam.transform.Translate(CamMove);
            playerCam.transform.rotation = Quaternion.Euler(new Vector3(0,45,0));

            IsPeakingLeft = false;
            IsPeakingRight = true;
            PeakIdle = false;
        }
        //Left to Idle lean
        else if (Input.GetKeyDown(KeyCode.E) && IsPeakingLeft == true)
        {
            Vector3 CamMove = new Vector3(0.5f, 0.0f, 0.0f);
            playerCam.transform.Translate(CamMove);
            
            IsPeakingLeft = false;
            IsPeakingRight = false;
            PeakIdle = true;
        }
        //Left to Idle lean #2
        else if (Input.GetKeyDown(KeyCode.Q) && IsPeakingLeft == true)
        {
            Vector3 CamMove = new Vector3(0.5f, 0.0f, 0.0f);
            playerCam.transform.Translate(CamMove);

            IsPeakingLeft = false;
            IsPeakingRight = false;
            PeakIdle = true;
        }
        //Right to Idle lean
        else if (Input.GetKeyDown(KeyCode.Q) && IsPeakingRight == true)
        {
            Vector3 CamMove = new Vector3(-0.5f, 0.0f, 0.0f);
            playerCam.transform.Translate(CamMove);

            IsPeakingLeft = false;
            IsPeakingRight = false;
            PeakIdle = true;
        }
        //Right to Idle lean #2
        else if (Input.GetKeyDown(KeyCode.E) && IsPeakingRight == true)
        {
            Vector3 CamMove = new Vector3(-0.5f, 0.0f, 0.0f);
            playerCam.transform.Translate(CamMove);
            

            IsPeakingLeft = false;
            IsPeakingRight = false;
            PeakIdle = true;
        }


        //I love you. <3 - Trout
        //I love you too.


        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);


                        
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded && HuntMode == true)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded && HuntMode == true)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove && HuntMode == true)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    
    }

}