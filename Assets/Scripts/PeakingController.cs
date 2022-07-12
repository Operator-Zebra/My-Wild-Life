using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Still needs to take input of If huntmode == true!

public class PeakingController : MonoBehaviour
{
    public Transform PeakLeft;
    public Transform PeakRight;
    public Transform Idle;
    public Transform CrouchPeakLeft;
    public Transform CrouchPeakRight;
    public Transform CrouchIdle;
    public Transform PronePeakLeft;
    public Transform PronePeakRight;
    public Transform ProneIdle;

    private bool IsStanding = true;
    private bool IsCrouched = false;
    private bool IsProne = false;

    public float lerpTime = 0.15f;

    void Update()
    {
            if (Input.GetKeyDown(KeyCode.LeftControl)&& IsStanding == true)
            {
                IsStanding = false;
                IsCrouched = true;
                IsProne = false;

            }
            else if (Input.GetKeyDown(KeyCode.LeftControl)&& IsCrouched == true)
            {
                IsCrouched = false;
                IsStanding = true;
                IsProne = false;
            }
            else if (Input.GetKeyDown(KeyCode.LeftControl)&& IsProne == true)
            {
                IsCrouched = true;
                IsProne = false;
                IsStanding = false;
            }

            if (Input.GetKeyDown(KeyCode.Z)&& IsStanding == true)
            {
                IsProne = true;
                IsCrouched = false;
                IsStanding = false;
            }
            else if (Input.GetKeyDown(KeyCode.Z)&& IsCrouched == true)
            {
                IsProne = true;
                IsCrouched = false;
                IsStanding = false;
            }
            else if (Input.GetKeyDown(KeyCode.Z)&& IsProne == true)
            {
                IsProne = false;
                IsCrouched = false;
                IsStanding = true;
            }
            
        //Return to standing from Crouched or Prone
            
            if (Input.GetKeyDown(KeyCode.Space)&& IsCrouched == true)
            {
                IsCrouched = false;
                IsStanding = true;
                IsProne = false;
            } 
            else if (Input.GetKeyDown(KeyCode.Space)&& IsProne == true)
            {

                IsProne = false;
                IsCrouched = false;
                IsStanding = true;
            }
    }

    //Standing Controls 100% WORKING!
    void LateUpdate()
    {
        if (IsStanding == true)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                transform.position = Vector3.Lerp(transform.position, PeakLeft.position, lerpTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, PeakLeft.rotation, lerpTime);
            }
            else if (Input.GetKey(KeyCode.E))
            {
                transform.position = Vector3.Lerp(transform.position, PeakRight.position, lerpTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, PeakRight.rotation, lerpTime);
            }
            else {
                transform.position = Vector3.Lerp(transform.position, Idle.position, lerpTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, Idle.rotation, lerpTime);
            }

            
            
        }

        //Crouching Controls 100% WORKING!
        if (IsCrouched == true)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                transform.position = Vector3.Lerp(transform.position, CrouchPeakLeft.position, lerpTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, CrouchPeakLeft.rotation, lerpTime);
            }
            else if (Input.GetKey(KeyCode.E))
            {
                transform.position = Vector3.Lerp(transform.position, CrouchPeakRight.position, lerpTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, CrouchPeakRight.rotation, lerpTime);
            }
            else {
                transform.position = Vector3.Lerp(transform.position, CrouchIdle.position, lerpTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, CrouchIdle.rotation, lerpTime);
            }
        }

        // Proneing Controls 100% WORKING!
        if (IsProne == true)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                transform.position = Vector3.Lerp(transform.position, PronePeakLeft.position, lerpTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, PronePeakLeft.rotation, lerpTime);
            }
            else if (Input.GetKey(KeyCode.E))
            {
                transform.position = Vector3.Lerp(transform.position, PronePeakRight.position, lerpTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, PronePeakRight.rotation, lerpTime);
            }
            else {
                transform.position = Vector3.Lerp(transform.position, ProneIdle.position, lerpTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, ProneIdle.rotation, lerpTime);
            }
        }
    }
}