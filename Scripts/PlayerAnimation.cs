using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator myAnimator;
    private SpriteRenderer sr;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    
    public void PlayerWalk(bool walk, bool flipSide)
    {
        myAnimator.SetBool("Walk",walk);
        sr.flipX = flipSide;
    }

    public void PlayerStop()
    {
        myAnimator.SetBool("Walk", false);
    }
}
