using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Собирает монетки на поле
/// </summary>
public class MoneyCollector : MonoBehaviour
{
    public static event Action OnFinishCollect = delegate { };
    [SerializeField]
    private MoneyView view;
    [SerializeField]
    private CreateLevel level;

    private int maxCount;
    private int currentCount;

    private void Start()
    {
        maxCount = level.GetCountMoney();
        Money.OnCollect += Collector;
        view.ChangeText(currentCount, maxCount);
    }

    private void Collector()
    {
        currentCount++;
        view.ChangeText(currentCount, maxCount);
        if (currentCount == maxCount)
        {
            OnFinishCollect();
        }
    }

    private void OnDestroy()
    {
        Money.OnCollect -= Collector;
    }
}
