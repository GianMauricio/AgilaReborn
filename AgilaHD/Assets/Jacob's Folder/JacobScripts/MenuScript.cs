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
}
