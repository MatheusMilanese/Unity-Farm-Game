using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] private float timeMove;
    [SerializeField] private float speed;

    private float timeCount;

    void Update()
    {
        if(timeCount < timeMove){
            timeCount += Time.deltaTime;
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            other.GetComponent<PlayerItens>().TotalWood++;
            Destroy(gameObject);
        }
    }
}
