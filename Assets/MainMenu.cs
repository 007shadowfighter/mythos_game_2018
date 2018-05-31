using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void Playgame ()
    {
        SceneManager.LoadScene("lvl1_2d");
    }
    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

}
