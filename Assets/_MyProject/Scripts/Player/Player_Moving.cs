using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Moving : MonoBehaviour
{
    [Header("Player Parameters")]
    [SerializeField] private float movingSpeed;
    [SerializeField] private float jumpPower;
    private Vector3 playerScale;

    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    [Header("Multiple Jumps")]
    [SerializeField] private int extraJumps;
    private int jumpCounter;

    [Header("Wall Jumping")]
    [SerializeField] private float wallJumpX;
    [SerializeField] private float wallJumpY;

    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;

    [SerializeField] public ParticleSystem dust;
    [SerializeField] public ParticleSystem dustJump;
    [SerializeField] public ParticleSystem dustWall;

    private float inputHorizontal;
    private bool jumpeffect;

    private Animator animator;
    private Rigidbody2D mybody;
    private CapsuleCollider2D capsuleCollider;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        mybody = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        playerScale = transform.localScale;
    }
    private void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        mybody.velocity = new Vector2(inputHorizontal * movingSpeed, mybody.velocity.y);
        FlipChar();   
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SoundsManager.instance.PlaySound(jumpSound);
            Jump();
        }
        
        if (isOnWall())
        {
            dustWall.Play();
            mybody.velocity = Vector2.zero; 
        }
        if (isOnGround())
        {
            jumpCounter = extraJumps;           
        }
   
        if(isOnGround() && inputHorizontal != 0)
        {
            dust.Play();
        }

        animator.SetBool("Run", inputHorizontal != 0);
        animator.SetBool("Fall", isFalling());
        animator.SetBool("Ground", isOnGround());
        animator.SetBool("Wall", isOnWall());
    }
    private void FlipChar()
    {
        if (inputHorizontal > 0.01f)
            transform.localScale = playerScale;
        else if (inputHorizontal < -0.01f)
            transform.localScale = new Vector3(playerScale.x * -1, playerScale.y, playerScale.z);
    }
    private bool isOnGround()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(capsuleCollider.bounds.center, capsuleCollider.bounds.size, 0, Vector2.down, 0.01f, groundLayer);
        return raycastHit.collider != null;
    }
    private bool isOnWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(capsuleCollider.bounds.center, capsuleCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null && !isOnGround();
    }
    private void Jump()
    {
        if (isOnWall())
        {
            WallJump();
        }
        else
        {
            if (isOnGround())
            {
                mybody.velocity = new Vector2(mybody.velocity.x, jumpPower);
                animator.SetTrigger("Jump");
            }
            else
            {
                if (jumpCounter > 0) //If we have extra jumps then jump and decrease the jump counter
                {
                    mybody.velocity = new Vector2(mybody.velocity.x, jumpPower);
                    jumpCounter--;
                    animator.SetTrigger("DoubleJump");
                }
            }
        }
        jumpeffect = true;
    }
    private void WallJump()
    {
        mybody.AddForce(new Vector2(-Mathf.Sign(transform.localScale.x) * wallJumpX, wallJumpY));
    }
    private bool isFalling()
    {
        if (mybody.velocity.y <= 0 && !isOnGround())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (jumpeffect)
            {
                dustJump.Play();
                jumpeffect = false;
            }
        }
    }
}
