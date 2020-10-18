using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    public void PlayGame(){
        PlatformController.GameModeSelected = PlatformController.GameModes.Local;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayGameVSCPU(){
        PlatformController.GameModeSelected = PlatformController.GameModes.CPU;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

     public void ExitGame(){
        Application.Quit();
    }
}
