using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script will animate the hunter ping UI
/// This will rely on the eagle camera being the only main camera that exists
/// </summary>
public class HunterVisionUI : MonoBehaviour
{
    public enum HuntState { ACTIVE, INACTIVE };
    public GameObject UIHolder;
    public Vector3 lockLocation;
    public Image Ping;
    public List<string> filePathsHold;
    public List<Sprite> imagesHold;
    public bool isPaused = false;

    private float frameChange = 0.01f;
    private float timeElapsed = 0.0f;
    private int currFrame = 0;

    public float ScalarMult = 1.0f;

    private float AxisMult = 1.0f;

    private float MultMax = 1.5f;
    private float MultMin = 0.1f;

    public HuntState state = HuntState.INACTIVE;

    // Start is called before the first frame update
    void Start()
    {
        lockLocation = Vector3.zero;
        //Ready frames file paths via resource folder
        for (int i = 2; i <= 91; i++)
        {
            //Sprite newSprite;
            string filePathPing;
            if (i < 10)
            {
                filePathPing = "HunterVision/Hunter_Vision__denoise_000" + i.ToString();
            }

            else
            {
                filePathPing = "HunterVision/Hunter_Vision__denoise_00" + i.ToString();
            }

            filePathsHold.Add(filePathPing);
        }

        //Load frames based on file paths
        for (int i = 0; i < 89; i++)
        {
            imagesHold.Add(Resources.Load<Sprite>(filePathsHold[i]));
        }

        //Set current frame to first;
        currFrame = 0;

        //give own reference to the static class
        InteractibleManager.addInteractible(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            return;
        }

        if(state == HuntState.ACTIVE)
        {
            //Set rotation to always look at eagle
            UIHolder.transform.LookAt(lockLocation);

            //Set scale to be relevant to the largest axis of difference between the eagle and this ui
            float maxAxisDist = 0.0f;

            //Get the vector distance difference
            Vector3 distDiff = Vector3.one;
            distDiff.x = (Mathf.Pow(transform.position.x - lockLocation.x, 2));
            distDiff.y = (Mathf.Pow(transform.position.y - lockLocation.y, 2));
            distDiff.z = (Mathf.Pow(transform.position.z - lockLocation.z, 2));

            //Get maximum distance the eagle is away from the hunter UI projection source
            if (distDiff.x > maxAxisDist)
            {
                maxAxisDist = distDiff.x;
            }

            if (distDiff.y > maxAxisDist)
            {
                maxAxisDist = distDiff.y;
            }

            if (distDiff.z > maxAxisDist)
            {
                maxAxisDist = distDiff.z;
            }

            //Calculate the scale difference based on the expected size and the current size
            //At 3000 the circle is scale 1
            AxisMult = maxAxisDist / 3000; 
       
            Vector3 newScale = Vector3.one;

            //Determine if the Axis Mult is within or without the acceptable margin of visibility
            if (MultMin < AxisMult && AxisMult < MultMax)
            {
                newScale = new Vector3(AxisMult, AxisMult, 1);
            }

            //Otherwise use either limit
            if (AxisMult < MultMin)
            {
                newScale = new Vector3(MultMin, MultMin, 1);
            }

            else if(AxisMult > MultMax)
            {
                newScale = new Vector3(MultMax, MultMax, 1);
            }

            UIHolder.transform.localScale = newScale;

            if (timeElapsed >= frameChange)
            {
                timeElapsed = 0.0f;

                Ping.sprite = imagesHold[currFrame];

                //Offset frame value
                currFrame++;

                //Ensure it never exceeds
                currFrame %= 89;
            }

            else
            {
                timeElapsed += Time.deltaTime;
            }
        }

        else if(state == HuntState.INACTIVE)
        {
            currFrame = 0;
        }
    }

    //Takes in a location from which the ping was sent and orients the UI towards the position
    public void EngagePing(Vector3 origin)
    {
        lockLocation = origin;
        //Set own state to active and enable image element
        state = HuntState.ACTIVE;
        Ping.enabled = true;
    }

    public void DisablePing()
    {
        //Set own state to inactive and disable the image element of the UI
        //Also Reset own rotation and scale in order to avoid problems
        Ping.enabled = false;
        state = HuntState.INACTIVE;
    }

    public void Pause()
    {
        isPaused = true;
        //This is fucking cursed
        if (gameObject.CompareTag("Bunny"))
        {
            gameObject.GetComponent<HuntableBaseScript>().Pause();
        }
    }

    public void Unpause()
    {
        isPaused = false;
        //This is fucking cursed(2)
        if (gameObject.CompareTag("Bunny"))
        {
            gameObject.GetComponent<HuntableBaseScript>().Unpause();
        }
    }
}
