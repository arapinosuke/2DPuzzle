using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LimitTimeCountViewer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_Timetext;
    private float m_limitTime;

    private void Start()
    {
        m_limitTime = 60f;
    }

    private void Update()
    {
        m_limitTime -= Time.deltaTime;
        m_Timetext.text = $"{m_limitTime}";
    }
}
