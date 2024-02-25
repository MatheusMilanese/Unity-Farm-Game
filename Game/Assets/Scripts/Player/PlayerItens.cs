using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItens : MonoBehaviour
{
    [SerializeField] private float totalWood;
    [SerializeField] private float totalCarrots;
    [SerializeField] private float currentWater;

    public readonly float waterLimit = 50;
    public readonly float woodLimit = 5;
    public readonly float carrotLimit = 10;

    public float TotalWood { get => totalWood; set => totalWood = value; }
    public float TotalCarrots { get => totalCarrots; set => totalCarrots = value; }
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
