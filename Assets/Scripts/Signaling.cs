using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _duration;

    private bool _isVolumeUp = false;
    private bool _isVolumeDown = false;
    private bool _isUpdateTimer = false;
    private float _runningTime;
    private float volume = 0.0f;

    public bool IsAlarmWorks { get; private set; }

    private void Update()
    {
        float minVolume = 0.0f;
        float maxVolume = 1.0f;

        _runningTime += Time.deltaTime;
        float volumeChange = _runningTime / _duration;

        if (IsAlarmWorks)
        {
            IsAlarmWorks = true;
            _isVolumeDown = false;
            _isVolumeUp = true;
        }
        else
        {
            IsAlarmWorks = false;
            _isVolumeUp = false;
            _isVolumeDown = true;
        }

        if (_isUpdateTimer)
        {
            volume = _audio.volume;
            _runningTime = 0;
            _isUpdateTimer = false;
        }

        if (_isVolumeUp)
        {
            _audio.volume = Mathf.MoveTowards(volume, maxVolume, volumeChange);
        }
        else if (_isVolumeDown)
        {
            _audio.volume = Mathf.MoveTowards(volume, minVolume, volumeChange);
        }
    }

    public void TurnOnAlarm()
    {
        IsAlarmWorks = true;
    }

    public void TurnOffAlarm()
    {
        IsAlarmWorks = false;
    }

    public void UpdateTimer()
    {
        _isUpdateTimer = true;
    }
}