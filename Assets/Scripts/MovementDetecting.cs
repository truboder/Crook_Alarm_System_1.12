using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementDetecting : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AlarmTriggering.EnterEvent.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        AlarmTriggering.ExitEvent.Invoke();
    }
}
