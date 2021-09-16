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
        for (int i = 1; i <= 60; i++)
        {
            //Sprite newSprite;
            string filePathPing;

            if (i < 10)
            {
                filePathPing = "HunterVision/Speedline__denoise_000" + i.ToString();
            }

            else
            {
                filePathPing = "HunterVision/Speedline__denoise_00" + i.ToString();
            }

            filePathsHold.Add(filePathPing);
        }

        //Load frames based on file paths
        for (int i = 0; i < 60; i++)
        {
            imagesHold.Add(Resources.Load<Sprite>(filePathsHold[i]));
        }

        //Set current frame to first;
        currFrame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
