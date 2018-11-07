using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothedCamera : MonoBehaviour {

    public Transform target;
    public float LookAheadTrigger;
    public float LevelBoundsX;
    public float LevelBoundsY;
    private PlaneController PC;

    public float HorizontalLookDistance;
    public Vector3 CameraOffset;

    public float SmoothingSpeed;
    public float CameraSpeed;

    private float _shakeDuration;
    private float _shakeIntensity;
    private float _shakeDecay;

    private Vector3 _currentVelocity;

    private Vector3 _lastTargetPosition;
    private Vector3 _lookAheadPos;
    private float ResetSpeed;
    private float _offsetZ;

    private Camera _camera;

    private Vector3 _lookDirectionModifier;


  

    private void Start()
    {
        // GSM = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        PC = target.GetComponent<PlaneController>();
        _camera = this.GetComponent<Camera>();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        
        
            // if the player has moved since last update
            float xMoveDelta = (target.position - _lastTargetPosition).x;
            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > LookAheadTrigger;

            if (updateLookAheadTarget)
            {
                _lookAheadPos = HorizontalLookDistance * Vector3.right * Mathf.Sign(xMoveDelta);
            }
            else
            {
                _lookAheadPos = Vector3.MoveTowards(_lookAheadPos, Vector3.zero, Time.deltaTime * ResetSpeed);
            }

            Vector3 aheadTargetPos = target.position + _lookAheadPos + Vector3.forward * _offsetZ + _lookDirectionModifier + CameraOffset;
            Vector3 newCameraPosition = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref _currentVelocity, CameraSpeed);
            Vector3 shakeFactorPosition = Vector3.zero;

            // If shakeDuration is still running.
            if (_shakeDuration > 0)
            {
                shakeFactorPosition = Random.insideUnitSphere * _shakeIntensity * _shakeDuration;
                _shakeDuration -= _shakeDecay * Time.deltaTime;
            }

            if (newCameraPosition.x > LevelBoundsX)
            {
                newCameraPosition.x = LevelBoundsX;

            } else if(newCameraPosition.x < -LevelBoundsX)
            {
            newCameraPosition.x = -LevelBoundsX;

            }

             if (newCameraPosition.y > LevelBoundsY)
             {
            newCameraPosition.y = LevelBoundsY;

             }
            else if (newCameraPosition.y < -LevelBoundsY)
            {
            newCameraPosition.y = -LevelBoundsY;

            }


        newCameraPosition = newCameraPosition + shakeFactorPosition;

        
            
                transform.position = newCameraPosition;

        
            

            _lastTargetPosition = target.position;

        float TargetCameraSize = Mathf.Clamp(PC.Acceleration, 100, 200);
        if(_camera.orthographicSize < TargetCameraSize)
        {
            _camera.orthographicSize += 50 * Time.deltaTime;
        }
        if(_camera.orthographicSize > TargetCameraSize)
        { _camera.orthographicSize -= 50 * Time.deltaTime; }

           
        
        
    }
}
