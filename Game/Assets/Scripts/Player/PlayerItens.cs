using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItens : MonoBehaviour
{
    [SerializeField] private int totalWood;
    [SerializeField] private float currentWater;

    private readonly float waterLimit = 50;

    public int TotalWood { get => totalWood; set => totalWood = value; }
    public float CurrentWater { get => currentWater; }

    public void AddWater(float waterAmount){
        currentWater += waterAmount;
        if(currentWater > waterLimit){
            currentWater = waterLimit;
        }
    }

    public void ConsumeWater(){
        currentWater -= 0.01f;
    }
}
