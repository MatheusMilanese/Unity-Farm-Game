using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    private bool detectingPlayer;
    private PlayerItens playerItens;
    private PlayerAnim playerAnim;

    [SerializeField] private GameObject fishPrefab;

    private void Start() {
        playerItens = FindObjectOfType<PlayerItens>();
        playerAnim = playerItens.GetComponent<PlayerAnim>();
    }

    // Update is called once per frame
    void Update()
    {
        if(detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            playerAnim.OnCastingStart();
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

    public void OnCasting(){
        int random = Random.Range(0, 100);

        if(random <= 50){
            Vector3 fishPosition = playerItens.transform.position + Vector3.left * Random.Range(-2.5f, -1.5f);
            Instantiate(fishPrefab, fishPosition, Quaternion.identity);
        }

    }
}
