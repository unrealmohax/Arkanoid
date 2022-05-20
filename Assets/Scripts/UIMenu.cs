using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private GameObject PanelLevelSelect;
    [SerializeField] private GameObject PanelSettings;
    [SerializeField] private GameObject OverLay;

    [SerializeField] private TextMeshProUGUI ButtonStartText;
    private int maximumLevel—ompleted = 0;

    private void Start()
    {
        if (PlayerPrefs.HasKey("maximumLevel—ompleted"))
        {
            maximumLevel—ompleted = PlayerPrefs.GetInt("maximumLevel—ompleted");
            if (maximumLevel—ompleted != 0)
            {
                ButtonStartText.text = "Continue";
            }
        }
    }

    public void StartGame()
    {
        int MaxLevel = PlayerPrefs.GetInt("MaxLevel", 0);

        if (maximumLevel—ompleted + 1 < MaxLevel)
        {
            SceneManager.LoadScene(maximumLevel—ompleted + 1);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    public void OnPanelLevelSelect() 
    {
        OverLay.SetActive(true);
        PanelLevelSelect.SetActive(true);
    }
    public void OnPanelSettings()
    {
        OverLay.SetActive(true);
        PanelSettings.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
