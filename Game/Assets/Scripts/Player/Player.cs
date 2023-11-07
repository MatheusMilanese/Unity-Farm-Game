using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;
    
    private Rigidbody2D rBody;

    private int handlingObj;

    private bool _isRolling;
    private bool _isRunning;
    private bool _isCutting;
    private bool _isDigging;
    private float _initialSpeed;
    private Vector2 _direction;

    public Vector2 direction { get => _direction; }
    public bool isRunning { get => _isRunning; }
    public bool isRolling { get => _isRolling; }
    public bool isCutting { get => _isCutting; }
    public bool isDigging { get => _isDigging; }

    private void Start() {
        rBody = GetComponent<Rigidbody2D>();
        _initialSpeed = speed;
    }

    private void Update() {
        OnInput();
        OnRun();
        OnRoll();

        OnInputTools();
        OnCutting();
        OnDigging();
    }

    private void FixedUpdate() {
        OnMove();
    }

    #region Movement

    void OnInput(){
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove(){
        rBody.MovePosition(rBody.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun(){
        if(Input.GetKey(KeyCode.LeftShift)){
            speed = runSpeed;
            _isRunning = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            speed = _initialSpeed;
            _isRunning = false;
        }
    }

    void OnRoll(){
        if(Input.GetMouseButtonDown(1)){
            _isRolling = true;
            speed = runSpeed;
        }
        if(Input.GetMouseButtonUp(1)){
            _isRolling = false;
            speed = _initialSpeed;
        }
    }

    #endregion

    #region farming

    void OnInputTools(){
        if(Input.GetKeyDown(KeyCode.Alpha1)) handlingObj = 0;
        else if(Input.GetKeyDown(KeyCode.Alpha2)) handlingObj = 1;
    }

    void OnCutting(){
        if(handlingObj != 0) return;
        if(Input.GetMouseButtonDown(0)){
            _isCutting = true;
            speed = 0f;
        }
        if(Input.GetMouseButtonUp(0)){
            _isCutting = false;
            speed = _initialSpeed;
        }
    }

    void OnDigging(){
        if(handlingObj != 1) return;
        if(Input.GetMouseButtonDown(0)){
            _isDigging = true;
            speed = 0f;
        }
        if(Input.GetMouseButtonUp(0)){
            _isDigging = false;
            speed = _initialSpeed;
        }
    }

    #endregion
}
