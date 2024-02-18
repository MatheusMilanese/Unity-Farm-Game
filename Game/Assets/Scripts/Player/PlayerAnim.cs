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
        OnWatering();
    }

    #region Movement

    void OnMove(){
        if(player.Direction.sqrMagnitude > 0) {
            if(player.IsRolling){
                animator.SetTrigger("isRoll");
            }
            else{
                animator.SetInteger("transition", 1);
            }
        }
        else{
            animator.SetInteger("transition", 0);
        }

        if(player.Direction.x > 0){
            transform.eulerAngles = new Vector2(0, 0);
        }
        else if(player.Direction.x < 0){
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    void OnRun(){
        if(player.IsRunning){
            animator.SetInteger("transition", 2);
        }
    }

    #endregion

    #region farming
    
    void OnCutting(){
        if(player.IsCutting){
            animator.SetInteger("transition", 3);
        }
    }

    void OnDigging(){
        if(player.IsDigging){
            animator.SetInteger("transition", 4);
        }
    }

    void OnWatering(){
        if(player.IsWatering){
            animator.SetInteger("transition", 5);
        }
    }
    #endregion
}
