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

    public void unPause()
    {
        transform.GetComponentInParent<BirdMainScript>().Paused();
    }

    public void onClickPlay()
    {
        SceneManager.LoadScene("IntroStoryScene");
    }

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

    public void IntroScenePlay()
    {
        SceneManager.LoadScene("IntroStoryScene");
    }

    public void MidStoryScenePlay()
    {
        SceneManager.LoadScene("MidStoryScene");
    }

    public void FinalStoryScenePlay()
    {
        SceneManager.LoadScene("FinalStoryScene");
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
}

