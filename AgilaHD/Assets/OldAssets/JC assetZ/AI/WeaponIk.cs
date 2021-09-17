using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponIk : MonoBehaviour
{
    public Transform targetTransform;
    public Transform aimTransform; //raycast node
    public Transform initTransform; //forward object
    public Transform eagleTransform;
    public Transform hand;

    public int iterations = 10;

    [Range(0,1)]
    public float weight = 1.0f;

    public Transform[] main_bones;

    public float angleLimit = 90;
    public float distanceLimit = 1;


    public float rotationSpeed = 0.1f;
    public float positionSpeed = 0.1f;
    public bool shootMode = false;

    //particle system
    public GameObject muzzleFlash;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(targetTransform == null || aimTransform == null)
        {
            return;
        }

        if (!shootMode)
        {
            SetTargetTransform(initTransform);
        }
        else
        {
            SetTargetTransform(eagleTransform);
        }

        Vector3 targetPosition = GetTargetPosition();
        for (int i = 0; i< iterations; i++)
        {
            for(int b = 0; b < main_bones.Length; b++)
            {
                Transform bone = main_bones[b];
                AimAtTarget(bone, targetPosition, weight);
            }
            
        }
       
    }

    Vector3 GetTargetPosition()
    {
        Vector3 aimDirection = aimTransform.forward;
        //Vector3 targetDirection = targetPosition - aimTransform.position;
        Vector3 targetDirection = (targetTransform.position - aimTransform.position);
        float blendOut = 0.0f;

        float targetAngle = Vector3.Angle(targetDirection, aimDirection);
        //float nice = Mathf.Rad2Deg * Vector3.Dot(aimDirection, targetDirection);
        
        
        //Debug.Log("Target angle : " + targetAngle + "Dot :" + nice);
        if (targetAngle > angleLimit)
        {
            blendOut += (targetAngle - angleLimit) / 50.0f;
        }

        float targetDistance = targetDirection.magnitude;
        if(targetDistance < distanceLimit)
        {
            blendOut += distanceLimit - targetDistance;
        }

       

        Vector3 direction = Vector3.Slerp(targetDirection, aimDirection, blendOut);
        

        return aimTransform.position + direction;
    }
    private void AimAtTarget(Transform bone, Vector3 targetPosition, float weight)
    {
        
        Vector3 aimDirection = aimTransform.forward;
        //Vector3 targetDirection = targetPosition - aimTransform.position;
        Vector3 targetDirection = (targetPosition - aimTransform.position);//Vector3.Normalize

        Quaternion aimTowards = Quaternion.FromToRotation(aimDirection, targetDirection);
        Quaternion blendedRotation = Quaternion.Slerp(Quaternion.identity, aimTowards, weight);
        bone.rotation = aimTowards * bone.rotation;

        //Debug.Log("target position vector: " + targetPosition);
        //Vector3 nice = aimTransform.position + targetDirection;
        //Debug.Log("Computed direction + raycast position: " + nice );
    }

    public void SetTargetTransform(Transform target)
    {
        //lerp me
        targetTransform.position = Vector3.Lerp(targetTransform.position, target.position, Time.deltaTime * rotationSpeed);
        targetTransform.rotation = Quaternion.Lerp(targetTransform.rotation, target.rotation, Time.deltaTime * positionSpeed);
        //targetTransform = target;
    }


    public void SetAimTransform(Transform aim)
    {
        aimTransform = aim;
    }

    public void setShootMode(bool mode)
    {
        shootMode = mode;
        

    }

    public void playMuzzleFlash()
    {
        Vector3 p1 = aimTransform.position;
        Vector3 p2 = targetTransform.position;
        Vector3 dir = p2 - p1;
        Vector3 aimDir = p1 + dir;
        Vector3 one = Vector3.one;
        Vector3 aimDirection = aimTransform.forward;
        Quaternion rot = Quaternion.FromToRotation(aimDirection, dir);

        //var poof = GameObject.Instantiate(muzzleFlash, aimTransform.position, rot);
        var poof = GameObject.Instantiate(muzzleFlash, aimTransform.position, hand.rotation);
        var wee = GameObject.Instantiate(bullet, aimTransform.position, aimTransform.rotation);
    }
}
