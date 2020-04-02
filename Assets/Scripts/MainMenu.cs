using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //All of these examples loads "SampleLevel"
        SceneManager.LoadScene("Level_1_Scene");
        //Resets timer to 0 with Persistent- and SceneManagerScript!!
        PersistentManagerScript.Instance.Value = 0;
    }

    public void QuitGame()
    {
        Application.Quit();

    }

    public void OptionsGame()
    {

        SceneManager.LoadScene("MainOptionsScene");
    }



    public void BackGame()
    {

        SceneManager.LoadScene("MainMenuScene");

    }
    public void CreditsGame()
    {

        SceneManager.LoadScene("MainCreditsScene");

    }

}

