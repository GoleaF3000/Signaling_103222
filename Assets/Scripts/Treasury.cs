using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Treasury : MonoBehaviour
{    
    [SerializeField] private Knight _knight;
    [SerializeField] private UnityEvent _thiefEntered;
    [SerializeField] private UnityEvent _thiefOut;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ninja>())
        {           
            _thiefEntered?.Invoke();            
            _knight.SetTarget(_knight.Enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Ninja>())
        {            
            _thiefOut?.Invoke();            
            _knight.SetTarget(_knight.Home);
        }
    }
}