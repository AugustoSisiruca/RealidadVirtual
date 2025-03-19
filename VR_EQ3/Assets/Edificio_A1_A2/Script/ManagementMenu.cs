using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class ManagementMenu : MonoBehaviour
{
    public void StartGameVR()
    {
        SceneManager.LoadScene(1);
    }
  
    public void ExitVR()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

    public void GoStartMenu()
    {
        SceneManager.LoadScene(0);
    }
}
