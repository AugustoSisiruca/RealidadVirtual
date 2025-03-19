using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class prueba_tutorial : MonoBehaviour
{
    [SerializeField] Dialogue dialogo;
    void Awake(){
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
            if (dialogo != null)
            {
                dialogo.localizationController.OnLocalizationReady += OnLocalizationReady;
            }
    }
    private void OnLocalizationReady()
    {
        dialogo.SetupDialogue();
        dialogo.StartDialogue(0, false);
    }
}
