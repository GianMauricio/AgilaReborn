using UnityEngine;
using System.Collections.Generic;

public class ThirdPersonCamera : MonoBehaviour
{
    //to rotate around the player
    public Transform target;
    public float dstFromTarget = 2;

    //add constraints para di sumobra yung pag rotate
    //public float maxPitch = -10, minPitch = 85; //-10,85 ishh??
    public Vector2 pitchMinMax; /*= new Vector2(minPitch, maxPitch);*/
    public Vector2 yawMinMax;

    //get inputs
    public float yaw;
    public float pitch;
    public float yawRotation;
    public float lastYaw =0;
    public float mouseSensitivity = 10f;

    //Smoothing
    public float rotationSmoothTime = 1.2f;

    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;
     
    public Vector3 initialPosition;

    public bool moveleft = false;
    public bool moveright = false;
    private bool isPaused = false;


    [SerializeField] bool cursorLock;
    private void Start()
    {
        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        Vector3 startPosition = initialPosition;
        transform.position = initialPosition;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (!isPaused)
        {
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;

            //to limit rotation
            pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

            if (Input.GetAxis("Mouse X") < 0)
            {
                //Code for action on mouse moving left
                //    Debug.Log("Left");
                moveleft = true;
                moveright = false;
            }
            else if (Input.GetAxis("Mouse X") > 0)
            {
                //Code for action on mouse moving right
                //   Debug.Log("Right");
                moveleft = false;
                moveright = true;
            }
            else
            {
                //    Debug.Log("IDLE");
                moveleft = false;
                moveright = false;
            }


            //yaw = Mathf.Clamp(yaw, yawMinMax.x, yawMinMax.y);
            //Debug.LogWarning(yawRotation);

            //rotation smoothing
            //public static Vector3 SmoothDamp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed = Mathf.Infinity, float deltaTime = Time.deltaTime);
            currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);

            //to move the camera without smoothing

            //Vector3 targetRotation = new Vector3(pitch, yaw);
            //transform.eulerAngles = targetRotation; use if walang smoothing
            transform.eulerAngles = currentRotation;


            //to rotate around the player
            //take this off then oks ka na sa fps controls lmao
            transform.position = target.position - transform.forward * dstFromTarget;
        }
    }

    public void Pause()
    {
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Unpause()
    {
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
