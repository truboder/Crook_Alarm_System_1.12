using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementDetecting : MonoBehaviour
{
    private static UnityEvent _entered = new UnityEvent();
    private static UnityEvent _exited = new UnityEvent();

    public static void AddEnteredListener(UnityAction function)
    {
        _entered.AddListener(function);
    }

    public static void AddExitedListener(UnityAction function)
    {
        _exited.AddListener(function);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _entered.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _exited.Invoke();
    }
}
