using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    //This function will load the scene using the build order
    public void Reload()
    {
        SceneManager.LoadScene(LevelTracker.getLastLevel());
    }

    public void unPause()
    {
        transform.GetComponentInParent<BirdMainScript>().Paused();
    }

    public void onClickPlay()
    {
        SceneManager.LoadScene("IntroStoryScene");
    }

    //LEGACY
    public void OnClickStart()
    {
        SceneManager.LoadScene("TUTORIAL TERRAIN"); //Replace with Tutorial scene later
    }

    public void OnClickEnd()
    {
        Application.Quit(); //Quit the application
    }

    public void OnClickBack()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void StoryScene1()
    {
        SceneManager.LoadScene("StoryScene1");
    }

    public void StoryScene2()
    {
        SceneManager.LoadScene("StoryScene2");
    }

    public void StoryScene3()
    {
        SceneManager.LoadScene("StoryScene3");
    }

    public void StoryScene4()
    {
        SceneManager.LoadScene("StoryScene4");
    }

    public void StoryScene5()
    {
        SceneManager.LoadScene("StoryScene5");
    }
    public void Level1Play()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Level2Play()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Level3Play()
    {
        SceneManager.LoadScene("Level3");
    }

    public void Level4Play()
    {
        SceneManager.LoadScene("Level4");
    }

    public void Level5Play()
    {
        SceneManager.LoadScene("Level5");
    }

    public void Leave()
    {
        Application.Quit();
    }

    //DO NOT call this via the last scene.
    public void loadNext()
    {
        int currScene = SceneManager.GetActiveScene().buildIndex;

        int nextScene = currScene + 1;

        SceneManager.LoadScene(nextScene);
    }
}

