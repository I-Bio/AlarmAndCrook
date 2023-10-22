using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(AlarmEnterChecker))]
public class AlarmPlayback : MonoBehaviour
{
    [SerializeField] private float _startVolume;
    [SerializeField] private float _endVolume;
    [SerializeField] private float _recoveryRate;

    private AudioSource _audioSource;
    private AlarmEnterChecker _alarmEnterChecker;
    private float _currentVolume;
    private bool _isPlaying;

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        _alarmEnterChecker = GetComponent<AlarmEnterChecker>();
        _isPlaying = false;

        _alarmEnterChecker.Enter += PlayAlarm;
        _alarmEnterChecker.Exit += StopAlarm;
    }

    private void OnDisable()
    {
        _alarmEnterChecker.Enter -= PlayAlarm;
        _alarmEnterChecker.Exit -= StopAlarm;
    }

    private void Update()
    {
        ChangeVolume();
    }

    private void ChangeVolume()
    {
        float targetVolume;
        
        if (_isPlaying == true)
        {
            targetVolume = _endVolume;
        }
        else
        {
            targetVolume = _startVolume;
        }
        
        _currentVolume = Mathf.MoveTowards(_currentVolume, targetVolume, _recoveryRate * Time.deltaTime);
        _audioSource.volume = _currentVolume;
        
        if (_audioSource.volume <= _startVolume)
        {
            _audioSource.Stop();
        }
    }

    private void PlayAlarm()
    {
        _audioSource.Play();
        _isPlaying = true;
    }

    private void StopAlarm()
    {
        _isPlaying = false;
    }
}
