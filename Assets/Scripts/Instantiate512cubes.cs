using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512cubes : MonoBehaviour
{
    [Tooltip("The max at which the cubes are stretched")]
    public float maxValue = 512f;
    [Tooltip("The final rotation of the parent object on the y axis")]
    public float yRotFinal = 0f;
    [Tooltip("The final rotation of the parent object on the z axis")]
    public float zRotFinal = 0f;

    [Tooltip("The lowest value the cubes can be")]
    public float lowestValue = 20f;

    [Tooltip("The prefab that is copied upon multiple instances")]
    public GameObject _sampleCubePrefab;
    [Tooltip("The collection of the copied cubes")]
    GameObject[] _sampleCube = new GameObject[512];
    public float _maxScale;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 512; i++) {
            GameObject _instanceSampleCube = (GameObject)Instantiate(_sampleCubePrefab);
            _instanceSampleCube.transform.position = transform.position;
            _instanceSampleCube.transform.parent = transform;
            _instanceSampleCube.name = "SampleCube " + i;
            //transform.position = new Vector3(-0.703125f * i, transform.position.y, 9000);
            transform.eulerAngles = new Vector2(transform.rotation.x, transform.rotation.y + (i*0.2f));
            _instanceSampleCube.transform.position = Vector3.forward * 9000;
            _sampleCube[i] = _instanceSampleCube;
        }
        transform.eulerAngles = new Vector3(transform.rotation.x, yRotFinal, zRotFinal);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 512; i++) {
            if (_sampleCube != null) {
                _sampleCube[i].transform.localScale = new Vector3(transform.localScale.x, Mathf.Clamp((AudioPeer._samples[i] * _maxScale) + 2, lowestValue, maxValue), transform.localScale.z);
            }
        }
    }
}
