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

    private float timer;

    public int TimeUntilMove; 

    public float speed;

    public NavMeshAgent nav;

    public Vector3 Target;

    private float myX;
    private float myZ;

    bool isEaten;

    // Start is called before the first frame update
    void Start()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
        myX = gameObject.transform.position.x;
        myZ = gameObject.transform.position.z;
        isEaten = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= TimeUntilMove)
        {
            newTarget(); //Call newTarget until TimeUntilMove
            timer = 0;
        }
       
    }

    void newTarget()
    {
        


        float xPos = myX + Random.Range(myX - 20, myX + 20);


        float ZPos = myZ + Random.Range(myZ - 20, myZ + 20);

        Target = new Vector3(xPos, gameObject.transform.position.y, ZPos);

        nav.SetDestination(Target);
    }

    void gotEaten() //for when it gets eaten by player
    {


        gameObject.SetActive(false);
    }
}
