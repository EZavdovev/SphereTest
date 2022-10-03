using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/// <summary>
/// Логика отображения монет
/// </summary>
public class MoneyView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    private const string MASK = "{0}/{1} Монет"; 
    /// <summary>
    /// Метод для изменения текста отображения
    /// </summary>
    /// <param name="currentCount"> текущее число монет</param>
    /// <param name="maxCount">максимальное число монет</param>
    public void ChangeText(int currentCount, int maxCount)
    {
        text.text = string.Format(MASK, currentCount, maxCount);
    }
}
