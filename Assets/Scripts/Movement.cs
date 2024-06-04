using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    
    public Animator animator;
    
    private Vector3 _direction;
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");

    private void Update()
    {
        //get input from player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //apply movement to sprite
        _direction = new Vector3(horizontal, vertical, 0);
        AnimateMovement(_direction);
        
        
    }

    private void FixedUpdate()
    {
        this.transform.position += _direction.normalized * (speed * Time.deltaTime);
    }

    void AnimateMovement(Vector3 vectorDirection)
    {
        if (animator is not null)
        {
            if (vectorDirection.magnitude > 0)
            {
                animator.SetBool(IsMoving, true);
                animator.SetFloat(Horizontal, vectorDirection.x);
                animator.SetFloat(Vertical, vectorDirection.y);
            }
            else
            {
                animator.SetBool(IsMoving, false);
            }
        }
    }
}