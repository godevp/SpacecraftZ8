using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
  MainMenu_scripts.cs 
  Vitaliy Karabanov
  Student number: 101312885
  Date last Modified - 24/10/2022 
  This is the mainMenu and just a button scripts
  Revision hystory: added function StartGame and QuitGame, later Surrender and restartB
  *New made a singalton to use it in playerBehavior when dying.
 */


public class MainMenu_script : MonoBehaviour
{
    // Start is called before the first frame update
    public static MainMenu_script instance;

    private void Awake()
    {
        instance = this;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Surrender()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartB()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
