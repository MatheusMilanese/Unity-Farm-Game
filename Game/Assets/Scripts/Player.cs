using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rBody;
    private Vector2 _direction;

    public Vector2 direction { get => _direction; }

    private void Start() {
        rBody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate() {
        rBody.MovePosition(rBody.position + _direction * speed * Time.fixedDeltaTime);
    }
}
