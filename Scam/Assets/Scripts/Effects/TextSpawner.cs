using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Для работы с TextMeshPro

public class TextSpawner : MonoBehaviour
{
    [SerializeField] private Button button;                       // Ссылка на кнопку
    [SerializeField] private GameObject textPrefab;               // Префаб текста
    [SerializeField] private float effectDuration = 1f;           // Время до удаления текста
    [SerializeField] private RectTransform spawnPanel;            // Конкретная панель для спавна текста
    [SerializeField] public int clickValue = 1;                  // Количество очков за клик (можно изменять)

    void Start()
    {
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    void OnButtonClick()
    {
        SpawnTextAtRandomPosition();
    }

    void SpawnTextAtRandomPosition()
    {
        // Создаем экземпляр текста и делаем его дочерним элементом панели, а не кнопки
        GameObject textInstance = Instantiate(textPrefab, spawnPanel);  // Родитель - конкретная панель
        RectTransform textRectTransform = textInstance.GetComponent<RectTransform>();
        TextMeshProUGUI textComponent = textInstance.GetComponent<TextMeshProUGUI>();

        // Устанавливаем значение текста в зависимости от силы клика
        textComponent.text = $"+{Data.Instance.clickScore}";

        // Генерируем случайные координаты внутри конкретной панели
        float randomX = Random.Range(-spawnPanel.rect.width / 2, spawnPanel.rect.width / 2);
        float randomY = Random.Range(-spawnPanel.rect.height / 2, spawnPanel.rect.height / 2);

        // Устанавливаем позицию текста относительно панели
        textRectTransform.anchoredPosition = new Vector2(randomX, randomY);

        // Сбрасываем вращение текста, чтобы он не вращался с кнопкой
        textRectTransform.rotation = Quaternion.identity;

        // Запускаем корутину для удаления текста через короткое время, чтобы не блокировать кнопку
        StartCoroutine(RemoveEffectAfterTime(textInstance, effectDuration));
    }

    private IEnumerator RemoveEffectAfterTime(GameObject effect, float delay)
    {
        // Даем времени на отображение текста
        yield return new WaitForSeconds(delay);
        Destroy(effect);
    }
}
