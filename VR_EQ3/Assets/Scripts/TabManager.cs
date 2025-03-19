using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabManager : MonoBehaviour
{
    private int currentlyActive = 0;

    [SerializeField]
    private List<Button> myTabs = new List<Button>();

    [SerializeField]
    private List<GameObject> panelController = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i<myTabs.Count; i++){
            if (myTabs[i].GetComponent<SelectorButton>() != null){
                myTabs[i].GetComponent<SelectorButton>().upperIndex = i;
                myTabs[i].GetComponent<SelectorButton>().parent = this;
                myTabs[i].GetComponent<SelectorButton>().holder = myTabs[i];
            }
        }

        myTabs[currentlyActive].interactable = false;

        for (int i = 0; i<panelController.Count; i++) {
            if (i == currentlyActive) {
                panelController[i].SetActive(true);
            }
            else {
                panelController[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReassignTables(int becomingActive){
        myTabs[currentlyActive].interactable = true;
        panelController[currentlyActive].SetActive(false);

        currentlyActive = becomingActive;

        myTabs[currentlyActive].interactable = false;
        panelController[currentlyActive].SetActive(true);
    }
}
