using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ChangeHuntMode : MonoBehaviour
{
    [SerializeField] GameObject reference;
    [SerializeField] PostProcessVolume volReference;
    [SerializeField] PostProcessProfile profileReference;
    
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.T))
        {
            bool mode = reference.GetComponent<Huntable>().isnormalMode;
            reference.GetComponent<Huntable>().isnormalMode = !mode;
            reference.GetComponent<Huntable>().modeSwitch();

            ColorGrading cg = null;

            profileReference.TryGetSettings<ColorGrading>(out cg);

            if (mode)
            {
                // currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
                cg.lift.value = Vector4.Lerp(cg.lift.value, new Vector4(-1, -1, -1, -1), 10);
                //cg.lift.value = new Vector4(-1, -1, -1, -1);
                cg.gamma.value = new Vector4(-1, -1, -1, -1);

            }
            else
            {
                cg.lift.value = Vector4.zero;
                cg.gamma.value = Vector4.zero;

            }
            

        }


    }
}
