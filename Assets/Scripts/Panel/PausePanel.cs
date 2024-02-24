using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : BasePanel
{
    public Button btnHome;
    public Button btnRankingList;
    public Button btnRestart ;
    public Button btnClose;


    private void Awake()
    {
        btnHome.onClick.AddListener(OnbtnHome);
        btnRankingList.onClick.AddListener(OnbtnRankingList);
        btnRestart.onClick.AddListener(OnbtnRestart);
        btnClose.onClick.AddListener(OnbtnClose);

    }
    void OnbtnHome()
    {
        Time.timeScale = 1;
        UIManager.Instance.panelDict.Clear();
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
    void OnbtnClose()
    {
        Time.timeScale = 1;
        UIManager.Instance.ClosePanel(UIConst.PausePanel);
    }
}
