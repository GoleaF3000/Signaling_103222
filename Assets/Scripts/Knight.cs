using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Bot
{
    [SerializeField] private Transform _enemy;
    [SerializeField] private Signaling _signaling;

    private void Update()
    {
        if (_signaling.IsAlarmWorks)
        {
            SetTarget(_enemy);
        }
        else
        {
            SetTarget(Home);
        }

        transform.position = Vector3.MoveTowards(transform.position, ReturnTarget().position, ReturnSpeed() * Time.deltaTime);
    }
}