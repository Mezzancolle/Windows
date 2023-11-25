using System;
using UnityEngine;



public class ClockHands : MonoBehaviour {

    private const float
      hoursToDegrees = 360f / 12f,
      minutesToDegrees = 360f / 60f;

    public Transform hours, minutes;

    private DateTime time;
    [SerializeField] int hour, minute, seconds;

    void Start () 
    {
        time = DateTime.Now;
    }
	
	void Update () {

        hour = time.Hour;
        minute = time.Minute;
        seconds = time.Second;

        time.AddMilliseconds(Time.deltaTime);

        hours.localRotation = Quaternion.Euler(0f, 0f, ((time.Hour) * hoursToDegrees) + ((time.Minute * minutesToDegrees) / 12.0f));
        minutes.localRotation = Quaternion.Euler(0f, 0f, (time.Minute * minutesToDegrees));
    }
}
