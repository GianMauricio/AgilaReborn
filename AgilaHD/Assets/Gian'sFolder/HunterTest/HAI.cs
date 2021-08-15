using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Basic logic, the hunter will get the nearest point in the navmesh to the current location of the eagle and move towards it.
/// Every X time intervals the "nearest point" will change to update to the eagles current position
/// Once the hunter is within range, start shooting the birb
/// </summary>
public class HAI : MonoBehaviour
{
    private GameObject BirbTarget;
    public GameObject bullet;
    public GameObject CrossHair;
    private NavMeshAgent nav;


    private float fireRate = 0.1f;
    private float rangeLimit = 300.0f;
    private float resetTargetInterval = 5.0f;
    private float moveTimer = 0.0f;
    
    private Vector3 AITarget;

    void Start()
    {
        //Get the AI agent
        nav = gameObject.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //set agent to target the birbs location
        AITarget = BirbTarget.gameObject.transform.position;

        //Offset move timer so the hunter doesn't home in on birb instantly
        moveTimer += Time.deltaTime;

        //Get current range and make bang bang based on distance
        Vector3 currPos = gameObject.transform.position;
        Vector3 targetPos = gameObject.transform.position;

        //reference firerate to make the hunter not fire full auto
        fireRate -= Time.deltaTime;

        //Make hunter bullet spawner face eagle
        CrossHair.transform.LookAt(BirbTarget.transform.position);

        //if the Eagle is within "Cone of Sight" and the hunter has not fired in a while
        if(Vector3.Distance(currPos, targetPos) < rangeLimit && fireRate <= 0.0)
        {
            //Create bullet
            GameObject BulletClone = Instantiate(bullet, CrossHair.transform.position,
                                                     CrossHair.transform.rotation);

            //Make bullet look at birb
            BulletClone.transform.LookAt(BirbTarget.transform.position);

            //YEET the bullet has hard as you can
            BulletClone.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 3000);

            //Reset firerate
            fireRate = 5.0f;
        }

        //If the hunter has not moved in a while, allow movement
        if (moveTimer >= resetTargetInterval)
        {
            moveTimer = 0;
            newTarget();
        }
    }

    public void setTarget(GameObject newTarget)
    {
        BirbTarget = newTarget;
    }

    //Get nearest location on the nav mesh depending on a given target with a possible margin of error of 100
    void newTarget()
    {
        
        NavMeshHit hit;
        NavMesh.SamplePosition(AITarget, out hit, 100, NavMesh.AllAreas);
        Vector3 meshLoc = hit.position;

        //Tell agent to go to new target location
        nav.SetDestination(meshLoc);
    }
}
