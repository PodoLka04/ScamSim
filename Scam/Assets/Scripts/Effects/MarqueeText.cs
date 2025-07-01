using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MarqueeText : MonoBehaviour
{
    public TextMeshProUGUI marqueeText;  // Ссылка на компонент текста
    public RectTransform rectTransform; // Ссылка на RectTransform текста
    public RectTransform panel;         // Панель, которая ограничивает движение текста
    public float speed = 100f;          // Скорость движения
    public List<string> messages;       // Список сообщений

    private float panelLeftEdge;        // Левая граница панели
    private float panelRightEdge;       // Правая граница панели

    void Start()
    {
        if (marqueeText == null || panel == null) return; // Проверка наличия текста и панели

        rectTransform = marqueeText.GetComponent<RectTransform>(); // Получаем RectTransform текста

        // Определяем позиции границ панели
        panelLeftEdge = panel.rect.xMin; // Левая граница панели
        panelRightEdge = panel.rect.xMax; // Правая граница панели

        StartCoroutine(ScrollText()); // Запускаем корутину
    }

    IEnumerator ScrollText()
    {
        while (true)
        {
            // Для каждого сообщения создаем отдельную корутину
            StartCoroutine(ScrollSingleMessage(messages[0])); // Начинаем движение с первого сообщения

            // Заменяем первое сообщение в списке
            messages.Add(messages[0]);
            messages.RemoveAt(0);

            yield return new WaitForSeconds(10f); // Задержка перед тем, как спавнить новое сообщение
        }
    }

    IEnumerator ScrollSingleMessage(string message)
    {
        marqueeText.text = message; // Устанавливаем текст

        // Рассчитываем ширину текста
        float textWidth = marqueeText.preferredWidth + 50f;

        // Устанавливаем начальную позицию текста за правую границу
        rectTransform.anchoredPosition = new Vector2(panelRightEdge, rectTransform.anchoredPosition.y);

        // Пока текст не выйдет за левую границу панели
        while (rectTransform.anchoredPosition.x + textWidth > panelLeftEdge)
        {
            rectTransform.anchoredPosition += Vector2.left * speed * Time.deltaTime;
            yield return null;
        }
    }
}
