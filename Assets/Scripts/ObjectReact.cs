using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReact : MonoBehaviour
{
    public float _tempo;
    public int _band;
    float _minIntensity, _maxIntensity;
    public float _scaleFactor = 300f;
    public float _sensitivity = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.one;
        _minIntensity = transform.localScale.x + _sensitivity;
        _maxIntensity = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        float newValue = AudioPeer._audioBandBuffer[_band] * (_maxIntensity - _minIntensity) + _minIntensity;
        if (transform.localScale.x - .40 >= newValue)
        {
            return;
        }
        transform.localScale = new Vector3(newValue, newValue, transform.localScale.z);
    }
}
