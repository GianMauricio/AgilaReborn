using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// This script uses simple gif logic to make simple UI animations. Specifically this script controls the Eagle's speedline effect
/// </summary>
public class SpeedLinesAnimator : MonoBehaviour
{
    public enum SpeedState { ACCELERATING, DECELERATING, HOLDINGFAST, HOLDINGSLOW};
    public Image speedLines;
    public List<string> filePathsHold;
    public List<string> filePathsEnter;
    public List<Sprite> imagesHold;
    public List<Sprite> imagesEnter;
    private float frameChange = 0.01f;
    private float timeElapsed = 0.0f;
    private int currFrame = 0;
    private float opac = 0.0f;

    public SpeedState state = SpeedState.HOLDINGSLOW;

    void Start()
    {
        //Ready frames file paths via resource folder
        for(int i = 1; i <= 60; i++)
        {
            //Sprite newSprite;
            string filePathEnter;
            string filePathHold;

            if(i < 10)
            {
                filePathEnter = "SpeedlinesEnter/Speedline__denoise_000" + i.ToString();
                filePathHold = "SpeedlinesHold/Speedline__denoise_000" + i.ToString();
            }

            else
            {
                filePathEnter = "SpeedlinesEnter/Speedline__denoise_00" + i.ToString();
                filePathHold = "SpeedlinesHold/Speedline__denoise_00" + i.ToString();
            }
            
            filePathsHold.Add(filePathHold);
            filePathsEnter.Add(filePathEnter);
        }

        //Load frames based on file paths
        for (int i = 0; i < 60; i++)
        {
            imagesHold.Add(Resources.Load<Sprite>(filePathsHold[i]));
            imagesEnter.Add(Resources.Load<Sprite>(filePathsEnter[i]));
        }

        //Set current frame to first;
        currFrame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Maintain starter values if currently at slow
        if(state == SpeedState.HOLDINGSLOW)
        {
            opac = 0.0f;
            currFrame = 0;
            return;
        }

        //if the eagle is accelerating, slowly fade in while playing entry anim
        else if(state == SpeedState.ACCELERATING)
        {
            if (timeElapsed >= frameChange)
            {
                timeElapsed = 0.0f;

                speedLines.sprite = imagesEnter[currFrame];

                //Offset frame value
                currFrame++;

                //Ensure it never exceeds
                currFrame %= 30;
            }

            else
            {
                timeElapsed += Time.deltaTime;
            }

            if (opac < 1.0f)
            {
                opac += Time.deltaTime;
                speedLines.color = new Color(1, 1, 1, opac);
            }

            else
            {
                currFrame = 0;
                opac = 1.0f;
                speedLines.color = new Color(1, 1, 1, opac);
                state = SpeedState.HOLDINGFAST;
            }
        }

        //if the eagle is accelrating then run normal animations until otherwise indicated
        else if (state == SpeedState.HOLDINGFAST){
            if (timeElapsed >= frameChange)
            {
                timeElapsed = 0.0f;

                //Set new frame
                //speedLines.sprite = Resources.Load<Sprite>(filePathsHold[currFrame]);
                speedLines.sprite = imagesHold[currFrame];

                //Offset frame value
                currFrame++;

                //Ensure it never exceeds
                currFrame %= 60;
            }

            else
            {
                timeElapsed += Time.deltaTime;
            }
        }

        else if(state == SpeedState.DECELERATING)
        {
            if (timeElapsed >= frameChange)
            {
                timeElapsed = 0.0f;

                //Loop enter but backwards
                int activeFrame = 29 - currFrame;
                speedLines.sprite = imagesEnter[activeFrame];

                //Offset frame value
                currFrame++;

                //Ensure it never exceeds
                currFrame %= 30;
            }

            else
            {
                timeElapsed += Time.deltaTime;
            }

            if (opac > 0.0f)
            {
                opac -= Time.deltaTime;
                speedLines.color = new Color(1, 1, 1, opac);
            }

            else
            {
                opac = 0.0f;
                speedLines.color = new Color(1, 1, 1, opac);
                state = SpeedState.HOLDINGSLOW;
            }
        }
    }

    /// <summary>
    /// Changes the current state of the birds speedlines
    /// </summary>
    /// <param name="newState">Always use Accelerating and Decelerating</param>
    public void changeState(SpeedState newState)
    {
        state = newState;
        currFrame = 0;
        timeElapsed = 0.0f;
    }
}
