using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _duration;
      
    private float _targetVolume = 0.0f;
    private float _minVolume = 0.0f;
    private float _maxVolume = 1.0f;  
    
    private void Start()
    {
        _audio.volume = 0.0f;
    }

    public void TurnUpVolume()
    {
        _targetVolume = _maxVolume;
    }

    public void TurnDownVolume()
    {
        _targetVolume = _minVolume;
    }

    public void StartTurnOn()
    {
        StartCoroutine(TurnOn());
    }

    private IEnumerator TurnOn()
    {
        float runningTime = 0;
        float volumeChange;

        while (runningTime < _duration)
        {
            runningTime += Time.deltaTime;
            volumeChange = Time.deltaTime / _duration;            
            
            _audio.volume = Mathf.MoveTowards(_audio.volume, _targetVolume, volumeChange);
           
            yield return null;
        }

        StopCoroutine(TurnOn());
    }
}