using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject winGame;
    public float Cronometer = 180f;
    public bool finished = false;

    void Update()
    {
        if (finished)
        {
            return;
        }

        Cronometer -= Time.deltaTime;

        if(Cronometer < 0)
        {
            Win();
        }
    }

    public void Win()
    {
        finished = true;
        winGame.SetActive(true);
        Time.timeScale = 0;

        Debug.Log("HAS GANADO");
    }

    public void Lose()
    {
        finished = true;
        gameOver.SetActive(true);
        Time.timeScale = 0;

        Debug.Log("PERDISTE, MEJORA");
    }

    public void ResetScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
