using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Логика отображения конечного экрана
/// </summary>
public class ShowEndScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject winScreen;
    [SerializeField]
    private GameObject loseScreen;

    private void Awake()
    {
        MoneyCollector.OnFinishCollect += Win;
        Thorns.OnKill += Lose;
    }

    private void Win()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Lose()
    {
        loseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
        MoneyCollector.OnFinishCollect -= Win;
        Thorns.OnKill -= Lose;
    }
}
