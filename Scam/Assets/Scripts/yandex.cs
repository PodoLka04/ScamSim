using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using YG;
using UnityEngine.UI;


public class yandex : MonoBehaviour
{

    public static yandex Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Сохраняем объект между сценами
        }
        else
        {
            Destroy(gameObject); // Удаляем дубликаты
        }
    }


    public void uioi()
    {
        YandexGame.FullscreenShow();
    }

    //===========================================================================================================================
    void Start()
    {
        
        if (YandexGame.SDKEnabled == true)
        {
            LoadSaveCloud();
        }
        //-------------------------------------------------------------------среда сохранения каждые 2 секунды---------------------------------------------------
        StartCoroutine(SaveCoroutine());

    }

    /*private void Update()
    {
        if (!buttonVisible)
        {
            timer -= Time.deltaTime; // Уменьшаем таймер
            if (timer <= 0)
            {
                ShowButton(); // Показываем кнопку, когда таймер обнуляется
            }
        }
    }

    public Button buttonToShow; // Ссылка на кнопку, которая будет появляться
    private float timer = 60f; // Таймер в секундах
    private bool buttonVisible = false; // Состояние видимости кнопки


    // Корутин для показа кнопки раз в минуту
    IEnumerator ShowButtonRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(60f); // Ждём минуту
            if (!buttonVisible)
            {
                ShowButton(); // Показываем кнопку
            }
        }
    }

    // Метод для показа кнопки
    void ShowButton()
    {
        buttonToShow.gameObject.SetActive(true); // Показываем кнопку
        buttonVisible = true; // Обновляем состояние
    }

    // Метод вызывается при нажатии на кнопку
    public void OnButtonClicked()
    {
        buttonToShow.gameObject.SetActive(false); // Скрываем кнопку
        buttonVisible = false; // Обновляем состояние
        timer = 100f; // Сбрасываем таймер на минуту
    }

    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Reward;//хз че это
        YandexGame.GetDataEvent += LoadSaveCloud;//хз че это
    }
    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Reward;//хз че это
        YandexGame.GetDataEvent -= LoadSaveCloud;
    }

    public void Reward(int id)
    {
        Data.Instance.SetScore(500);
    }

    public void ADVbutt()
    {
        YandexGame.RewVideoShow(1);
    }*/
   

    //===========================================================================================================================

    public void LoadSaveCloud()//функцию вызываю при старте игры
    {
        Data.Instance.score = YandexGame.savesData.Score;
        Data.Instance.clickScore = YandexGame.savesData.ClickScore;
        Data.Instance.hitrost = YandexGame.savesData.hitrost;

        Data.Instance.key1 = YandexGame.savesData.key1;
        Data.Instance.key2 = YandexGame.savesData.key2;
        Data.Instance.key3 = YandexGame.savesData.key3;
        Data.Instance.key4 = YandexGame.savesData.key4;

        Data.Instance.boss1Win = YandexGame.savesData.boss1Win; // открыл раз и на всегда
        Data.Instance.boss2Win = YandexGame.savesData.boss2Win;
        Data.Instance.boss3Win = YandexGame.savesData.boss3Win;
        Data.Instance.boss4Win = YandexGame.savesData.boss4Win;

        Data.Instance.upgradeCost = YandexGame.savesData.upgradeCost;
        Data.Instance.isFirstTime = YandexGame.savesData.isFirstTime;
        Data.Instance.key_kuzya = YandexGame.savesData.key_kuzya;

        /*Data.Instance.upg0Text = YandexGame.savesData.upg0Text;
        Data.Instance.upg1Text = YandexGame.savesData.upg1Text;
        Data.Instance.upg2Text = YandexGame.savesData.upg2Text;
        Data.Instance.upg3Text = YandexGame.savesData.upg3Text;
        Data.Instance.upg4Text = YandexGame.savesData.upg4Text;
        Data.Instance.upg5Text = YandexGame.savesData.upg5Text;
        Data.Instance.upg6Text = YandexGame.savesData.upg6Text;*/

        Data.Instance.upg1Acsess = YandexGame.savesData.upg1Acsess;
        Data.Instance.upg2Acsess = YandexGame.savesData.upg2Acsess;
        Data.Instance.upg3Acsess = YandexGame.savesData.upg3Acsess;
        Data.Instance.upg4Acsess = YandexGame.savesData.upg4Acsess;
        Data.Instance.upg5Acsess = YandexGame.savesData.upg5Acsess;
        Data.Instance.upg6Acsess = YandexGame.savesData.upg6Acsess;
        Data.Instance.upg7Acsess = YandexGame.savesData.upg7Acsess;


    }

    public void MySafe()//функцию вызываю каждые 2 секунды
    {
        YandexGame.savesData.Score = Data.Instance.score;
        YandexGame.savesData.ClickScore = Data.Instance.clickScore;
        YandexGame.savesData.hitrost = Data.Instance.hitrost;

        YandexGame.savesData.key1 = Data.Instance.key1;
        YandexGame.savesData.key2 = Data.Instance.key2;
        YandexGame.savesData.key3 = Data.Instance.key3;
        YandexGame.savesData.key4 = Data.Instance.key4;

        YandexGame.savesData.boss1Win = Data.Instance.boss1Win; ; // открыл раз и на всегда
        YandexGame.savesData.boss2Win = Data.Instance.boss2Win; ;
        YandexGame.savesData.boss3Win = Data.Instance.boss3Win; ;
        YandexGame.savesData.boss4Win = Data.Instance.boss4Win; ;

        YandexGame.savesData.upgradeCost = Data.Instance.upgradeCost;
        YandexGame.savesData.isFirstTime = Data.Instance.isFirstTime;
        YandexGame.savesData.key_kuzya = Data.Instance.key_kuzya;

        /*YandexGame.savesData.upg0Text = Data.Instance.upg0Text;
        YandexGame.savesData.upg1Text = Data.Instance.upg1Text;
        YandexGame.savesData.upg2Text = Data.Instance.upg2Text;
        YandexGame.savesData.upg3Text = Data.Instance.upg3Text;
        YandexGame.savesData.upg4Text = Data.Instance.upg4Text;
        YandexGame.savesData.upg5Text = Data.Instance.upg5Text;        
        YandexGame.savesData.upg6Text = Data.Instance.upg6Text;*/

        YandexGame.savesData.upg1Acsess = Data.Instance.upg1Acsess;
        YandexGame.savesData.upg2Acsess = Data.Instance.upg2Acsess;
        YandexGame.savesData.upg3Acsess = Data.Instance.upg3Acsess;
        YandexGame.savesData.upg4Acsess = Data.Instance.upg4Acsess;
        YandexGame.savesData.upg5Acsess = Data.Instance.upg5Acsess;
        YandexGame.savesData.upg6Acsess = Data.Instance.upg6Acsess;
        YandexGame.savesData.upg7Acsess = Data.Instance.upg7Acsess;

        YandexGame.SaveProgress();
    }
    private IEnumerator SaveCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f); // Ждем 2 секунды

            MySafe(); // Вызываем метод сохранения каждые 2 сек
        }
    }

}
