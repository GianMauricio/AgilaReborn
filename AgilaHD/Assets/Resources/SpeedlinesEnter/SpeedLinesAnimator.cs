using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SpeedLinesAnimator : MonoBehaviour
{
    public Image speedLines;
    public List<string> filePaths;
    public List<Sprite> images;
    private float frameChange = 0.03f;
    public float timeElapsed = 0.0f;
    private int currFrame = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 60; i++)
        {
            if(i < 10)
            {
                filePaths.Add("SpeedlinesHold/Speedline__denoise_000" + i + ".png");
            }

            else
            {
                filePaths.Add("SpeedlinesHold/Speedline__denoise_00" + i + ".png");
            }
        }

        for(int i = 0; i < 60; i++)
        {
            images.Add(IMG2Sprite.LoadSprite(filePaths[i]));
        }

        if(speedLines == null)
        {
            Debug.Log("Image reference missing for speedlines");
        }
        
        if(images.Count == 0)
        {
            Debug.Log("No Frames found");
        }

        currFrame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeElapsed >= frameChange)
        {
            timeElapsed = 0.0f;

            //Set new frame
            speedLines.sprite = images[currFrame];

            //Offset frame value
            currFrame++;

            //Ensure it never exceeds
            currFrame %= currFrame % images.Count;
        }

        else
        {
            timeElapsed += Time.deltaTime;
        }
    }
}
