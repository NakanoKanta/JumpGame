using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float PlayerJumpPower;
    [SerializeField] float PlayerMovePower;
    public bool JumpFrag = false;

    Rigidbody2D player_rb;
    public float JumpCount = 0;
    float player_move;

    public AudioClip smallJumpSound;
    public AudioClip mediumJumpSound;
    public AudioClip bigJumpSound;

    public Sprite idleSprite;     // �ҋ@���X�v���C�g
    public Sprite jumpSprite;     // �W�����v���X�v���C�g
    SpriteRenderer spriteRenderer;

    AudioSource audioSource;
    CountManager countManager;

    void Start()
    {
        player_rb= GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        countManager = FindObjectOfType<CountManager>();
    }
    void Update()
    {
        if (!countManager.isGameTimer) return; // �^�C�}�[�J�n�O�̓W�����v��ړ��֎~
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

    //Player��Jump�̓���
    void PlayerJump()
    {
        if (Input.GetButtonUp("Jump"))
        {
            if (JumpCount >= 0 && JumpCount < 1)
            {
                // ���W�����v
                player_rb.AddForce(Vector2.up * PlayerJumpPower * 0.5f, ForceMode2D.Impulse);
                PlayerJumpSound(smallJumpSound);
            }
            else if (JumpCount >= 1 && JumpCount < 2)
            {
                // ���W�����v
                player_rb.AddForce(Vector2.up * PlayerJumpPower, ForceMode2D.Impulse);
                PlayerJumpSound(mediumJumpSound);
            }
            else if (JumpCount >= 2)
            {
                // ��W�����v
                player_rb.AddForce(Vector2.up * PlayerJumpPower * 1.25f, ForceMode2D.Impulse);
                PlayerJumpSound(bigJumpSound);
            }
           
        }
    }
    //���E�̓���
    void PlayerMoveX(float horizontal)
    {
        player_rb.velocity = new Vector2(horizontal * PlayerMovePower,player_rb.velocity.y);
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        else if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
    }

    void PlayerJumpSound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GroundTag"))
        {
            JumpFrag = true;
            JumpCount = 0;
            player_rb.velocity = new Vector2(0f, player_rb.velocity.y);
            // ���n�X�v���C�g�ɖ߂�
            if (spriteRenderer != null && idleSprite != null)
            {
                spriteRenderer.sprite = idleSprite;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GroundTag"))
        {
            JumpFrag = false;
            // �W�����v�X�v���C�g�ɕύX
            if (spriteRenderer != null && jumpSprite != null)
            {
                spriteRenderer.sprite = jumpSprite;
            }
        }
    }
}
