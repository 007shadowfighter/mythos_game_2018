using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeMenu : MonoBehaviour {

    private string start = "lvl1_2d"; //scene to go to when time is out
    public void Playgame ()
    {
        SceneManager.LoadScene(start);
    }
    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

}
