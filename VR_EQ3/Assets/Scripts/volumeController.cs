using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class volumeController : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Text displayedText;

    void Start(){
        updateText();
    }

    private void updateText() {
        if (masterMixer != null && displayedText != null) {
            float currentAudioLevel;
            masterMixer.GetFloat("MasterVolumeController", out currentAudioLevel);
            displayedText.text = (string.Format("{0:N0}", currentAudioLevel+80) + "%");
        }
    }

    public void increaseVolume() {
        if (masterMixer != null) {
            float currentAudioLevel;
            masterMixer.GetFloat("MasterVolumeController", out currentAudioLevel);
            if (currentAudioLevel < 20) {
                currentAudioLevel += 1;
                masterMixer.SetFloat("MasterVolumeController", currentAudioLevel);
                updateText();
                print(currentAudioLevel);
            }
        }
    }

    public void decreaseVolume() {
        if (masterMixer != null) {
            float currentAudioLevel;
            masterMixer.GetFloat("MasterVolumeController", out currentAudioLevel);
            if (currentAudioLevel > -80) {
                currentAudioLevel -= 1;
                masterMixer.SetFloat("MasterVolumeController", currentAudioLevel);
                updateText();
                print(currentAudioLevel);
            }
        }
    }
}
