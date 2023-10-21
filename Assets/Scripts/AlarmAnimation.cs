using UnityEngine;

[RequireComponent(typeof(AlarmEnterChecker),typeof(Animator))]
public class AlarmAnimation : MonoBehaviour
{
    private const string Alarm = "Alarm";
    
    private AlarmEnterChecker _alarmEnterChecker;
    private Animator _animator;
    
    private void OnEnable()
    {
        _alarmEnterChecker = GetComponent<AlarmEnterChecker>();
        _animator = GetComponent<Animator>();
        
        _alarmEnterChecker.Enter += OnActive;
        _alarmEnterChecker.Exit += OnActive;
    }

    private void OnDisable()
    {
        _alarmEnterChecker.Enter -= OnActive;
        _alarmEnterChecker.Exit -= OnActive;
    }

    private void OnActive()
    {
        _animator.SetTrigger(Alarm);
    }
}
