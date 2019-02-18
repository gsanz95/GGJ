using UnityEngine.SceneManagement;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    // Movement Speed
    public float speed;

    // Jumping and Jumping Force
    public float jumpforce;

    bool isjumping;

    // Movement
    public Vector2 deltaPos;
    private float windForce;

    private Rigidbody2D rb;

    private Animator kittenAnim;

    private bool isBeingPushed;

    // Level indexes
    public int MAIN_MENU_INDEX;
    

    // Sound
    private AudioSource playerAudio;
    public AudioClip[] audioTracks;

    public bool isDead = false;

    // Indexes for sound clips
    private int WALK_INDEX = 0;
    private int JUMP_INDEX = 1;

    private float jumpDebounce;
    private float debounceValue = 0.25f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        kittenAnim = GetComponent<Animator>();
        isBeingPushed = false;

        this.playerAudio = GetComponent<AudioSource>();
        jumpDebounce = debounceValue;
    }

    private void Update()
    {
        if (isDead == false)
        {
            if (jumpDebounce <= 0)
            {
                Jump();
                MoveHorizontal();

            }
            
        }
        else
        {
            // Game Over 
            SceneManager.LoadScene(MAIN_MENU_INDEX);
        }
        //Debug.Log(isjumping);

        if (jumpDebounce > 0)
        {
            jumpDebounce--;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isjumping)
        {
            jumpDebounce = debounceValue;
            Debug.Log("space bugtton hit");
            isjumping = true;
            rb.velocity = Vector2.up * jumpforce;

            kittenAnim.SetTrigger("Kitten_Jump");

            // Sound
            if (this.playerAudio.isPlaying)
                this.playerAudio.Stop();
            this.playerAudio.PlayOneShot(audioTracks[JUMP_INDEX]);
        }
    }

    void MoveHorizontal()
    {
        //float move_horizontal = 0.0f;

        float move_horizontal = Input.GetAxisRaw("Horizontal");
        
        UpdateWalkAnimation(move_horizontal);

        //Debug.Log(move_horizontal);

        if (isBeingPushed)
            move_horizontal += windForce;

        rb.velocity = new Vector2(speed * move_horizontal, rb.velocity.y);
    }

    void UpdateWalkAnimation(float move_horizontal)
    {

        if (move_horizontal > 0.05f && isjumping == false)
        {
            transform.localScale = new Vector3(1, 1, 1);
            if (!this.playerAudio.isPlaying)
                this.playerAudio.PlayOneShot(audioTracks[WALK_INDEX]);
            kittenAnim.SetTrigger("Kitten_Walk");
            kittenAnim.speed = 1.5f;
        }
        if (move_horizontal < -0.05f && isjumping == false)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            if (!this.playerAudio.isPlaying)
                this.playerAudio.PlayOneShot(audioTracks[WALK_INDEX]);
            kittenAnim.SetTrigger("Kitten_Walk");
            kittenAnim.speed = 1.5f;
        }
        if (move_horizontal >= -0.05f && move_horizontal <= 0.05f && isjumping == false)
        {
            kittenAnim.SetTrigger("Kitten_Stand_Idle");
            if (!isjumping)
                this.playerAudio.Stop();
        }
    }

    

    
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Interactable") || collision.gameObject.CompareTag("Flying"))
            isjumping = true;
    }
    

    // Play sound if moving
    void MovementSound(float speed)
    {
        if (speed != 0.0f)
        {
            if (!this.playerAudio.isPlaying)
                this.playerAudio.PlayOneShot(audioTracks[WALK_INDEX]);
        }
        else
            if(!isjumping)
                this.playerAudio.Stop();
    }

    /*
    // Collision With the Ground 
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Interactable") || other.gameObject.CompareTag("Flying"))
        {
            if (isjumping == true)
            {
                kittenAnim.SetTrigger("Kitten_Land");
            }
            isjumping = false;

            rb.velocity = Vector2.zero;
        }
    }
    */

    // Push object
    void OnCollisionStay2D(Collision2D colInfo)
    {
        // Is this obj interactable?
        if (colInfo.collider.CompareTag("Interactable"))
        {
            colInfo.gameObject.GetComponent<Movable_Object>().MoveThisTowards(this.deltaPos);
        }
        else if (colInfo.gameObject.CompareTag("Ground") || colInfo.gameObject.CompareTag("Interactable") || colInfo.gameObject.CompareTag("Flying"))
        {
            if (isjumping == true)
            {
                kittenAnim.SetTrigger("Kitten_Land");
            }
            isjumping = false;
        }
    }

    // Push Player
    public void PushPlayer(float force)
    {
        if (force == 0f)
        {
            isBeingPushed = false;
        }
        else
        {
            isBeingPushed = true;
        }

        windForce = force;
    }

    void OnTriggerEnter2D(Collider2D colInfo)
    {
        if(colInfo.CompareTag("End"))
        {
            killPlayer();
        }
    }

    public void killPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
