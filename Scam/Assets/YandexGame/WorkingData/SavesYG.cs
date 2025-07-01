
using TMPro;
using UnityEngine;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {

        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int money = 1;                       // Можно задать полям значения по умолчанию
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        // Ваши сохранения

        public int Score = 0;
        public int ClickScore = 1;
        public int CostInt = 100;
        public int hitrost = 0;

        public bool key1 = true;//открыл только пока панель открыта 
        public bool key2 = true;
        public bool key3 = true;
        public bool key4 = true;

        public bool boss1Win = false; // открыл раз и на всегда
        public bool boss2Win = false;
        public bool boss3Win = false;
        public bool boss4Win = false;

        public int upgradeCost = 1000;
        public bool isFirstTime = true;
        public bool key_kuzya = false;


        /*public TMP_Text upg0Text;
        public TMP_Text upg1Text;
        public TMP_Text upg2Text;
        public TMP_Text upg3Text;
        public TMP_Text upg4Text;
        public TMP_Text upg5Text;
        public TMP_Text upg6Text;*/ /*так нельзя*/
        public bool upg1Acsess = true;
        public bool upg2Acsess = false;
        public bool upg3Acsess = false;
        public bool upg4Acsess = false;
        public bool upg5Acsess = false;
        public bool upg6Acsess = false;
        public bool upg7Acsess = false;
        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны


        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива

            openLevels[1] = true;
        }
    }
}
