using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingFloor : MonoBehaviour
{

    [SerializeField]
    public float speed = 0.5f;
    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(0, Time.time * speed);
        material.mainTextureOffset = offset;
    }
}
