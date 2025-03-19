using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorButton : MonoBehaviour
{
    public TabManager parent;
    public Button holder;
    public int upperIndex;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void callChanges(){
        parent.ReassignTables(upperIndex);
    }
}
