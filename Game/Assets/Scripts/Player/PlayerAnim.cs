using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator animator;

    void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        OnMove();
        OnRun();
        OnCutting();
        OnDigging();
    }

    #region Movement

    void OnMove(){
        if(player.direction.sqrMagnitude > 0) {
            if(player.isRolling){
                animator.SetTrigger("isRoll");
            }
            else{
                animator.SetInteger("transition", 1);
            }
        }
        else{
            animator.SetInteger("transition", 0);
        }

        if(player.direction.x > 0){
            transform.eulerAngles = new Vector2(0, 0);
        }
        else if(player.direction.x < 0){
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    void OnRun(){
        if(player.isRunning){
            animator.SetInteger("transition", 2);
        }
    }

    #endregion

    #region farming
    
    void OnCutting(){
        if(player.isCutting){
            animator.SetInteger("transition", 3);
        }
    }

    void OnDigging(){
        if(player.isDigging){
            animator.SetInteger("transition", 4);
        }
    }
    #endregion
}
