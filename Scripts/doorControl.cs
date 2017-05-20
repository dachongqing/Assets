using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//这个脚本不知道是来干嘛的

public class doorControl : MonoBehaviour {

    public Animator animator;

    void Start()
    {
        animator = this.GetComponent<Animator>();
      //  animator.SetBool("openFlag", true);
    }

    void OnTriggerEnter2D(Collider2D co)
    {
       // Debug.Log("the gameObject name is :" + co.gameObject.name);
      //  Debug.Log("the object name is :" + co.name);
        if (co.gameObject.name == "01_0")
        {
            // this.GetComponent<Animator>()
            animator.SetBool("openFlag", true);
           //   
        }


    }

    void Update()
      {
         AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
         // 判断动画是否播放完成
         if (info.normalizedTime >= 1.0f)
         {
            Debug.Log("the animator  is over" );
           // animator.SetBool("openFlag", false);
        }
     }
}
