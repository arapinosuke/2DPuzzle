using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreViewer : MonoBehaviour
{
   ComboCounter m_comboCounter=>GetComponent<ComboCounter>();

    [SerializeField] TextMeshProUGUI m_scoreText;
    public int Score;

    public int MinusCombo = 5;

    private void Update()
    {
        m_scoreText.text = $"{m_comboCounter.CurrentComboCount}";
        Score = m_comboCounter.CurrentComboCount;
    }

    public void MinusScore()
    {
        Score = m_comboCounter.CurrentComboCount -= 5;
    }
}
