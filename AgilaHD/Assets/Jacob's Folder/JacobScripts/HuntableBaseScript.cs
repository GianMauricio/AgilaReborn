using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/*
 Concerned with Movement and Health of the Huntables will probably also have other behaviour in the future
 
 
 */
public class HuntableBaseScript : MonoBehaviour
{
    [SerializeField] int Health = 1;
    private float timer;
    private float jumpTime = 0;

    public int TimeUntilMove;
    public int bounceInterval = 3;

    public float speed;

    public NavMeshAgent nav;

    public Vector3 Target;

    public float thrust = 1.0f;

    private float myX;
    private float myZ;

    bool isEaten;

    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
        myX = gameObject.transform.position.x;
        myZ = gameObject.transform.position.z;
        isEaten = false;

        rb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        jumpTime += Time.deltaTime;

        if(timer >= TimeUntilMove)
        {
            newTarget(); //Call newTarget until TimeUntilMove
            timer = 0;
        }

        
        if (jumpTime >= bounceInterval)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 100, ForceMode.Impulse);
            jumpTime = 0;
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

    public int giveHealth()
    {
        int addHealth = 1;

        return addHealth;
    }
}
