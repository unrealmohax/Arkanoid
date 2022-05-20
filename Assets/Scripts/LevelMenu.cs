using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Doozy;

public class LevelMenu : MonoBehaviour
{
    private int currPage = 0;
    [SerializeField] private GameObject[] Pages;
    [SerializeField] private Selectable[] LevelButtons;
    [SerializeField] private GameObject[] BlockButtons;
    [SerializeField] private Image[] Stars; 
    [SerializeField] private Sprite StarActive;
    [SerializeField] private GameObject Overlay;
    [SerializeField] private GameObject PanelSettings; 

    private void Start()
    {
        OpenLevel();
        PlayerPrefs.SetInt("MaxLevel", LevelButtons.Length);
    }

    public void NextPageLevel ()
    {
        currPage++;
        DisplayPage(currPage);
    }

    public void BackPageLevel()
    {
        currPage--;
        DisplayPage(currPage);
    }

    private void DisplayPage(int Page) 
    {
        for (int i = 0; i < Pages.Length; i++)
        {
            if (i == currPage)
            {
                Pages[i].SetActive(true);
            }
            else 
            {
                Pages[i].SetActive(false);
            }
        }
    }

    public void LoadLevel(int Level) 
    {
        SceneManager.LoadScene(Level);
    }

    private void OpenLevel() 
    {
        int maximumLevelÑompleted = 0;
        int heart = 0;

        if (PlayerPrefs.HasKey("maximumLevelÑompleted"))
        {
            maximumLevelÑompleted = PlayerPrefs.GetInt("maximumLevelÑompleted");
        }

        for (int i = 0; i <= maximumLevelÑompleted && i < LevelButtons.Length; i++)
        {
            if (PlayerPrefs.HasKey("lvl"+ (i + 1).ToString()))
            {
                heart = PlayerPrefs.GetInt("lvl" + (i + 1).ToString());

                for (int k = 3 * i; k < heart + 3 * i; k++)
                {
                    Stars[k].sprite = StarActive;
                }
            }

            for (int k = 3 * i; k < i * 3 + 3; k++)
            {
                Stars[k].gameObject.SetActive(true);
            }

            LevelButtons[i].interactable = true;
            BlockButtons[i].SetActive(false);
        }
    }

    public void ClosePanelLevelSelect() 
    {
        for (int i = 0; i < Pages.Length; i++) 
        {
            Pages[i].SetActive(false);
        }
        
        Overlay.SetActive(false);
        currPage = 0;
    }

    public void ClosePanelSettings()
    {
        PanelSettings.SetActive(false);

        Overlay.SetActive(false);
    }
}
