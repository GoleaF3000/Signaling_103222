using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasury : MonoBehaviour
{
    [SerializeField] private Signaling _signaling;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ninja>())
        {
            _signaling.UpdateTimer();
            _signaling.TurnOnAlarm();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Ninja>())
        {
            _signaling.UpdateTimer();
            _signaling.TurnOffAlarm();
        }
    }
}