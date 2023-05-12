using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPipe : MonoBehaviour
{
    public float speed;
    private float timer = 0;
    private float lastScore = 0;

    private void Update()
    {
        if(Score.score > lastScore)
        {
            timer += 0.1f;
        }
        lastScore = Score.score;
        transform.position += Vector3.left * (speed+timer) * Time.deltaTime;
    }

}
