using UnityEngine;
using UnityEngine.SceneManagement;

public class reload : MonoBehaviour
{
    public GameObject meme;

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void memeMode()
    {
        meme.SetActive(meme.activeSelf ? false : true);
    }

    public void QuitButton()
    {
        Debug.Log("Exiting Game...");
        Application.Quit(); 
    }
}
