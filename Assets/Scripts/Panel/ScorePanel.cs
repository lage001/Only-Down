using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePanel : BasePanel
{
    public TextMeshProUGUI scoreText;
    float timer;
    private int m_Minute;//·Ö
    private int m_Second;//Ãë
    private void Start()
    {
        timer = 0;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        m_Second = (int)timer;
       
        if (m_Second >= 60.0f)
        {
            m_Second = (int)(timer - (m_Minute * 60));
            m_Minute = (int)(timer / 60);
            scoreText.text = m_Minute.ToString() + "'" + m_Second.ToString();
        }
        else
        {
            scoreText.text = m_Second.ToString();
        }
    }
}


