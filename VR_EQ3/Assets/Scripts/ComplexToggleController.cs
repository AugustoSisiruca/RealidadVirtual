using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ComplexToggleController : MonoBehaviour, IPointerEnterHandler
{
    private bool isActive = false;
    public int groupIndex;
    private Animator localAnimator;
    private SelectorCompGraphics selectorComponentGroupAnimator;
    [SerializeField]
    private GameObject objectHeld;
    private ToggleManager boss;
    public void OnPointerEnter(PointerEventData eventData)
    {
        enterUpdate();
    }
    // Start is called before the first frame update
    void Start()
    {
        boss = (ToggleManager)FindObjectOfType(typeof(ToggleManager));
        localAnimator = this.GetComponent<Animator>();
        if (objectHeld != null) {
            selectorComponentGroupAnimator = objectHeld.GetComponent<SelectorCompGraphics>();
            objectHeld.SetActive(false);
        }
    }

    public void enterUpdate() {
        boss.updateActives(groupIndex);
    }

    public void activate() {
        isActive = true;
        localAnimator.SetTrigger("activateToggle");
        StartCoroutine(toggleSetter());
    }

    public void deactivate() {
        isActive = false;
        localAnimator.SetTrigger("deactivateToggle");
        StartCoroutine(toggleSetter());
        selectorComponentGroupAnimator.exit();
    }

    IEnumerator toggleSetter() {
        if (isActive == true) {
            objectHeld.SetActive(true);
        }
        else {
            yield return new WaitForSecondsRealtime(.12f);
            objectHeld.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
