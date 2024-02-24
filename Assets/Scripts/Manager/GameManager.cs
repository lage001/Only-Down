using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public enum State
{
    BeforeMenu,
    BeforeGame,
    Menu,
    Game,
    GameOver,
    Empty,
}
public class GameManager : SingletonBase<GameManager>
{
    
    RankingList rankingList;
    //public ChoseCharacter choseCharacter;
    TextMeshProUGUI scoreText;
    public List<int> scoreList;

    public static int playerNum;
    public int checkNum = 0;
    public MainPanel mainPanel;
    public ControlPanel controlPanel;
    public ScorePanel scorePanel;
    GameObject player;

    AsyncOperation asyncLoad;
    bool isLoading;
    public State state;
    public State originState = State.BeforeMenu;

    List<GameObject> prefabList = new List<GameObject>();

    protected override void Awake()
    {
        base.Awake();
        isLoading = false;
        rankingList = Resources.Load<RankingList>("ScriptableObject/RankingList");
        scoreList = rankingList.rankingList;
        prefabList.Add(Resources.Load<GameObject>("Prefabs/Player/Dude"));
        prefabList.Add(Resources.Load<GameObject>("Prefabs/Player/Frog"));
        prefabList.Add(Resources.Load<GameObject>("Prefabs/Player/Pink"));
        prefabList.Add(Resources.Load<GameObject>("Prefabs/Player/Guy"));
        state = originState;
        
    }

    private void Update()
    {
        switch (state)
        {
            case State.BeforeMenu:
                OnBeforeMenu();
                break;
            case State.Menu:
                OnMenuState();
                break;
            case State.BeforeGame:
                OnBeforeGame();
                break;
            case State.Game:
                OnGameState();
                break;
            case State.GameOver:
                OnGameOverState();
                break;
            case State.Empty:
                break;
            default:
                break;
        }
    }
    public void ChangeToState(State nextState)
    {
        state = nextState;
    }
    void OnBeforeMenu()
    {
        if (!isLoading)
        {
            StartCoroutine(LoadScene(0));
            isLoading = true;
        }
        else if(asyncLoad.isDone)
        {
            isLoading = false;

            UIManager.Instance.panelDict.Clear();
            print(SceneManager.GetActiveScene().buildIndex);
            UIManager.Instance.CheckPanel<MainPanel>();
            mainPanel = UIManager.Instance.panelDict[UIConst.MainPanel] as MainPanel;
            ChangeToState(State.Menu);
        }
    }
    void OnMenuState()
    {
    }
    void OnBeforeGame()
    {
        if (!isLoading)
        {
            StartCoroutine(LoadScene(1));
            isLoading = true;
        }
        else if (asyncLoad.isDone)
        {
            isLoading = false;

            UIManager.Instance.panelDict.Clear();
            UIManager.Instance.CheckPanel<ScorePanel>();
            UIManager.Instance.CheckPanel<ControlPanel>();
            scorePanel = UIManager.Instance.panelDict[UIConst.ScorePanel] as ScorePanel;
            controlPanel = UIManager.Instance.panelDict[UIConst.ControlPanel] as ControlPanel;
            
            player = Instantiate(prefabList[playerNum], new Vector3(0, 5, 0), Quaternion.identity);
            ChangeToState(State.Game);
        }  
    }
    void OnGameState()
    {

        scoreText = scorePanel.scoreText;
        if (player.GetComponent<PlayerContoller>().isDead)
        {
            ChangeToState(State.GameOver);
        }
    }
    void OnGameOverState()
    {

        StartCoroutine(EndGame());
        ChangeToState(State.Empty);
    }
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
        UIManager.Instance.OpenPanel(UIConst.RestartPanel);
        UpdateRankingList();
    }

    IEnumerator LoadScene(int sceneIndex)
    {
        asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);
        asyncLoad.allowSceneActivation = true;
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void UpdateRankingList()
    {
        scoreList.Add(int.Parse(scoreText.text));
        scoreList.Sort((x, y) => -x.CompareTo(y));
        if (scoreList.Count == 11)
        {
            print("removed");
            scoreList.RemoveAt(10);
        }
    }
}
