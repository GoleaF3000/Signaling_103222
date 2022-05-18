using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : Motion
{    
    [SerializeField] private Transform _chest;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlaceNinja>())
        {
            SetTarget(_chest);
        }
        else if (collision.GetComponent<Knight>())
        {
            SetTarget(Home);
        }
    }
}