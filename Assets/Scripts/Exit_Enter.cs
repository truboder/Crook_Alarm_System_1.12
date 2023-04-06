using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Enter : MonoBehaviour
{
    [SerializeField] private AlarmTriggering _alarmTriggering;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IEnumerator enumerator = _alarmTriggering.StartAlarm();
        StartCoroutine(enumerator);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(_alarmTriggering.StopAlarm());
    }
}
