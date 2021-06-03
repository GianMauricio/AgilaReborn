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

    // Start is called before the first frame update
    void Start()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        AITarget = BirbTarget.gameObject.transform.position;
        moveTimer += Time.deltaTime;

        //Get current range and make bang bang based on distance
        Vector3 currPos = gameObject.transform.position;
        Vector3 targetPos = gameObject.transform.position;

        fireRate -= Time.deltaTime;

        CrossHair.transform.LookAt(BirbTarget.transform.position);

        if(Vector3.Distance(currPos, targetPos) < rangeLimit && fireRate <= 0.0)
        {
            GameObject BulletClone = Instantiate(bullet, CrossHair.transform.position,
                                                     CrossHair.transform.rotation);

            BulletClone.transform.LookAt(BirbTarget.transform.position);

            BulletClone.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 3000);
            fireRate = 5.0f;
        }

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

    void newTarget()
    {
        NavMeshHit hit;
        NavMesh.SamplePosition(AITarget, out hit, 1000, NavMesh.AllAreas);
        Vector3 meshLoc = hit.position;

        nav.SetDestination(meshLoc);
    }
}
