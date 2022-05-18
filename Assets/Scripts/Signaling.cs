using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _duration;
    
    private float _runningTime;
    private float _volume;
    private float _targetVolume = 0.0f;
    private float _minVolume = 0.0f;
    private float _maxVolume = 1.0f;

    private void Start()
    {
        _audio.volume = 0.0f;
    }    

    public void SetMaxVolume()
    {
        _targetVolume = _maxVolume;
    }

    public void SetMinVolume()
    {
        _targetVolume = _minVolume;
    }

    public void UpdateTimer()
    {
        _volume = _audio.volume;
        _runningTime = 0;        
    }

    public void StartAdjustVolume()
    {
        StartCoroutine(AdjustVolume());
    }

    private IEnumerator AdjustVolume()
    {
        UpdateTimer();

        while (_runningTime < _duration)
        {
            _runningTime += Time.deltaTime;
            float volumeChange = _runningTime / _duration;

            _audio.volume = Mathf.MoveTowards(_volume, _targetVolume, volumeChange);

            yield return null;
        }
    }
}