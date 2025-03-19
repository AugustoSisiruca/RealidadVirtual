using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resolutionController : MonoBehaviour
{
    private Resolution[] availableResolutions;
    public Text referenceText;
    int resolutionIndex = 0;
    List<string> displayedResolutions = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        availableResolutions = Screen.resolutions;
        for (int i = 0; i < availableResolutions.Length; i++) {
            displayedResolutions.Add(availableResolutions[i].width.ToString() + "x" + availableResolutions[i].height.ToString());
            if (availableResolutions[i].width == Screen.currentResolution.width && availableResolutions[i].height == Screen.currentResolution.height){
                resolutionIndex = i;
                if (referenceText != null){
                    referenceText.text = displayedResolutions[i];
                }
            }
        }
    }

    private void updateResolution(int index){
        referenceText.text = displayedResolutions[index];
        Screen.SetResolution(availableResolutions[index].width, availableResolutions[index].height, false);
    }

    public void resolutionUp() {
        if (resolutionIndex+1 < availableResolutions.Length){
            resolutionIndex += 1;
            updateResolution(resolutionIndex);
        }
    }

    public void resolutionDown() {
        if (resolutionIndex > 0) {
            resolutionIndex -= 1;
            updateResolution(resolutionIndex);
        }
    }
}
