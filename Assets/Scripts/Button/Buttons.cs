using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject panel;
    //public GameObject RankingListPanel;
    public GameObject ListPanel;
    // Start is called before the first frame update
    public void OnclickSetting()
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    //public void OnclickClose()
    //{
    //    panel.SetActive(false);
    //    Time.timeScale = 1;
    //}
    public void LoadHomeScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void OpenListPanel()
    {
        ListPanel.SetActive(true);
    }

}
