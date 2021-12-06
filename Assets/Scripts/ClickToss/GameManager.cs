using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score;

    public List<GameObject> targets;
    // public GameObject[] targetArr;
    public TextMeshProUGUI scoreText;
    public Image gameOverScreen;
    public Button restartButton;
    public GameObject TitleScreen;

    public bool isGameActive { get; private set; }

    /*Declare and initialize a new private float spawnRate variable
    Create a new IEnumerator SpawnTarget () method 
    Inside the new method, while(true), wait 1 second, generate a random index,  and spawn a random target
    In Start(), use the StartCoroutine method to begin spawning objects*/
    private float spawnRate = 1.0f;

    private IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverScreen.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void StartGame(int difficulty)
    {
        score = 0;
        spawnRate /= difficulty;

        UpdateScore(0);
        StartCoroutine(SpawnTarget());

        isGameActive = true;
        TitleScreen.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
