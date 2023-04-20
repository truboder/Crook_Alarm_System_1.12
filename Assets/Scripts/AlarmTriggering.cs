using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlarmTriggering : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _volumeChangeValue = 0.01f;

    private Coroutine _coroutine;

    public void StartAlarm()
    {
        var maxVolume = _audio.maxDistance;

        StartChangeValue(maxVolume, _volumeChangeValue);
    }

    public void StopAlarm()
    {
        var minVolume = _audio.minDistance;

        StartChangeValue(minVolume, -_volumeChangeValue);
    }

    private void StartChangeValue(float requiredValue, float volumeChangeValue)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeValue(requiredValue, volumeChangeValue));
    }

    private IEnumerator ChangeValue(float _requiredValue, float volumeChangeValue)
    {
        var waitingForFixed = new WaitForFixedUpdate();

        while (_audio.volume != _requiredValue)
        {
            _audio.volume += volumeChangeValue;

            yield return waitingForFixed;
        }
    }
}
