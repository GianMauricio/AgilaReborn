using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponIk : MonoBehaviour
{
    public enum GunType { SHOTGUN, RIFLE};
    public GunType type = GunType.RIFLE;
    public Transform targetTransform;
    public Transform aimTransform; //raycast node
    public Transform initTransform; //forward object
    public Transform eagleTransform;
    public Transform hand;
    public AudioSource Shoot;

    public int iterations = 10;

    [Range(0,1)]
    public float weight = 1.0f;

    public Transform[] main_bones;

    public float angleLimit = 90;
    public float distanceLimit = 1;

    public float rotationSpeed = 0.1f;
    public float positionSpeed = 0.1f;
    public bool shootMode = false;

    //Shooting
    private float minHitChance = 0.0f;
    private int damage = 10;
    private float maxRange = 0.0f;

    //particle system
    public GameObject muzzleFlash;
    public GameObject bullet;

    private void Start()
    {
        
        if(type == GunType.RIFLE)
        {
            damage = 35;
            maxRange = 90f;
            minHitChance = 30.0f;
        }

        else if(type == GunType.SHOTGUN)
        {
            damage = 50;
            maxRange = 77.5f;
            minHitChance = 10.0f;
        }

        positionSpeed = 11.0f;
        rotationSpeed = 11.0f;
        distanceLimit = 2.5f;
        angleLimit = 100;

        main_bones = new Transform[2];
       // main_bones[0] = this.gameObject.transform.Find("mixamorig:Hips").transform.Find("mixamorig:Spine").transform.Find("mixamorig:Spine1").transform;
        main_bones[0] = this.gameObject.transform.Find("mixamorig:Hips").transform.Find("mixamorig:Spine").transform.Find("mixamorig:Spine1").transform.Find("mixamorig:Spine2").transform;//.transform.Find("mixamorig:Spine1").transform.Find("mixamorig:Spine2").transform
        main_bones[1] = this.gameObject.transform.Find("mixamorig:Hips").transform.Find("mixamorig:Spine").transform.Find("mixamorig:Spine1").transform.Find("mixamorig:Spine2").transform.Find("mixamorig:Neck").transform;

        Vector3 forw = this.gameObject.transform.position;
        Vector3 dir;
        dir = this.gameObject.transform.forward;
        float length = 9.0f;
        Vector3 finalpos = forw + dir * length;
        finalpos.y += 9;
        initTransform.position = finalpos;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        eagleTransform = this.gameObject.GetComponent<AiAgent>().eagleReference.transform;
        if (main_bones[0] == null)
        {
            Debug.LogWarning("null main bones reference");
        }

        if (targetTransform == null || aimTransform == null)
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

    //This function handles the shooting
    public void playMuzzleFlash()
    {
        Vector3 p1 = aimTransform.position;
        Vector3 p2 = targetTransform.position;
        Vector3 dir = p2 - p1;
        Vector3 aimDir = p1 + dir;
        Vector3 one = Vector3.one;
        Vector3 aimDirection = aimTransform.forward;
        Quaternion rot = Quaternion.FromToRotation(aimDirection, dir);

        //Play sound regardless of hit result
        Shoot.Play();

        //Cointoss for damage taking into account distance of Eagle
        //Calculate distance of hunter to eagle
        float dist = Vector3.Distance(transform.position, eagleTransform.position);

        //Convert to percent chance
        //Debug.Log("Eagle detected: " + dist);

        //Change depending on gun type here
        float chanceToHit = ((maxRange - dist) / maxRange) * 100;
        bool contact = false;

        //Add or remove hit chance based on speed
        float moreHitChance;

        //Almost still
        if(eagleTransform.gameObject.GetComponent<BirdMainScript>().current_speed < 5.0f)
        {
            moreHitChance = 20.0f;
        }
        
        else if(eagleTransform.gameObject.GetComponent<BirdMainScript>().current_speed < 27.5f)
        {
            moreHitChance = 5.0f;
        }

        //More than half speed
        else
        {
            moreHitChance = -10.0f;
        }

        chanceToHit += moreHitChance;

        //Always has a chance to hit
        if(chanceToHit < minHitChance)
        {
            chanceToHit = minHitChance;

            float tryHit = Random.Range(0, 100);

            if(tryHit < chanceToHit)
            {
                contact = true;
            }
        }

        //Hit guranteed
        else if(chanceToHit > 100)
        {
            eagleTransform.gameObject.GetComponent<BirdMainScript>().Hurt(damage);
        }

        //Do hit calculations
        else
        {
            float tryHit = Random.Range(0, 100);

            if (tryHit < chanceToHit)
            {
                contact = true;
            }
        }

        //Call only when bullet is launched
        if (contact) //Simulate hit
        {
            //If the gun is the rifle, then use full damage
            if(type == GunType.RIFLE)
            {
                eagleTransform.gameObject.GetComponent<BirdMainScript>().Hurt(damage);

                //var poof = GameObject.Instantiate(muzzleFlash, aimTransform.position, aimTransform.rotation);
                //var wee = GameObject.Instantiate(bullet, aimTransform.position, aimTransform.rotation);

                Instantiate(muzzleFlash, aimTransform.position, aimTransform.rotation); /*Flash!*/
                Instantiate(bullet, aimTransform.position, aimTransform.rotation); /*Bang!*/
            }
            
            //If the gun is the shotgun, impose penalties via distance
            else if(type == GunType.SHOTGUN)
            {
                //The closer the better
                int finalDamage = Mathf.FloorToInt(damage * ((dist + 2) / 100));

                //Min damage
                if(finalDamage < 20)
                {
                    finalDamage = 20;
                }

                eagleTransform.gameObject.GetComponent<BirdMainScript>().Hurt(finalDamage);

                //Add more muzzle flashes to the shotguns
                Instantiate(muzzleFlash, aimTransform.position, aimTransform.rotation);/*Flash*/
                Instantiate(muzzleFlash, aimTransform.position, aimTransform.rotation);/*Flash*/
                Instantiate(muzzleFlash, aimTransform.position, aimTransform.rotation);/*Flash*/

                Instantiate(bullet, aimTransform.position, aimTransform.rotation);/*Bang*/
            }

            //var poof = GameObject.Instantiate(muzzleFlash, aimTransform.position, rot);
            //var poof = GameObject.Instantiate(muzzleFlash, aimTransform.position, aimTransform.rotation);
            //var wee = GameObject.Instantiate(bullet, aimTransform.position, aimTransform.rotation);
        }

        else //Simulate Miss
        {
            //Add more muzzle to the shotguns
            Instantiate(muzzleFlash, aimTransform.position, aimTransform.rotation); /*Flash*/
            Instantiate(muzzleFlash, aimTransform.position, aimTransform.rotation);/*Flash*/
            Instantiate(muzzleFlash, aimTransform.position, aimTransform.rotation);/*Flash*/
            

            //Debug.Log("Miss");
        }
    }
}
