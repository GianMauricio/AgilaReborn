using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgressionSystem : MonoBehaviour
{
    public int objectives = 1;

    [Header("Timer Stuff")]
    public TextMeshProUGUI Timer;
    public float maxTime = 600000.0f;
    public float TimeElapsed;

    [Header("Objective 1 Data")]
    public GameObject Target1;
    public TextMeshProUGUI Header1;
    public TextMeshProUGUI Progress1;

    public int Total1;
    private int current1;

    [Header("Objective 2 Data")]
    public GameObject Target2;
    public TextMeshProUGUI Header2;
    public TextMeshProUGUI Progress2;

    public int Total2;
    private int current2;

    [Header("Objective 3 Data")]
    public GameObject Target3;
    public TextMeshProUGUI Header3;
    public TextMeshProUGUI Progress3;

    public int Total3;
    private int current3;

    // Start is called before the first frame update
    void Start()
    {
        //Make sure
        //all current objectives are 0'd out
        current1 = 0;
        current2 = 0;
        current3 = 0;

        //Timer is always visible
        Timer.gameObject.SetActive(true);

        //Edit visibility of objectives depending on the number in the level
        switch (objectives)
        {
            case 1:
                Header1.gameObject.SetActive(true);
                Progress1.gameObject.SetActive(true);

                //Set text vals ... don't question it
                if(Total1 > 1)
                {
                    if (Target1.CompareTag("Cage"))
                    {
                        Header1.SetText("Break " + Target1.tag + "s" + ":");
                    }

                    else
                    {
                        if (Target1.CompareTag("Bunny"))
                        {
                            string targetTag = Target1.tag;
                            string pluralizer = targetTag.Remove(targetTag.Length - 1);
                            pluralizer = pluralizer + "ies";
                            Header1.SetText("Hunt " + pluralizer + ":");
                        }
                        
                        else
                        {
                            Header1.SetText("Hunt " + Target1.tag + "s" + ":");
                        }
                    }
                }

                else
                {
                    if (Target1.CompareTag("Cage"))
                    {
                        Header1.SetText("Break " + Target1.tag + ":");
                    }

                    else
                    {
                        if (Target1.CompareTag("Bunny"))
                        {
                            string targetTag = Target1.tag;
                            string pluralizer = targetTag.Remove(targetTag.Length - 1);
                            pluralizer = pluralizer + "ies";
                            Header1.SetText("Hunt " + pluralizer + ":");
                        }

                        else
                        {
                            Header1.SetText("Hunt " + Target1.tag + "s" + ":");
                        }
                    }
                }

                Header2.gameObject.SetActive(false);
                Progress2.gameObject.SetActive(false);

                Header3.gameObject.SetActive(false);
                Progress3.gameObject.SetActive(false);
                break;

            case 2:
                Header1.gameObject.SetActive(true);
                Progress1.gameObject.SetActive(true);

                //Set text vals ... don't question it
                if (Total1 > 1)
                {
                    if (Target1.CompareTag("Cage"))
                    {
                        Header1.SetText("Break " + Target1.tag + "s" + ":");
                    }

                    else
                    {
                        if (Target1.CompareTag("Bunny"))
                        {
                            string targetTag = Target1.tag;
                            string pluralizer = targetTag.Remove(targetTag.Length - 1);
                            pluralizer = pluralizer + "ies";
                            Header1.SetText("Hunt " + pluralizer + ":");
                        }

                        else
                        {
                            Header1.SetText("Hunt " + Target1.tag + "s" + ":");
                        }
                    }
                }

                else
                {
                    if (Target1.CompareTag("Cage"))
                    {
                        Header1.SetText("Break " + Target1.tag + ":");
                    }

                    else
                    {
                        if (Target1.CompareTag("Bunny"))
                        {
                            string targetTag = Target1.tag;
                            string pluralizer = targetTag.Remove(targetTag.Length - 1);
                            pluralizer = pluralizer + "ies";
                            Header1.SetText("Hunt " + pluralizer + ":");
                        }

                        else
                        {
                            Header1.SetText("Hunt " + Target1.tag + "s" + ":");
                        }
                    }
                }

                Header2.gameObject.SetActive(true);
                Progress2.gameObject.SetActive(true);

                //Set text vals ... don't question it
                if (Total2 > 1)
                {
                    if (Target2.CompareTag("Cage"))
                    {
                        Header2.SetText("Break " + Target2.tag + "s" + ":");
                    }

                    else
                    {
                        if (Target2.CompareTag("Bunny"))
                        {
                            string targetTag = Target2.tag;
                            string pluralizer = targetTag.Remove(targetTag.Length - 1);
                            pluralizer = pluralizer + "ies";
                            Header2.SetText("Hunt " + pluralizer + ":");
                        }

                        else
                        {
                            Header2.SetText("Hunt " + Target2.tag + "s" + ":");
                        }
                    }
                }

                else
                {
                    if (Target2.CompareTag("Cage"))
                    {
                        Header2.SetText("Break " + Target2.tag + ":");
                    }

                    else
                    {
                        if (Target2.CompareTag("Bunny"))
                        {
                            string targetTag = Target2.tag;
                            string pluralizer = targetTag.Remove(targetTag.Length - 2);
                            pluralizer = pluralizer + "ies";
                            Header2.SetText("Hunt " + pluralizer + ":");
                        }

                        else
                        {
                            Header2.SetText("Hunt " + Target2.tag + "s" + ":");
                        }
                    }
                }

                Header3.gameObject.SetActive(false);
                Progress3.gameObject.SetActive(false);
                break;

            case 3:
                Header1.gameObject.SetActive(true);
                Progress1.gameObject.SetActive(true);

                //Set text vals ... don't question it
                if (Total1 > 1)
                {
                    if (Target1.CompareTag("Cage"))
                    {
                        Header1.SetText("Break " + Target1.tag + "s" + ":");
                    }

                    else
                    {
                        if (Target1.CompareTag("Bunny"))
                        {
                            string targetTag = Target1.tag;
                            string pluralizer = targetTag.Remove(targetTag.Length - 1);
                            pluralizer = pluralizer + "ies";
                            Header1.SetText("Hunt " + pluralizer + ":");
                        }

                        else
                        {
                            Header1.SetText("Hunt " + Target1.tag + "s" + ":");
                        }
                    }
                }

                else
                {
                    if (Target1.CompareTag("Cage"))
                    {
                        Header1.SetText("Break " + Target1.tag + ":");
                    }

                    else
                    {
                        if (Target1.CompareTag("Bunny"))
                        {
                            string targetTag = Target1.tag;
                            string pluralizer = targetTag.Remove(targetTag.Length - 1);
                            pluralizer = pluralizer + "ies";
                            Header1.SetText("Hunt " + pluralizer + ":");
                        }

                        else
                        {
                            Header1.SetText("Hunt " + Target1.tag + "s" + ":");
                        }
                    }
                }

                Header2.gameObject.SetActive(true);
                Progress2.gameObject.SetActive(true);

                //Set text vals ... don't question it
                if (Total2 > 1)
                {
                    if (Target2.CompareTag("Cage"))
                    {
                        Header2.SetText("Break " + Target2.tag + "s" + ":");
                    }

                    else
                    {
                        if (Target2.CompareTag("Bunny"))
                        {
                            string targetTag = Target2.tag;
                            string pluralizer = targetTag.Remove(targetTag.Length - 1);
                            pluralizer = pluralizer + "ies";
                            Header2.SetText("Hunt " + pluralizer + ":");
                        }

                        else
                        {
                            Header2.SetText("Hunt " + Target2.tag + "s" + ":");
                        }
                    }
                }

                else
                {
                    if (Target2.CompareTag("Cage"))
                    {
                        Header2.SetText("Break " + Target2.tag + ":");
                    }

                    else
                    {
                        if (Target2.CompareTag("Bunny"))
                        {
                            string targetTag = Target2.tag;
                            string pluralizer = targetTag.Remove(targetTag.Length - 2);
                            pluralizer = pluralizer + "ies";
                            Header2.SetText("Hunt " + pluralizer + ":");
                        }

                        else
                        {
                            Header2.SetText("Hunt " + Target2.tag + "s" + ":");
                        }
                    }
                }

                Header3.gameObject.SetActive(true);
                Progress3.gameObject.SetActive(true);

                //Set text vals ... don't question it
                if (Total3 > 1)
                {
                    if (Target3.CompareTag("Cage"))
                    {
                        Header3.SetText("Break " + Target3.tag + "s" + ":");
                    }

                    else
                    {
                        if (Target3.CompareTag("Bunny"))
                        {
                            string targetTag = Target3.tag;
                            string pluralizer = targetTag.Remove(targetTag.Length - 1);
                            pluralizer = pluralizer + "ies";
                            Header3.SetText("Hunt " + pluralizer + ":");
                        }

                        else
                        {
                            Header3.SetText("Hunt " + Target3.tag + "s" + ":");
                        }
                    }
                }

                else
                {
                    if (Target3.CompareTag("Cage"))
                    {
                        Header3.SetText("Break " + Target3.tag + ":");
                    }

                    else
                    {
                        if (Target3.CompareTag("Bunny"))
                        {
                            string targetTag = Target3.tag;
                            string pluralizer = targetTag.Remove(targetTag.Length - 3);
                            pluralizer = pluralizer + "ies";
                            Header3.SetText("Hunt " + pluralizer + ":");
                        }

                        else
                        {
                            Header3.SetText("Hunt " + Target3.tag + "s" + ":");
                        }
                    }
                }
                break;

            default:
                Debug.Log("Objective count " + objectives + " is unexpected");
                break;
        }

        
    }
    
    // Update is called once per frame
    void Update()
    {
        //Timer
        //increase time elapsed
        TimeElapsed += Time.deltaTime;

        float timeRemaining = maxTime - TimeElapsed;

        //Calculate seconds
        float seconds = timeRemaining % 60;

        //Round seconds to double decimal
        seconds = Mathf.Round(seconds);

        //Calculate minutes
        float minutes = timeRemaining / 60000;

        minutes = Mathf.Round(minutes);

        //Determine what the timer would display
        string timerString = "Time - " + minutes.ToString() + ":" + seconds.ToString();

        //Set the timer text
        Timer.SetText(timerString);

        //TODO:When timer runs out, load game over scene
    }

    //Update the objectives list with a tag of the object requested
    void updateObjectives(string objectTag)
    {
        //If the object tag matches target 1...
        if (Target1.CompareTag(objectTag))
        {
            current1++;

            //Update objective 1 UI


        }
    }
}
