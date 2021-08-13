using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is responsible for controlling the birds animations
/// The values of this script are directly fed to it by the main script 
/// Any and all transition changes are handled internally, and all calls to
/// change the script must be handled via references to this script
/// </summary>
public class BirdAnimationHandler : MonoBehaviour
{
    //Animation
    public Animator animControl;

    private enum BIRDSTATE
    {
        flapping = 0,
        grabbing = 1,
        gliding = 2,
        enterDive = 3,
        diving = 4,
        exitDive = 5
    };

    BIRDSTATE birdState = BIRDSTATE.flapping;

    public float current_speed = 0;
    private float flapspeed = 0;

    // Update is called once per frame
    void Update()
    {
        //Always set new flapspeed at end of process
        animControl.SetFloat("flapSpeed", flapspeed);
    }

    public void SetFlapSpeed(float newFlapSpeed)
    {
        flapspeed = newFlapSpeed;
    }

    public void doFlap()
    {
        birdState = BIRDSTATE.flapping;
        animControl.SetInteger("birdState", (int)birdState);
    }

    public void doGrab()
    {
        birdState = BIRDSTATE.grabbing;
        animControl.SetInteger("birdState", (int)birdState);
    }

    public void startDive()
    {
        birdState = BIRDSTATE.enterDive;
        animControl.SetInteger("birdState", (int)birdState);
    }

    public void leaveDive()
    {
        birdState = BIRDSTATE.exitDive;
        animControl.SetInteger("birdState", (int)birdState);
    }
}
