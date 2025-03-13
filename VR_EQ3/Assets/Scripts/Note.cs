using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;  // Necesario para interactuar con el sistema de eventos

public class Note : MonoBehaviour
{
    public GameObject notePanel;             // Panel que contiene la nota

    public Button closeButton;               // Botón para cerrar la nota
  

    private bool isNoteActive = false;

    void Start()
    {
        notePanel.SetActive(false);
        closeButton.onClick.AddListener(CloseNote);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Interact()
    {
        notePanel.SetActive(true);

        

        
        

        isNoteActive = true;
    }

    public void CloseNote()
    {
        notePanel.SetActive(false);

       

        isNoteActive = false;
    }

    void Update()
    {
        if (isNoteActive && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseNote();
        }
    }
}


