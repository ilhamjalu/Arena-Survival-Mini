using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Slider hpBar;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    private Vector2 lastDirection;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovementVisual(Vector2 direction)
    {
        bool isMoving = direction.sqrMagnitude > 0;

        animator.SetBool("IsMoving", isMoving);

        if (!isMoving)
        {
            return;
        }

        lastDirection = direction;

        float absX = Mathf.Abs(direction.x);

        float absY = Mathf.Abs(direction.y);

        if (absX > absY)
        {
            animator.SetFloat("MoveX", 1);
            animator.SetFloat("MoveY", 0);

            spriteRenderer.flipX = direction.x > 0;
        }
        else if (direction.y > 0)
        {
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", 1);

            spriteRenderer.flipX = false;
        }
        else
        {
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", -1);

            spriteRenderer.flipX = false;
        }
    }
}
