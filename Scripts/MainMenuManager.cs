using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private void Start()
    {
        KManager.enableMouse();
    }
    public void start()
    {
        SceneManager.LoadScene("Map_1");
    }
    public void exit()
    {
        Application.Quit();
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
