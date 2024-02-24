using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControlPanel : BasePanel
{
    public Button btnPause;
    public Button btnL;
    public Button btnR;
    public bool isUsingVKL;
    public bool isUsingVKR;
    public bool isUsingVK;
    public int direction;

    private void Awake()
    {
        btnPause.onClick.AddListener(OnbtnPause);
    }
    void OnbtnPause()
    {
        if (UIManager.Instance.panelDict.ContainsKey(UIConst.PausePanel))
        {
            Time.timeScale = 1;
            UIManager.Instance.ClosePanel(UIConst.PausePanel);
        }
        else
        {
            Time.timeScale = 0;
            UIManager.Instance.OpenPanel(UIConst.PausePanel);
        }
    }
    public void OnbtnLDown()
    {
        isUsingVKL = true;
    }
    public void OnbtnRDown()
    {
        isUsingVKR = true;
    }
    public void OnbtnLUp()
    {
        isUsingVKL = false;
    }
    public void OnbtnRUp()
    {
        isUsingVKR = false;
    }


}
