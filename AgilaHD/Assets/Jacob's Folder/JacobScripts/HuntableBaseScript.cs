using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntableBaseScript : MonoBehaviour
{
    [SerializeField] int Health;
    private bool movingLeft = false;
    private bool movingRight = false;
    private bool movingUp = false;
    private bool movingDown = false;

    private float movementTime;
    // Start is called before the first frame update
    void Start()
    {
        movementTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        while (movementTime < 5.0f)
        {
            int random = Random.Range(0, 4);
            Debug.Log(random);

           
            switch (random)
            {
                case 0:
                    movingLeft = true;
                    movingRight = false;
                    movingUp = false;
                    movingDown = false;
                    break;
                case 1:
                    movingLeft = true;
                    movingRight = false;
                    movingUp = false;
                    movingDown = false;
                    break;
                case 2:
                    movingLeft = true;
                    movingRight = false;
                    movingUp = false;
                    movingDown = false;
                    break;
                case 3:
                    movingLeft = true;
                    movingRight = false;
                    movingUp = false;
                    movingDown = false;
                    break;
                default:
                    movingLeft = false;
                    movingRight = false;
                    movingUp = false;
                    movingDown = false;
                    break;
            } //Decides which direction huntable will be moving in

            movementTime += Time.deltaTime;

            if (movingLeft == true)
            {
                //transform.position -= new Vector3(0, 0, 0.001f);
            }
            if (movingRight == true)
            {
                //transform.position += new Vector3(0, 0, 0.001f);
            }

            if (movingUp == true)
            {
                transform.position += new Vector3(0.1f, 0,0);
            }

            if (movingDown == true)
            {
                transform.position -= new Vector3(0.1f, 0, 0);
            }


            //Debug.Log(movementTime);

        }
        Debug.Log("I GOT OUT");
        movementTime = 0.0f;

    }
}
