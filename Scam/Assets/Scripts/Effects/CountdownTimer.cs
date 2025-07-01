using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TMP_Text timerText; // UI-текст для таймера
    public Button resetButton; // Кнопка сброса
    public Button resetButton2; // Кнопка сброса 2

    private float timeRemaining = 60f; // 1 минута
    private bool isRunning = false; // Таймер запускается только после нажатия кнопки
    private bool isFlashing = false; // Флаг мигания

    void Start()
    {
        resetButton.onClick.AddListener(ResetTimer);
        resetButton2.onClick.AddListener(ResetTimer);

    }

    void Update()
    {
        if (isRunning)
        {
            timeRemaining -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(Mathf.Abs(timeRemaining) / 60);
            int seconds = Mathf.FloorToInt(Mathf.Abs(timeRemaining) % 60);
            int milliseconds = Mathf.FloorToInt((Mathf.Abs(timeRemaining) % 1) * 100);

            // Добавляем знак "минус", если таймер ушел в отрицательное значение
            string sign = timeRemaining < 0 ? "-" : "";

            timerText.text = string.Format("{0}{1:00}:{2:00}:{3:00}", sign, minutes, seconds, milliseconds);

            // Запускаем мигание, если осталось 10 секунд или меньше
            if (timeRemaining <= 10f && !isFlashing)
            {
                isFlashing = true;
                StartCoroutine(FlashText());
            }
        }
    }

    void ResetTimer()
    {
        timeRemaining = 60f; // Сбрасываем на 1 минуту
        isRunning = true; // Запускаем заново
        isFlashing = false; // Останавливаем мигание
        timerText.color = Color.white; // Возвращаем обычный цвет
    }

    IEnumerator FlashText()
    {
        while (timeRemaining <= 10f)
        {
            timerText.color = Color.red; // Красный цвет
            yield return new WaitForSeconds(0.2f);
            timerText.color = Color.white; // Белый цвет
            yield return new WaitForSeconds(0.2f);
        }
    }
}
