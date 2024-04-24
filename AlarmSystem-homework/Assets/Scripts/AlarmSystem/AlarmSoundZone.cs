using UnityEngine;

public class AlarmSoundZone : MonoBehaviour
{
    [SerializeField] private AlarmSound _ambientSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<AlarmListener>())
        {
            _ambientSound.StartAlarm();
        }                 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<AlarmListener>()) 
        {
            _ambientSound.StopAlarm(); 
        }
    }
}
