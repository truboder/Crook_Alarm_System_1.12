using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlarmTriggering : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _volumeChangeValue = 0.01f;

    public IEnumerator StartAlarm()
    {
        while (_audio.volume < 1)
        {
            _audio.volume += _volumeChangeValue;

            yield return new WaitForFixedUpdate();

            Debug.Log(_audio.volume);
        }
    }

    public IEnumerator StopAlarm()
    {
        while (_audio.volume > 0)
        {
            _audio.volume -= _volumeChangeValue;

            yield return new WaitForFixedUpdate();
        }
    }


}
