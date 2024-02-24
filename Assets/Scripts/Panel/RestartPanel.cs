using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RestartPanel : BasePanel
{
    public Button btnHome;
    public Button btnRankingList;
    public Button btnRestart;

    private void Awake()
    {
        btnHome.onClick.AddListener(OnbtnHome);
        btnRankingList.onClick.AddListener(OnbtnRankingList);
        btnRestart.onClick.AddListener(OnbtnRestart);

    }
    void OnbtnHome()
    {
        Time.timeScale = 1;
        UIManager.Instance.panelDict.Clear();
        SceneManager.LoadScene(0);
        GameManager.Instance.ChangeToState(State.BeforeMenu);
    }
    void OnbtnRankingList()
    {
        RankingListPanel rankingListPanel = UIManager.Instance.OpenPanel(UIConst.RankingListPanel) as RankingListPanel;
        rankingListPanel.DisplayList();
    }
    void OnbtnRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        GameManager.Instance.ChangeToState(State.BeforeGame);
    }
}
