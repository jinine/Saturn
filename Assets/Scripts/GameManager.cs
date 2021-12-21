﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public int lives = 3;
    public float respawnTime = 3.0f;
    public int score = 0;
    public ParticleSystem explosion;
    public Text score_text;
    public Text life_text;

    public void Start()
    {
        score = 0;
        score_text.text = ("Score " + score);
        life_text.text = "LIVES " + lives;
    }

    public void PlayerDied()
    {
        lives--;
        life_text.text = "LIVES " + lives;
        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), respawnTime);
        }

    }

    public void AsteroidDestroyed(Asteroid asteroid)
    {
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();
        score++;
        score_text.text = "Score " + score;
    }

    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("Collision Handler");
        this.player.gameObject.SetActive(true);
        Invoke(nameof(TurnOffCollisionHandler), 3.0f);
    }

    private void TurnOffCollisionHandler()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {
        Debug.Log("you lost...");
        Debug.Log("your score: " + score);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
