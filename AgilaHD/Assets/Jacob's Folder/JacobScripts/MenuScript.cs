﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
    }
    public void OnClickStart()
    {
        SceneManager.LoadScene("TUTORIAL TERRAIN"); //Replace with Tutorial scene later
    }

    public void OnClickEnd()
    {
        Application.Quit(); //Quit the application
    }
}
