using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed;
    private float initialSpeed;
    private int index;
    public List<Transform> paths = new List<Transform>();

    [SerializeField] private Animator animator;

    void Start()
    {
        initialSpeed = speed;
    }

    void Update()
    {
        if(DialogueController.instance.isShowing){
            speed = 0;
            animator.SetBool("isWalking", false);
        }
        else{
            speed = initialSpeed;
            animator.SetBool("isWalking", true);
        }

        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, paths[index].position) < 0.1){
            index = Random.Range(0, paths.Count-1);
        }

        Vector2 direction = paths[index].position - transform.position;

        if(direction.x > 0) transform.eulerAngles = new Vector2(0, 0);
        else if(direction.x < 0) transform.eulerAngles = new Vector2(0, 180);
        
    }
}
