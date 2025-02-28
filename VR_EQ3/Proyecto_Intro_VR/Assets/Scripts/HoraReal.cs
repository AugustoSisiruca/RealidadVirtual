using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoraReal : MonoBehaviour
{

    public Transform hourHand;
    public Transform minuteHand;
    public Transform secondHand;
    void Update()
    {
        DateTime currentTime = DateTime.Now;
        float hourRotation = (currentTime.Hour % 12) * 30f + currentTime.Minute * 0.5f; // 360 degrees / 12 hours = 30 degrees per hour
        float minuteRotation = currentTime.Minute * 6f + currentTime.Second * 0.1f; // 360 degrees / 60 minutes = 6 degrees per minute
        float secondRotation = currentTime.Second * 6f; // 360 degrees / 60 seconds = 6 degrees per second

        // Rotate each hand
        hourHand.localRotation = Quaternion.Euler(hourRotation + 90f, 0, -90f);
        minuteHand.localRotation = Quaternion.Euler(minuteRotation + 90f, 0, -90f);
        secondHand.localRotation = Quaternion.Euler(secondRotation + 90f, 0, -90f);

    }
}
