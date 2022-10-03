using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Скрипт для обработки смерти игрока
/// </summary>
public class Player : MonoBehaviour
{
    private void Awake()
    {
        Thorns.OnKill += Die;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Thorns.OnKill -= Die;
    }
}
