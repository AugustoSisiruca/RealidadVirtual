using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LightRoom : MonoBehaviour
{
  public Button mybutton; 
    public GameObject lightRoom;
    // Start is called before the first frame update
    void Start()
    {
        mybutton.onClick.AddListener(InteractionEvent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractionEvent(){
        if(lightRoom.activeSelf)
        {
            lightRoom.SetActive(false);
        }
        else
        {
            lightRoom.SetActive(true);
        }
    }
}
