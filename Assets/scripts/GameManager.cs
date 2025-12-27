using UnityEngine;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject spike;
    public Transform spawnPoint;
    public float score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText; // Drag your 'Best Score' TMP object here

    void Start()
    {
        GameStart();
        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "Best: " + savedHighScore.ToString();
    }

    void Update()
    {
        // Increment score every frame if the player is alive
        if (GameObject.FindWithTag("Player") != null)
        {
            score += Time.deltaTime;
            scoreText.text = ((int)score).ToString();
        }
    }

    IEnumerator SpawnSpikes()
    {
         while(true)
        {
            float waitTime = Random.Range(0.5f, 2f);
            yield return new WaitForSeconds(waitTime);
            float pos = Random.Range(0f, 1f);
            Vector3 newpos=new Vector3();
            if(pos>0.5f)
                newpos = new Vector3(spawnPoint.position.x,spawnPoint.position.y+ 1.5f, spawnPoint.position.z);
            else
                newpos = new Vector3(spawnPoint.position.x,spawnPoint.position.y, spawnPoint.position.z);
            Instantiate(spike, newpos, Quaternion.identity);
        }
    }

    public void GameStart()
    {
        StartCoroutine(SpawnSpikes());
    }

    // Call this function when the player hits a spike
    public void CheckHighScore()
    {
        int currentScore = (int)score;
        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);

        if (currentScore > savedHighScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            PlayerPrefs.Save();
            highScoreText.text = "New Best Score: " + currentScore.ToString();
        }
        else
        {
            highScoreText.text = "Best Score: " + savedHighScore.ToString();
        }
    }
}