using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{

    public GameManger gameManager;
    public float velocity = 1;
    private Rigidbody2D rigidbody2d;
    public Score score;
    public AudioClip flyingSound;
    public AudioClip getPointSound;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); 
    }

    private void Update()
    {
        if (gameManager.isGameOver)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.GetComponent<Animator>().enabled = false;
            return;
        };
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.instance.Play(flyingSound);
            rigidbody2d.velocity = Vector2.up * velocity;
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            gameManager.GameOver();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pass") && !gameManager.isGameOver)
        {
            AudioManager.instance.Play(getPointSound);
            score.AddScore();
        }
    }

    }
