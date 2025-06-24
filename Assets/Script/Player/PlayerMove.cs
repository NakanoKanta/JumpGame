using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float PlayerJumpPower;
    [SerializeField] float PlayerMovePower;
    public bool JumpFrag = false;

    Rigidbody2D player_rb;
    float JumpCount = 0;
    float player_move;
    
    void Start()
    {
        player_rb= GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            JumpCount += 2 * Time.deltaTime;
            //Debug.Log(JumpCount);
        }
        if(JumpFrag == true)
            PlayerJump();
        if (JumpFrag == false)
        {
            player_move = Input.GetAxisRaw("Horizontal");
            PlayerMoveX(player_move);
        }
            
    }

    //PlayerのJumpの動き
    void PlayerJump()
    {
        if (Input.GetButtonUp("Jump"))
        {
            if (JumpCount >= 0 && JumpCount < 1)
            {
                // 小ジャンプ
                player_rb.AddForce(Vector2.up * PlayerJumpPower, ForceMode2D.Impulse);
            }
            else if (JumpCount >= 1 && JumpCount < 2)
            {
                // 中ジャンプ
                player_rb.AddForce(Vector2.up * PlayerJumpPower * 1.25f, ForceMode2D.Impulse);
            }
            else if (JumpCount >= 2 && JumpCount < 10)
            {
                // 大ジャンプ
                player_rb.AddForce(Vector2.up * PlayerJumpPower * 1.5f, ForceMode2D.Impulse);
            }
        }
    }
    //左右の動き
    void PlayerMoveX(float horizontal)
    {
        player_rb.velocity = new Vector2(horizontal * PlayerMovePower,player_rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GroundTag"))
        {
            JumpFrag = true;
            JumpCount = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GroundTag"))
        {
            JumpFrag = false;
        }
    }
}
