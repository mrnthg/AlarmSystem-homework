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

    private float _finalVolume;
    private IEnumerator _sounds;
    private bool _isStart = false;

    private void Start()
    {
        _audioSource.clip = _clip;      
        _audioSource.volume = _minCountVolume;      
    }

    public void StartAlarm()
    {       
        _finalVolume = _maxCountVolume;
        AlarmSystem();
    }

    public void StopAlarm()
    {
        _finalVolume = _minCountVolume;       
        AlarmSystem();
    }

    private void AlarmSystem()
    {      
        if (_isStart)
        {
            StopCoroutine(VolumeModification());
        }
        
        _sounds = VolumeModification();
        StartCoroutine(_sounds);
    }

    private IEnumerator VolumeModification()
    {
        _isStart = true;

        _audioSource.Play();

        while (_audioSource.volume != _finalVolume)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, _finalVolume, _recoveryRate * Time.deltaTime);
            _audioSource.volume = _currentVolume;

            yield return null;
        }
    }
}
