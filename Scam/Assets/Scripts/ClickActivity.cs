using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class ClickActivity : MonoBehaviour
{
    public TMP_Text ScoreText;           // Текст для отображения очков
    [SerializeField] private int upgradeCost = 300; // Стоимость улучшения
    private int score = 0;               // Инициализация переменной Score
    private int clickScore = 1;          // Инициализация переменной ClickScore

    private int upg1buy = 60;
    private int upg2buy = 120;
    private int upg3buy = 250;
    private int upg4buy = 700;
    private int upg5buy = 3000;
    private int upg6buy = 6000;
    
    public TMP_Text hitrostText;

    public TMP_Text upg0Text;
    public TMP_Text upg1Text;
    public TMP_Text upg2Text;
    public TMP_Text upg3Text;
    public TMP_Text upg4Text;
    public TMP_Text upg5Text;
    public TMP_Text upg6Text;

    public GameObject panel3ToRemove;
    public GameObject panel4ToRemove;
    public GameObject panel5ToRemove;
    public GameObject panel6ToRemove;
    public GameObject panel7ToRemove;

    public GameObject StartPanel;


    void Start()
    {
        if (Data.Instance.keyStartPanel == 0)
        {
            StartPanel.SetActive(true);
            Data.Instance.keyStartPanel += 1;
        }
        else 
        {
            StartPanel.SetActive(false);
        }

        // Получаем значения из класса Data
        score = Data.Instance.GetScore();
        clickScore = Data.Instance.GetClickScore();
        upgradeCost = Data.Instance.GetupgradeCost();
    }


    public void Update()
    {
        // Обновляем текст на экране
        ScoreText.text = Data.Instance.score + " коинов";
        hitrostText.text = "Хитрость: " + Data.Instance.hitrost;

        if (Data.Instance.upg2Acsess || Data.Instance.upg3Acsess || Data.Instance.upg4Acsess || Data.Instance.upg5Acsess || Data.Instance.upg6Acsess || Data.Instance.upg7Acsess)
        {
            upg1Text.text = "Пройдено";
            panel3ToRemove.SetActive(false);
        }
        if (Data.Instance.upg3Acsess || Data.Instance.upg4Acsess || Data.Instance.upg5Acsess || Data.Instance.upg6Acsess || Data.Instance.upg7Acsess)
        {
            upg2Text.text = "Пройдено";
            panel4ToRemove.SetActive(false);

        }
        if ( Data.Instance.upg4Acsess || Data.Instance.upg5Acsess || Data.Instance.upg6Acsess || Data.Instance.upg7Acsess)
        {
            upg3Text.text = "Пройдено";
            panel5ToRemove.SetActive(false);

        }
        if (Data.Instance.upg5Acsess || Data.Instance.upg6Acsess || Data.Instance.upg7Acsess)
        {
            upg4Text.text = "Пройдено";
            panel6ToRemove.SetActive(false);

        }
        if (Data.Instance.upg6Acsess || Data.Instance.upg7Acsess)
        {
            upg5Text.text = "Пройдено";
            panel7ToRemove.SetActive(false);

        }
        if (Data.Instance.upg7Acsess)
        {
            upg6Text.text = "Пройдено";
        }
    }


    public void OnClickButton()
    {
        Data.Instance.score += Data.Instance.clickScore; // Добавляем clickScore к score
    }

    public void upg1ButtonBuy()
    {
        if ((Data.Instance.score >= upg1buy) && (Data.Instance.upg1Acsess))
        {
            Data.Instance.clickScore += 1;
            Data.Instance.score -= upg1buy;
            Data.Instance.upg2Acsess = true;
            Data.Instance.upg1Acsess = false;
        }
    }
    public void upg2ButtonBuy()
    {
        if ((Data.Instance.score >= upg2buy) && (Data.Instance.upg2Acsess))
        {
            Data.Instance.clickScore += 1;
            Data.Instance.hitrost = 1;
            Data.Instance.score -= upg2buy;
            Data.Instance.upg3Acsess = true;
            Data.Instance.upg2Acsess = false;
        }
    }
    public void upg3ButtonBuy()
    {
        if ((Data.Instance.score >= upg3buy) && (Data.Instance.upg3Acsess))
        {
            Data.Instance.clickScore += 2;
            Data.Instance.score -= upg3buy;
            Data.Instance.upg4Acsess = true;
            Data.Instance.upg3Acsess = false;
        }
    }
    public void upg4ButtonBuy()
    {
        if ((Data.Instance.score >= upg4buy) && (Data.Instance.upg4Acsess))
        {
            Data.Instance.clickScore += 2;
            Data.Instance.hitrost = 2;
            Data.Instance.score -= upg4buy;
            Data.Instance.upg5Acsess = true;
            Data.Instance.upg4Acsess = false;
        }
    }
    public void upg5ButtonBuy()
    {
        if ((Data.Instance.score >= upg5buy) && (Data.Instance.upg5Acsess))
        {
            Data.Instance.clickScore += 2;
            Data.Instance.hitrost = 3;
            Data.Instance.score -= upg5buy;
            Data.Instance.upg6Acsess = true;
            Data.Instance.upg5Acsess = false;
        }
    }
    public void upg6ButtonBuy()
    {
        if ((Data.Instance.score >= upg6buy) && (Data.Instance.upg6Acsess))
        {
            Data.Instance.score -= upg6buy;
            Data.Instance.hitrost = 4;
            Data.Instance.upg6Acsess = false;
            Data.Instance.upg7Acsess = true;
            Data.Instance.clickScore += 2;
        }
    }

    public void closeStartpanel()
    { 
        StartPanel.SetActive(false);
    }
}