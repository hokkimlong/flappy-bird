using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipe : MonoBehaviour
{
    public float maxTime = 1;
    private float timer = 0;
    public GameObject pipe;
    public float height;
    private int currentPipe = 0;
    private List<GameObject> pipes = new();
    private float lastScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            pipes.Add(Instantiate(pipe));
        }
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if(maxTime>1 && Score.score - lastScore >= 2)
        {
            maxTime -= 0.25f;
            lastScore = Score.score;
        }
        if(timer > maxTime)
        {
            spawn();
            timer = 0;
        }
        timer += Time.deltaTime; 
    }

    private Vector3 getRandomPipePosition()
    {
        return transform.position + new Vector3(0, Random.Range(-height, height), 0); 
    }

    private void spawn()
    {
        pipes[currentPipe].transform.position = getRandomPipePosition();
        if (currentPipe < pipes.Count - 1)
        {
          currentPipe++;
        }
        else
        {
          currentPipe = 0;
        }
    }
}
