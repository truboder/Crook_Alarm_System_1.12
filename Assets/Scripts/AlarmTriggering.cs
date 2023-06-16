using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlarmTriggering : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _volumeChangeValue = 0.01f;

    private Coroutine _coroutine;

    private void Start()
    {
        MovementDetecting.AddEnteredListener(StartAlarm);
        MovementDetecting.AddExitedListener(StopAlarm);
    }

    private void StartAlarm()
    {
        var maxVolume = _audio.maxDistance;

        StartChangeValue(maxVolume, _volumeChangeValue);
    }

    private void StopAlarm()
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
            _audio.volume = Mathf.Clamp(_audio.volume + volumeChangeValue, _audio.minDistance, _audio.maxDistance);

            yield return waitingForFixed;
        }
    }
}
