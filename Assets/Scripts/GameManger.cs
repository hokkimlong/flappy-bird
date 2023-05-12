using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public GameObject playCanvas;
    public GameObject gameOverCanvas;
    public GameObject bird;
    public GameObject gameScoreCanvas;
    public bool isGameOver = false;
    public AudioClip hitSound;
    public AudioClip dieSound;

    // Start is called before the first frame update
    void Start()
    {
        playCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        playCanvas.SetActive(false);
        Time.timeScale = 1;
        AudioManager.instance.PlayBackground();
        bird.SetActive(true);
        gameScoreCanvas.SetActive(true);
    }

    public void GameOver()
    {
        AudioManager.instance.Play(hitSound);
        if (!isGameOver)
        {
            AudioManager.instance.Play(dieSound);
        }
        isGameOver = true;
        StartCoroutine(EndGame());
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
        gameOverCanvas.SetActive(true);
    }
}
