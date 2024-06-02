using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{

    public Animator _animator;
    bool comboPossible;
    bool inputSmash;
    public int comboStep;

    public bool isCrouch = false;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void ComboPossible()
    {
        comboPossible = true;
    }
    
    public void NextAtk()
    {
        if(!inputSmash)
        {
            if(comboStep == 2)
                _animator.Play("AttackB");
            if(comboStep == 3)
                _animator.Play("AttackC");
        }
        // if(inputSmash)
        // {
        //     if(comboStep == 1)
        //         _animator.Play("Skill1");
        //     if(comboStep == 2)
        //         _animator.Play("Skill2");
        //     if(comboStep == 3)
        //         _animator.Play("Skill3");
        // }
    }

    public void ResetCombo()
    {
        comboPossible = false;
        inputSmash = false;
        comboStep = 0;
    }

    public void spin()
    {
        _animator.Play("Spin");
    }

    public void NormalAttack()
    {
        if(comboStep == 0)
        {
            _animator.Play("AttackA");
            comboStep = 1;
            return;
        }
        if(comboStep != 0)
        {
            if(comboPossible)
            {
                comboPossible = false;
                comboStep += 1;
            }
        }
    }

    public void Crouch()
    {
        if(!isCrouch)
        {
            _animator.SetBool("Crouch", true);
            isCrouch = true;
        }
        else{
            _animator.SetBool("Crouch", false);
            isCrouch = false;
        }
            

    }
}
