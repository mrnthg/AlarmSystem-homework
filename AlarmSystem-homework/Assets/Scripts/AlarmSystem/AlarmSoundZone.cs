using UnityEngine;

public class AlarmSoundZone : MonoBehaviour
{
    [SerializeField] private AlarmSound _ambientSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            _ambientSound.StartAlarm();
        }                 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovement>()) 
        {
            _ambientSound.StopAlarm(); 
        }
    }
}
