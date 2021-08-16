using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Basic logic, the hunter will periodaically check if the bird is within range to enter "seek" mode
/// in seek mode the hunter will follow and aim at the bird. If the hunter is in seek mode, the hunter will periodically 
/// check if the bird is within a close enough range to shoot. If the bird is within the shooting range, then the hunter will 
/// switch to "hunt" mode. in Hunt mode, the hunter will stop moving completely and simply focus on shooting the bird.
/// </summary>

//Wander --> wander around aimlessly until you see the bird
//Seek --> actively attempt to follow and aim at bird
//Hunt --> Stay still and aim at bird

public enum HunterMode {Wander, Seek, Hunt}

public class HAI : MonoBehaviour
{
    //All hunters start in wander mode
    private HunterMode mode = HunterMode.Wander;

    [Header("ObjectReferences")]
    private GameObject BirbTarget;
    public GameObject bullet;
    public GameObject CrossHair;

    [Header("Behavior Params")]
    public float fireRate = 0.1f;
    public float seekLimit = 300.0f;
    public float huntLimit = 150.0f;
    public float resetTargetInterval = 5.0f;
    public float moveTimer = 0.0f;

    [Header("Wander Params")]
    public float xRadius = 5.0f;
    public float zRadius = 5.0f;

    void Start()
    {
    }

    void Update()
    {
        //Check what the current mode is
        switch (mode)
        {
            case HunterMode.Wander:
                //Randomize the next location to move
                float offsetX = Random.Range(-xRadius, xRadius);
                float offsetZ = Random.Range(-zRadius, zRadius);

                //set to vector without Y
                Vector3 nextTarget = new Vector3(transform.position.x + offsetX, transform.position.y, transform.position.z + offsetZ);


                break;

            case HunterMode.Seek:
                break;

            case HunterMode.Hunt:
                break;
        }

        //set agent to target the birbs location
        //AITarget = BirbTarget.gameObject.transform.position;

        //Offset move timer so the hunter doesn't home in on birb instantly
        moveTimer += Time.deltaTime;

        //Get current range and make bang bang based on distance
        Vector3 currPos = gameObject.transform.position;
        Vector3 targetPos = gameObject.transform.position;

        //reference firerate to make the hunter not fire full auto
        fireRate -= Time.deltaTime;

        //Make hunter bullet spawner face eagle
        CrossHair.transform.LookAt(BirbTarget.transform.position);

        //If the hunter has not moved in a while, allow movement
        if (moveTimer >= resetTargetInterval)
        {
            moveTimer = 0;
            //newTarget();
        }
    }

    public void Shoot()
    {
        //Create bullet
        GameObject BulletClone = Instantiate(bullet, CrossHair.transform.position,
                                                 CrossHair.transform.rotation);
        //Make bullet look at birb
        BulletClone.transform.LookAt(BirbTarget.transform.position);

        //YEET the bullet has hard as you can
        BulletClone.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 3000);
    }

    public void setTarget(GameObject newTarget)
    {
        BirbTarget = newTarget;
    }
}
