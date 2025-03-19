using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogo : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public Button button;
    public float textSpeed = 0.1f; //Velocidad del texto
    int index; //Linea donde se esta

    public GameObject dialogCanvas;




    void Start()
    {
        dialogueText.text = string.Empty;
        button.onClick.AddListener(EventClick);
        StartDialogue();
    }

    // Update is called once per frame
    void Update(){


    }


    public void StartDialogue(){
        index = 0;
        StartCoroutine(WriteLine());
    }

    IEnumerator WriteLine()
    { //Genera cada palabra en las lineas de texto cada 0,1 segundos
        foreach (char letter in lines[index].ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

    }

    public void NextLine() {
        //Pasar a la siguiente linea
        if (index < lines.Length-1){
            dialogueText.text = string.Empty;
            index++;
            StartCoroutine(WriteLine());

        }

        else{
            gameObject.SetActive(false);
            dialogCanvas.SetActive(false); 

        }
    }

    public void EventClick(){
        if(dialogueText.text == lines[index]){
        NextLine();}

        else {
            StopAllCoroutines();
            dialogueText.text = lines[index];
            }
    }
}
