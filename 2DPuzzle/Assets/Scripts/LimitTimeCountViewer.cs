using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LimitTimeCountViewer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_Timetext = null;
    public float m_limitTime=0f;

    //DevilOrbに触れると5秒縮む
    public float MinusSeconds = 5f;

    //3コンボより多く消した時に5秒追加
    public float PlusSeconds = 5f;

    private void Start()
    {
        m_limitTime = 60f;
    }

    public void MinusTime()
    {
        m_limitTime-=MinusSeconds;
    }

    public void PlusTime()
    {
        m_limitTime += PlusSeconds;
    }

    private void Update()
    {
        m_limitTime -= Time.deltaTime;
        m_Timetext.text = $"{m_limitTime}";
    }
}
