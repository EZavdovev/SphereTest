using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Скрипт реализует поведение монетки
/// </summary>
public class Money : MonoBehaviour
{
    public static event Action OnCollect = delegate { };
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            OnCollect();
            Destroy(gameObject);
        }
    }
}
