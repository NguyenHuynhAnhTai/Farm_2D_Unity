using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    
    public Animator animator;
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");

    private void Update()
    {
        //get input from player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //apply movement to sprite
        Vector3 direction = new Vector3(horizontal, vertical);
        AnimateMovement(direction);
        
        transform.position += direction * (speed * Time.deltaTime);
    }
    
    void AnimateMovement(Vector3 direction)
    {
        if (animator is not null)
        {
            if (direction.magnitude > 0)
            {
                animator.SetBool(IsMoving, true);
                animator.SetFloat(Horizontal, direction.x);
                animator.SetFloat(Vertical, direction.y);
            }
            else
            {
                animator.SetBool(IsMoving, false);
            }
        }
    }
}