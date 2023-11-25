using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LerpCameraToMonitor : MonoBehaviour
{
    [SerializeField] private Transform _monitorTarget;

    private Vector3 _startPos;
    private Quaternion _startRot;

    [SerializeField] private float _lerpTimer;
    [SerializeField] private float _lerpCounter;
    private bool _isLerping = false;
    private bool _isGoingForward = false;

    public UnityEvent OnStartLerp,OnLerpEndGoingForward,OnlerpEndGoingBackward;

    void Start()
    {
        _startPos = transform.position;

        OnStartLerp.AddListener(() => {
                                        _isLerping = true;
                                        Cursor.visible = false;
                                        Cursor.lockState = CursorLockMode.Locked;
        });

        OnLerpEndGoingForward.AddListener(() => { Cursor.visible = true; Cursor.lockState = CursorLockMode.Confined; });

    }

    void Update()
    {
        if (_isLerping) 
        {
            _lerpCounter += Time.deltaTime;
            LerpCameraFlipFlop();
            return;
        }

        if (Input.GetKeyDown(KeyCode.A) && !_isGoingForward)
        {
            _startRot = transform.rotation;
            StartLerping(true);

        }
        else if (Input.GetKeyDown(KeyCode.D) && _isGoingForward)
        {
            StartLerping(false);
        }
    }

    public void StartLerping(bool isGoingForward)
    {
        OnStartLerp.Invoke();
        _isGoingForward = isGoingForward;
    }

    private void LerpCameraFlipFlop()
    {
        if (_isGoingForward)
        {
            LerpCamera(_startPos, _startRot, _monitorTarget.position, _monitorTarget.rotation);
        }
        else
        {
            LerpCamera(_monitorTarget.position, _monitorTarget.rotation, _startPos, _startRot);
        }
    }

    private void LerpCamera(Vector3 fromPos, Quaternion fromRot, Vector3 toPos, Quaternion toRot)
    {
        transform.position = Vector3.Lerp(fromPos, toPos, _lerpCounter / _lerpTimer);
        transform.rotation = Quaternion.Slerp(fromRot, toRot, _lerpCounter / _lerpTimer);        

        if (_lerpCounter > _lerpTimer)
        {
            _isLerping = false;
            _lerpCounter = 0;

            if (_isGoingForward) OnLerpEndGoingForward.Invoke();
            else OnlerpEndGoingBackward.Invoke();
        }
    }        
}
