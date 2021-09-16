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
    public Image Ping;
    public List<string> filePathsHold;
    public List<Sprite> imagesHold;

    private float frameChange = 0.01f;
    private float timeElapsed = 0.0f;
    private int currFrame = 0;

    public HuntState state = HuntState.INACTIVE;

    // Start is called before the first frame update
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        if(state == HuntState.ACTIVE)
        {
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
        //Set own state to active and enable image element
        state = HuntState.ACTIVE;
    }

    public void DisablePing()
    {
        //Set own state to inactive and disable the image element of the UI
        //Also Reset own rotation and scale in order to avoid problems
        Ping.enabled = false;
        state = HuntState.INACTIVE;
    }
}
