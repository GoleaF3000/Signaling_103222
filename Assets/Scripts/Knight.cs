using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Motion
{
    [SerializeField] private Transform _enemy;    

    public Transform Enemy => _enemy;    
}