using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ProgressionSystem : MonoBehaviour
{
    public int objectives = 1;

    [Header("Timer Stuff")]
    public TextMeshProUGUI Timer;
    public float maxTime = 600000.0f;
    public float TimeElapsed;
    bool isPaused = false;

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

    public int avgFrameRate;
    public Text display_Text;


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

        //Set up progresses to 0 / max
        Progress1.SetText(current1.ToString() + "/" + Total1.ToString());
        Progress2.SetText(current2.ToString() + "/" + Total2.ToString());
        Progress3.SetText(current3.ToString() + "/" + Total3.ToString());

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
        float current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;
        display_Text.text = avgFrameRate.ToString() + " FPS";

        //Timer
        //increase time elapsed
        if (!isPaused)
        {
            TimeElapsed += Time.deltaTime;
        }

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
        if(timeRemaining <= 0)
        {
            SceneManager.LoadScene("GameLost");
        }
    }

    //Update the objectives list with a tag of the object requested
    public void updateObjectives(string objectTag)
    {
        //If the object tag matches target 1...
        if (Target1.CompareTag(objectTag))
        {
            if(current1 < Total1)
            {
                current1++;
            }

            //Update objective 1 UI
            Progress1.SetText(current1.ToString() + "/" + Total1.ToString());

            //Change UI text if objective is complete
            if(current1 >= Total1)
            {
                Progress1.color = Color.green;
            }
        }

        else if (objectives > 1  && Target2.CompareTag(objectTag))
        {
            if (current2 < Total2)
            {
                current2++;
            }

            //Update objective 1 UI
            Progress2.SetText(current2.ToString() + "/" + Total2.ToString());

            //Change UI text if objective is complete
            if (current2 >= Total2)
            {
                Progress2.color = Color.green;
            }
        }

        else if (objectives > 2 && Target3.CompareTag(objectTag))
        {
            if (current3 < Total3)
            {
                current3++;
            }

            //Update objective 1 UI
            Progress3.SetText(current3.ToString() + "/" + Total3.ToString());

            //Change UI text if objective is complete
            if (current3 >= Total3)
            {
                Progress3.color = Color.green;
            }
        }

        //Check if all objectives have been met
        if(objectives == 1)
        {
            if(current1 >= Total1)
            {
                SceneManager.LoadScene("GameWon");
            }
        }

        else if (objectives == 2)
        {
            if (current1 >= Total1 && current2 >= Total2)
            {
                SceneManager.LoadScene("GameWon");
            }
        }

        else if (objectives == 3)
        {
            if (current1 >= Total1 && current2 >= Total2 && current3 >= Total3)
            {
                SceneManager.LoadScene("GameWon");
            }
        }
    }

    //Declare paused/unpause
    public void Pause()
    {
        isPaused = true;
    }

    public void Unpause()
    {
        isPaused = false;
    }
}
