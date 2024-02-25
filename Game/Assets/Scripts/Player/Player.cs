using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isPaused;

    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;
    
    private Rigidbody2D rBody;
    private PlayerItens playerItens;

    private int handlingObj;

    private bool isRolling;
    private bool isRunning;
    private bool isCutting;
    private bool isDigging;
    private bool isWatering;

    private float initialSpeed;
    private Vector2 direction;

    public Vector2 Direction { get => direction; }
    public bool IsRunning { get => isRunning; }
    public bool IsRolling { get => isRolling; }
    public bool IsCutting { get => isCutting; }
    public bool IsDigging { get => isDigging; }
    public bool IsWatering { get => isWatering; }

    public int HandlingObj { get => handlingObj; }

    private void Start() {
        rBody = GetComponent<Rigidbody2D>();
        playerItens = GetComponent<PlayerItens>();
        initialSpeed = speed;
    }

    private void Update() {
        if(isPaused) return;

        OnInput();
        OnRun();
        OnRoll();

        OnInputTools();
        OnCutting();
        OnDigging();
        OnWatering();
    }

    private void FixedUpdate() {
        if(isPaused) return;

        OnMove();
    }

    #region Movement

    void OnInput(){
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove(){
        rBody.MovePosition(rBody.position + speed * Time.fixedDeltaTime * direction);
    }

    void OnRun(){
        if(Input.GetKey(KeyCode.LeftShift)){
            speed = runSpeed;
            isRunning = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            speed = initialSpeed;
            isRunning = false;
        }
    }

    void OnRoll(){
        if(Input.GetMouseButtonDown(1)){
            isRolling = true;
            speed = runSpeed;
        }
        if(Input.GetMouseButtonUp(1)){
            isRolling = false;
            speed = initialSpeed;
        }
    }

    #endregion

    #region farming

    void OnInputTools(){
        if(Input.GetKeyDown(KeyCode.Alpha1)) handlingObj = 0;
        else if(Input.GetKeyDown(KeyCode.Alpha2)) handlingObj = 1;
        else if(Input.GetKeyDown(KeyCode.Alpha3)) handlingObj = 2;
    }

    void OnCutting(){
        if(handlingObj != 0) return;
        if(Input.GetMouseButtonDown(0)){
            isCutting = true;
            speed = 0f;
        }
        if(Input.GetMouseButtonUp(0)){
            isCutting = false;
            speed = initialSpeed;
        }
    }

    void OnDigging(){
        if(handlingObj != 1) return;
        if(Input.GetMouseButtonDown(0)){
            isDigging = true;
            speed = 0f;
        }
        if(Input.GetMouseButtonUp(0)){
            isDigging = false;
            speed = initialSpeed;
        }
    }

    void OnWatering(){
        if(handlingObj != 2) return;
        if(Input.GetMouseButtonDown(0) && playerItens.CurrentWater > 0){
            isWatering = true;
            speed = 0f;
        }
        if(Input.GetMouseButtonUp(0) || playerItens.CurrentWater <= 0){
            isWatering = false;
            speed = initialSpeed;
        }
        if(isWatering){
            playerItens.ConsumeWater();
        }
    }

    #endregion
}
