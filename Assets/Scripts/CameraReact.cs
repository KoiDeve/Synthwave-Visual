using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReact : MonoBehaviour
{

    bool _isActive = false;
    public int _band;
    Camera _theCamera;
    float _minIntensity, _maxIntensity;
    public float _sensitivity = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        _theCamera = FindObjectOfType<Camera>();
        _minIntensity = _theCamera.orthographicSize + _sensitivity;
        _maxIntensity = _theCamera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isActive)
            return;
        _theCamera.orthographicSize = (AudioPeer._audioBandBuffer[_band] * (_maxIntensity - _minIntensity)) + _minIntensity;
    }

    public void UpdateOrthographic(float orthoSize) {
        _minIntensity = orthoSize + _sensitivity;
        _maxIntensity = orthoSize;
    }

    public void SetMusicSensitivity(bool active) {
        _isActive = active;
    }

}
