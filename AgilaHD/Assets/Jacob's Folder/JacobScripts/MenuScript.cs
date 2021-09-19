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
        SceneManager.LoadScene("Level 1");
    }

    public void OnClickBack()
    {
        SceneManager.LoadScene("MenuScene");
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

