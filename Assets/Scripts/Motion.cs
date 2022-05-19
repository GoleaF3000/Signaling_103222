using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _home;

    private Transform _target;
    
    public Transform Home => _home;    

    private void Start()
    {
        _target = _home;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);       
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}