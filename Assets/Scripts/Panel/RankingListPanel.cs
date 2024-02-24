using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RankingListPanel : BasePanel
{
    ScorePanel scorePanel;
    public Button btnClose;
    public Transform List;
    
    private void Awake()
    {
        btnClose.onClick.AddListener(OnbtnClose);
    }

    void OnbtnClose()
    {
        UIManager.Instance.ClosePanel(UIConst.RankingListPanel);
    }
    
    public void DisplayList()
    {
        for (int i = 0; i < GameManager.Instance.scoreList.Count; i++)
        {
            List.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = GameManager.Instance.scoreList[i].ToString();
        }
    }
}
