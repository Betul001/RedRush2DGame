using UnityEngine.SceneManagement;
using UnityEngine;
//using UnityEngine.UI;
using Cinemachine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public GameObject pauseMenuScreen;
    /*public Text WinText;*/ //win
    /*public GameObject finishScreen;*/ //finish

    public static Vector2 lastCheckPointPos = new Vector2(-3, 0);

    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;

    public CinemachineVirtualCamera VCam;
    public GameObject[] playerPrefabs;
    int characterIndex;

    private void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject player = Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, Quaternion.identity);
        VCam.m_Follow = player.transform;
        //numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        isGameOver = false;

    }

    void Update()
    {
        coinsText.text = numberOfCoins.ToString();
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    //finish
    //public void FinishGame()
    //{
    //    Time.timeScale = 0;
    //    finishScreen.SetActive(true);
    //}

    //win
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.tag == "Win")
    //    {
    //        WinText.gameObject.SetActive(true);
    //        Time.timeScale = 0;
    //    }
    //}

    public void Quit()
        {
            Application.Quit();
            Debug.Log("Quit");
        }


}



