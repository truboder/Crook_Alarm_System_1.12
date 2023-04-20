using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Enter : MonoBehaviour
{
    [SerializeField] private AlarmTriggering _alarmTriggering;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _alarmTriggering.StartAlarm();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _alarmTriggering.StopAlarm();
    }
}
