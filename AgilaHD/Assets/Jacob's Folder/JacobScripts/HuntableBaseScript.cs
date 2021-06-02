using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/*
 Concerned with Movement and Health of the Huntables will probably also have other behaviour in the future
 
 
 */
public class HuntableBaseScript : MonoBehaviour
{
    [SerializeField] int Health;

    public float timer;

    public int TimeToMove; 

    public float speed;

    public NavMeshAgent nav;

    public Vector3 Target;

    // Start is called before the first frame update
    void Start()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= TimeToMove)
        {
            newTarget();
            timer = 0;
        }
       
    }

    void newTarget()
    {
        float myX = gameObject.transform.position.x;
        float myZ = gameObject.transform.position.z;

        float xPos = myX + Random.Range(myX - 20, myX + 20);
        float ZPos = myZ + Random.Range(myZ - 20, myZ + 20);

        Target = new Vector3(xPos, gameObject.transform.position.y, ZPos);

        nav.SetDestination(Target);
    }
}
