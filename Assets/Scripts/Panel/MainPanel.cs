using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MainPanel : BasePanel
{

    public Button btnSetting;
    public Button btnSelectionL;
    public Button btnSelectionR;
    public ScrollController scrollController;
    public List<Button> characters;

    



    private void Awake()
    {
        btnSetting.onClick.AddListener(OnBtnSetting);
        btnSelectionL.onClick.AddListener(OnBtnSelectionL);
        btnSelectionR.onClick.AddListener(OnBtnSelectionR);
        for (int i = 0; i < characters.Count; i++)
        {
            int temp = i;
            characters[temp].onClick.AddListener(() =>
            {
                GameManager.playerNum =temp;
                GameManager.Instance.ChangeToState(State.BeforeGame);
                
            });
        }
    }

    void OnBtnSetting()
    {
        print("OnBtnSetting");
        if (UIManager.Instance.panelDict.ContainsKey(UIConst.SettingsPanel))
        {
            UIManager.Instance.ClosePanel(UIConst.SettingsPanel);
        }
        else
        {
            UIManager.Instance.OpenPanel(UIConst.SettingsPanel);
        }
    }
    void OnBtnSelectionL()
    {
        scrollController.scrollPos -= 1;
    }
    void OnBtnSelectionR()
    {
        scrollController.scrollPos += 1;
    }

}
