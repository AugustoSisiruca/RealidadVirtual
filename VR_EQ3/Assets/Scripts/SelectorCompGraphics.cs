using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorCompGraphics : MonoBehaviour
{   
    [SerializeField]
    private Button increaseButton;
    [SerializeField]
    private Button decreaseButton;
    private Animator ownAnimator;
    // Start is called before the first frame update
    void Start()
    {
        ownAnimator = this.GetComponent<Animator>();
    }

    public void exit() {
        ownAnimator.SetTrigger("SelectorExit");
        if (increaseButton != null) {
            Animator increaseAnimator = increaseButton.GetComponent<Animator>();
            increaseAnimator.SetTrigger("Exit");
        }
        if (increaseButton != null) {
            Animator decreaseAnimator = decreaseButton.GetComponent<Animator>();
            decreaseAnimator.SetTrigger("Exit");
        }
    }
}
