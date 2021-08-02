using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the legacy code for the eagles movement, it is no longer relevant and can be removed at any time
/// </summary>

public class Glider : MonoBehaviour
{
    //LEGACY CODE, only refrenced by the old eagle, once deleted, ensure that the reference from the old eagle is also subsequently borken
    static float EAGLE_START_X = 0;
    static float EAGLE_START_Y = 10;
    static float EAGLE_START_Z = 0;

    //Get eagle body
    public GameObject eBody;
    Transform eTrans;
    Renderer eRend;

    //Define simple physics calcs
    float X_accel, X_spd, Z_accel, Z_spd;

    // Start is called before the first frame update
    void Start(){
        //Set appropriate references
        eTrans = eBody.GetComponent<Transform>();
        eRend = eBody.GetComponent<Renderer>();

        //Set Eagle to Test Altitude
        eTrans.position = new Vector3(EAGLE_START_X, EAGLE_START_Y, EAGLE_START_Z);

        //Change Eagle color to something obnoxious
        eRend.material.color = Color.red;

        //Prep physics vars
        X_accel = 0;;
        X_spd = 0;

        Z_accel = 0;
        Z_spd = 0;
    }

    // Update is called once per frame
    void Update(){
        //This movement system is not terribly efficient... TOO BAD!
        //Pressed Keys
        if (Input.GetKey(KeyCode.W)){
            Debug.Log("Hit Up");
            if(Z_accel < 1.0f){
                Z_accel += 0.5f;
            }
        }

        else if (Input.GetKey(KeyCode.A)){
            Debug.Log("Hit Left");
            if(X_accel > -1.0f){
                X_accel -= 0.5f;
            }
        }

        else if (Input.GetKey(KeyCode.S)){
            Debug.Log("Hit Down");
            if (Z_accel > -1.0f){
                Z_accel -= 0.5f;
            }
        }

        else if (Input.GetKey(KeyCode.D)){
            Debug.Log("Hit Right");
            if (X_accel < 1.0f){
                X_accel += 0.5f;
            }
        }

        //Do physics
        //Add accel to speed
        if(X_accel != 0) { X_spd += X_accel; }
        if(Z_accel != 0) { Z_spd += Z_accel; }
        
        //Affect Position with speed (Drunk code)
        if(X_spd != 0) {
            //Get current position
            Vector3 currPos = eBody.GetComponent<Transform>().position;

            //Add by offset
            currPos.x += X_spd * Time.deltaTime;

            //Set new position to account for offset
            eBody.GetComponent<Transform>().position = currPos;
        }

        if(Z_spd != 0){
            Vector3 currPos = eBody.GetComponent<Transform>().position;

            //Add by offset
            currPos.z += Z_spd * Time.deltaTime;

            //Set new position to account for offset
            eBody.GetComponent<Transform>().position = currPos;
        }

        //Remove accel and spd to make sure that Eagle doesn't float forever
        if (X_accel > 0) { X_accel -= 0.25f; }
        else if (X_accel < 0) { X_accel += 0.25f; }

        if (Z_accel > 0) { Z_accel -= 0.25f; }
        else if (Z_accel < 0) { Z_accel += 0.25f; }

        if(X_spd > 0) { X_spd -= 0.25f; }
        else if (X_spd < 0) { X_spd += 0.25f; }

        if(Z_spd > 0) { Z_spd -= 0.25f; }
        else if (Z_spd > 0) { Z_spd += 0.25f; }
    }
}
