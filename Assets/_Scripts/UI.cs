using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;
    [SerializeField] private TextMeshProUGUI[] scoreTexts;
    [SerializeField] private TextMeshProUGUI drawAmountText;

    public void UpdateScoreText(int score, int textMeshIndex)
    {
        scoreTexts[textMeshIndex].text = score.ToString();
    }

    public void UpdateDrawAmountText(int totalAmount)
    {
        drawAmountText.text = totalAmount.ToString();
    }
    public void PanelController(bool setActive, int panelIndex)
    {
        panels[panelIndex].gameObject.SetActive(setActive);
    }
}
