using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LerpCameraToMonitor : MonoBehaviour
{
    public Transform Target;
    private Vector3 Oldpos;
    private Quaternion Oldrot;
    public float LerpTime;
    private float _lerpCounter;
    private bool _startedLerpIntoMonitor = false;
    private bool _startedLerpIntoCamera = false;
    public UnityEvent OnFirstLerpEnded;
    public UnityEvent OnSecondLerpEnded;

    void Start()
    {
        Oldpos = transform.position;
        Oldrot = transform.rotation;

    }

    void Update()
    {
        LerpIntoMonitor();
        LerpIntoCamera();
    }

    private void LerpIntoMonitor()
    {
        if (Input.GetKeyDown(KeyCode.A) & !_startedLerpIntoMonitor)
        {
            Oldrot = transform.rotation;
            _lerpCounter = 0;
            _startedLerpIntoMonitor = true;
        }

        if (_startedLerpIntoMonitor)
        {
            OnFirstLerpEnded.Invoke();

            transform.position = Vector3.Lerp(Oldpos, Target.position, _lerpCounter / LerpTime);
            transform.rotation = Quaternion.Slerp(Oldrot, Target.rotation, _lerpCounter / LerpTime);

            _lerpCounter += Time.deltaTime;

            if (_lerpCounter > LerpTime)
            {
                _startedLerpIntoMonitor = false;
                _lerpCounter = 0;
            }
        }
    }

    private void LerpIntoCamera()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            _lerpCounter = 0;
            _startedLerpIntoCamera = true;
        }

        if (_startedLerpIntoCamera)
        {
            transform.position = Vector3.Lerp(Target.position, Oldpos, _lerpCounter / LerpTime);
            transform.rotation = Quaternion.Slerp(Target.rotation, Oldrot, _lerpCounter / LerpTime);

            _lerpCounter += Time.deltaTime;

            if (_lerpCounter > LerpTime)
            {
                _startedLerpIntoCamera = false;
                _lerpCounter = 0;
                OnSecondLerpEnded.Invoke();
            }
        }

    }
        
}
