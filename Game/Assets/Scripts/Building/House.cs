using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {
    private bool detectingPlayer;
    private Player player;
    private PlayerItens playerItens;
    private PlayerAnim playerAnim;

    private bool isBuilding = false;

    private readonly int woodValue = 3;
    private readonly float buildingTime = 5f;
    private float currentTime;

    [SerializeField] private GameObject Collider;
    [SerializeField] private SpriteRenderer spriteHouse;
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;

    [SerializeField] private Transform playerPoint;
    private void Start() {
        playerItens = FindObjectOfType<PlayerItens>();
        playerAnim = playerItens.GetComponent<PlayerAnim>();
        player = playerItens.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update() {
        if(detectingPlayer && Input.GetKeyDown(KeyCode.E) && playerItens.TotalWood >= woodValue) {
            OnStartBuilding();
        }
        if(isBuilding){
            currentTime += Time.deltaTime;
            if(currentTime >= buildingTime){
                OnEndBuilding();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            detectingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            detectingPlayer = false;
        }
    }

    private void OnStartBuilding(){
        player.isPaused = true;
        isBuilding = true;
        playerAnim.OnHammeringStart();
        spriteHouse.gameObject.SetActive(true);
        spriteHouse.color = startColor;
        playerItens.transform.position = playerPoint.position;
        playerItens.transform.eulerAngles = new Vector2(0, 0);
        playerItens.TotalWood -= woodValue;
    }

    private void OnEndBuilding(){
        player.isPaused = false;
        isBuilding = false;
        playerAnim.OnHammeringEnd();
        spriteHouse.color = endColor;
        Collider.SetActive(true);
        Destroy(this);
    }
}
