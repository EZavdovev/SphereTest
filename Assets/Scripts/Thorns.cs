using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Скрипт реализет поведение шипов
/// </summary>
public class Thorns : MonoBehaviour
{
    public static event Action OnKill = delegate { };
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnKill();
        }
    }
}
