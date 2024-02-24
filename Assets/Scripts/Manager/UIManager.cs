using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class UIManager : SingletonBase<UIManager>
{
    
    //����Ԥ����·�������ֵ�
    public Dictionary<string, string> pathDict;
    //����Ԥ���建���ֵ�
    public Dictionary<string, GameObject> prefabDict;
    //�Ѵ򿪽���Ļ����ֵ�
    public Dictionary<string, BasePanel> panelDict;
    Transform _uiRoot;

    protected override void  Awake()
    {
        base.Awake();
    }
    UIManager()
    {
        InitDicts();
    }

    public Transform UIRoot(string panelName)
    {
        
        print(GameObject.Find("ScoreCanvas") == null);
        print(GameObject.Find("Canvas") == null);

        _uiRoot = panelName == "ScorePanel"? GameObject.Find("ScoreCanvas").transform: GameObject.Find("Canvas").transform;
        return _uiRoot;

    }
    void InitDicts()
    {
        prefabDict = new Dictionary<string, GameObject>();
        panelDict = new Dictionary<string, BasePanel>();
        pathDict = new Dictionary<string, string>()
        {
            {UIConst.MainPanel,"Menu/MainPanel"},
            {UIConst.SettingsPanel, "Menu/SettingsPanel" },
            {UIConst.ControlPanel, "Game/ControlPanel" },
            {UIConst.PausePanel, "Game/PausePanel" },
            {UIConst.RankingListPanel, "Game/RankingListPanel" },
            {UIConst.RestartPanel, "Game/RestartPanel" },
            {UIConst.ScorePanel, "Game/ScorePanel" },
        };
    }
    public T CheckPanel<T>() where T:BasePanel
    {
        
        T panel = FindObjectOfType(typeof(T)) as T;
        string name = typeof(T).ToString();
        if (panel == null)
        {
            print(name);
            return OpenPanel(name) as T;
        }
        else
        {
            panelDict.Add(name,panel);
            return panel;
        }
    }
    public BasePanel OpenPanel(string name)
    {
        //����Ƿ��Ѿ���
        if (panelDict.TryGetValue(name, out BasePanel panel))
        {
            return panel;
        }
        //���·���Ƿ�������
        if (!pathDict.TryGetValue(name, out string path))
        {
            Debug.LogError("�������ƴ��󣬻���δ����·����" + name);
            return null;
        }
        //ʹ�û����Ԥ����
        if (!prefabDict.TryGetValue(name, out GameObject panelPrefab))
        {   
            string realPath = "Prefabs/Panel/" + path;
            panelPrefab = Resources.Load<GameObject>(realPath);
            prefabDict.Add(name, panelPrefab);
        }
        //�򿪽���
        GameObject panelObject = Instantiate(panelPrefab, UIRoot(name), false);
        panelObject.SetActive(true);
        panel = panelObject.GetComponent<BasePanel>();
        panelDict.Add(name, panel);
        return panel;
    }


    public void ClosePanel(string name)
    {
        if(!panelDict.ContainsKey(name))
        {
            Debug.LogError("����δ�򿪣�" + name);
            return;
        }
        GameObject gameObject = GameObject.Find(name + "(Clone)");
        gameObject.SetActive(false);
        Destroy(gameObject);
        panelDict.Remove(name);
    }

}
public class UIConst
{
    public const string MainPanel = "MainPanel";
    public const string SettingsPanel = "SettingsPanel";
    public const string ControlPanel = "ControlPanel"; 
    public const string PausePanel = "PausePanel";
    public const string RankingListPanel = "RankingListPanel";
    public const string RestartPanel = "RestartPanel";
    public const string ScorePanel = "ScorePanel";
}



