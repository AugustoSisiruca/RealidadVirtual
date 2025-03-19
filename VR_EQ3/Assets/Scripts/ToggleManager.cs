using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleManager : MonoBehaviour
{
    [SerializeField]
    private List<ComplexToggleController> managedToggles = new List<ComplexToggleController>();

    private int currentActive = -1;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i<managedToggles.Count; i++){
            managedToggles[i].groupIndex = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateActives(int newCurrentlyActive){
        if (currentActive != newCurrentlyActive) {
            if (currentActive != -1) {
                managedToggles[currentActive].deactivate();
            }
            managedToggles[newCurrentlyActive].activate();
            currentActive = newCurrentlyActive;
        }
    }
}
