using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItens : MonoBehaviour
{
    [SerializeField] private int _totalWood;

    public int totalWood { get => _totalWood; set => _totalWood = value; }
}
