using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float reset;
    private Vector3 StartPosition;

    void Start()
    {
        StartPosition = transform.position;
    }

    //update is called once per frame

    void Update()
    {
        transform.Translate(translation: Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < reset)
        {
            transform.position = StartPosition;
        }
    }
}
