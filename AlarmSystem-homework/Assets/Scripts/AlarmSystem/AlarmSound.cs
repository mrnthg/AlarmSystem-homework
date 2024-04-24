using System.Collections;
using UnityEngine;

public class AlarmSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _clip;
    
    private float _currentVolume;
    private float _minCountVolume = 0; 
    private float _maxCountVolume = 1;
    private float _recoveryRate = 0.2f;
    private bool _isDetected;

    private void Start()
    {
        _audioSource.clip = _clip;      
        _audioSource.volume = _minCountVolume;
    }

    public void StartAlarm()
    {
        _isDetected = true;
        StartCoroutine(PlaySound());       
    }

    public void StopAlarm()
    {
        _isDetected = false;
        StartCoroutine(StopSound());      
    }

    private IEnumerator PlaySound()
    {
        _audioSource.Play();

        while (_audioSource.volume != _maxCountVolume && _isDetected)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, _maxCountVolume, _recoveryRate * Time.deltaTime);
            _audioSource.volume = _currentVolume;
            
            yield return null;
        }   
    }

    private IEnumerator StopSound()
    {
        while (_audioSource.volume != _minCountVolume && !_isDetected)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, _maxCountVolume, -_recoveryRate * Time.deltaTime);
            _audioSource.volume = _currentVolume;

            yield return null;
        }

        _audioSource.Stop();
    }
}
