using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using YG;

public class Boss3 : MonoBehaviour
{
    public int playerHealth = 100;         // Здоровье игрока
    public int bossHealth = 600;           // Здоровье босса
    public float playerHealthLossRate = 5f; // Скорость потери здоровья игрока за секунду

    public Slider playerHealthSlider;      // Слайдер для отображения здоровья игрока
    public Slider bossHealthSlider;        // Слайдер для отображения здоровья босса
    public Button attackButton;            // Кнопка для атаки

    private bool isFighting = true;        // Флаг для проверки, продолжается ли битва

    public GameObject boss3suget1Pan;
    public GameObject boss3suget2Pan;
    public GameObject boss3FinalWinPan;
    public GameObject boss3FinalLosePan;

    void Start()
    {
        boss3suget1Pan.SetActive(true);
        boss3suget2Pan.SetActive(false);
        boss3FinalWinPan.SetActive(false);
        boss3FinalLosePan.SetActive(false);


        // Инициализируем полоски здоровья
        playerHealthSlider.maxValue = playerHealth;
        playerHealthSlider.value = playerHealth;

        bossHealthSlider.maxValue = bossHealth;
        bossHealthSlider.value = bossHealth;

        // Привязываем событие клика по кнопке
        attackButton.onClick.AddListener(AttackBoss);

    }

    // Метод атаки босса
    public void AttackBoss()
    {
        if (!isFighting) return;  // Если битва окончена, ничего не делаем



        // Наносим урон боссу
        int playerAttack = Data.Instance.GetClickScore();
        bossHealth -= playerAttack;
        bossHealth = Mathf.Max(bossHealth, 0); // Убеждаемся, что здоровье босса не отрицательное
        bossHealthSlider.value = bossHealth;

        Debug.Log("Игрок нанес " + playerAttack + " урона боссу.");

        // Проверяем, победил ли игрок
        if (bossHealth <= 0)
        {
            EndFight(true);  // Победа игрока
        }
    }

    // Корутина для уменьшения здоровья игрока с течением времени
    private IEnumerator PlayerHealthLossOverTime()
    {
        while (isFighting)
        {
            yield return new WaitForSeconds(1f);  // Ждём 1 секунду

            playerHealth -= (int)playerHealthLossRate;  // Уменьшаем здоровье игрока
            playerHealth = Mathf.Max(playerHealth, 0); // Убеждаемся, что здоровье игрока не отрицательное
            playerHealthSlider.value = playerHealth;

            // Проверяем, проиграл ли игрок
            if (playerHealth <= 0)
            {
                EndFight(false);  // Поражение игрока
            }
        }
    }

    // Метод, который завершает битву
    void EndFight(bool playerWon)
    {
        isFighting = false;  // Останавливаем битву

        if (playerWon)
        {
            Debug.Log("Игрок победил!");
            Data.Instance.Setboss3Win(true); //типо победили!!!!!!
            
            boss3FinalWinPan.SetActive(true);

            // Логика для победы (например, переход на следующую сцену)
        }
        else
        {
            Debug.Log("Игрок проиграл...");
            boss3FinalLosePan.SetActive(true);

        }

        // Отключаем кнопку атаки
        attackButton.interactable = false;
    }

    public void To2Sugetpanel()
    {
        boss3suget1Pan.SetActive(false);
        boss3suget2Pan.SetActive(true);
    }

    public void ToBoss()
    {
        boss3suget2Pan.SetActive(false);

        // Запускаем уменьшение здоровья игрока с течением времени
        StartCoroutine(PlayerHealthLossOverTime());
    }
    public void AfterFight()
    {
        boss3FinalWinPan.SetActive(false);
        boss3FinalLosePan.SetActive(false);

        SceneManager.LoadScene("Main"); // Укажите имя начальной сцены
        YandexGame.FullscreenShow();

    }
}