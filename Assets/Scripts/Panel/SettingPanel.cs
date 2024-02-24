using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SettingPanel : BasePanel
{
    public Button btnClose;
    private void Awake()
    {
        btnClose.onClick.AddListener(OnBtnClose);
    }
    public void OnBtnClose()
    {
        print("OnBtnClose");
        UIManager.Instance.ClosePanel(UIConst.SettingsPanel);
    }
}
