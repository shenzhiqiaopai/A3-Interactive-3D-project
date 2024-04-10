using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 触发前进动画
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsBacking", false); // 避免前进和后退动画同时播放
        }
        else if (Input.GetKey(KeyCode.S)) // 触发后退动画
        {
            animator.SetBool("IsWalking", false); // 避免前进和后退动画同时播放
            animator.SetBool("IsBacking", true);
        }
        else // 当没有按下W或S键时，停止动画
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsBacking", false);
        }

        // 触发向左动画
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("IsTurningLeft", true);
            animator.SetBool("IsTurningRight", false); // 避免向左和向右动画同时播放
        }
        else // 当没有按下A键时，停止向左动画
        {
            animator.SetBool("IsTurningLeft", false);
        }

        // 触发向右动画
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("IsTurningRight", true);
            animator.SetBool("IsTurningLeft", false); // 避免向右和向左动画同时播放
        }
        else // 当没有按下D键时，停止向右动画
        {
            animator.SetBool("IsTurningRight", false);
        }

        // 触发跳跃动画
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsJumping", true);
        }
        else // 当没有按下空格键时，停止跳跃动画
        {
            animator.SetBool("IsJumping", false);
        }
    }
}
