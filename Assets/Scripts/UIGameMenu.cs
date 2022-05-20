using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UIGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject PanelVictory;
    [SerializeField] private GameObject PanelDefeat;
    [SerializeField] private GameObject overLay;
    [SerializeField] private Image[] Stars;
    [SerializeField] private Sprite StarActive;
    [SerializeField] private TextMeshProUGUI ScoreWin;
    [SerializeField] private TextMeshProUGUI ScoreDefeat;
    [SerializeField] private GameObject menuPause;

    private void Start()
    {
        Events.Victory.AddListener(OnPanelVictory);
        Events.Defeat.AddListener(OnPanelDefeat);
    }

    private void OnPanelVictory(int heart, int Score) 
    {
        Time.timeScale = 0;
        for (int i = 0; i < heart; i++) 
        {
            Stars[i].sprite = StarActive;
        }

        ScoreWin.text = "Score: " + Score.ToString();
        overLay.SetActive(true);
        PanelVictory.SetActive(true);
    }

    private void OnPanelDefeat(int hearth, int Score)
    {
        Time.timeScale = 0;
        ScoreDefeat.text = "Score: " + Score.ToString();
        overLay.SetActive(true);
        PanelDefeat.SetActive(true);
    }
    public void Restart()
    {
        int currLevel = 0;
        if (PlayerPrefs.HasKey("currLevel"))
        {
            currLevel = PlayerPrefs.GetInt("currLevel");
        }

        SceneManager.LoadScene(currLevel);
        Time.timeScale = 1;
    }
    public void NextLevel()
    {
        int currLevel = PlayerPrefs.GetInt("currLevel", 0);
        int MaxLevel = PlayerPrefs.GetInt("MaxLevel", 0);

        if (currLevel + 1 < MaxLevel)
        {
            SceneManager.LoadScene(currLevel + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }

        Time.timeScale = 1;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Play()
    {
        overLay.SetActive(false);
        menuPause.SetActive(false);
        Time.timeScale = 1;
    }

    public void Paused()
    {
        Time.timeScale = 0;
        menuPause.SetActive(true);
        overLay.SetActive(true);
    }

}
