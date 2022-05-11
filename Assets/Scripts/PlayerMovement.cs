using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveHorizontal;
    private float moveVertical;
    [SerializeField] private float speed;
    [SerializeField] private float speed2; // "Strafing" speed
    public Rigidbody2D player;
    private Vector2 movement;

    // added by Fiona for testing
    public GameObject staff;

    private Animator animator;
    private string currentAnimation;

    bool faceRight = true;

    // Animation states
    const string PLAYER_IDLE = "PlayerIdle";
    const string PLAYER_DOWN = "PlayerDown";
    const string PLAYER_DOWNRIGHT = "PlayerDownRight";
    const string PLAYER_RIGHT = "PlayerRight";
    const string PLAYER_UP = "PlayerUp";
    const string PLAYER_UPRIGHT = "PlayerUpRight";

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
       // Debug.Log("horizontal: " + moveHorizontal + " vertical: " + moveVertical);
    }

    private void FixedUpdate()
    {
        // Player movement
        movement = new Vector2(moveHorizontal, moveVertical);

        // Changing animation states
        if (moveHorizontal > 0 && moveVertical == 0)
        {
            player.velocity = movement * speed;
            ChangeAnimationState(PLAYER_RIGHT);
            if (!faceRight)
            {
                Flip();
                FlipChildren();
            }
        }

        if (moveHorizontal < 0 && moveVertical == 0)
        {
            player.velocity = movement * speed;
            ChangeAnimationState(PLAYER_RIGHT);
            if (faceRight)
            {
                Flip();
                FlipChildren();
            }
        }

        if (moveVertical > 0 && moveHorizontal == 0)
        {
            player.velocity = movement * speed;
            ChangeAnimationState(PLAYER_UP);
        }

        if (moveVertical > 0 && moveHorizontal > 0)
        {
            player.velocity = movement * speed2;
            ChangeAnimationState(PLAYER_UPRIGHT);
            if (!faceRight)
            {
                Flip();
                FlipChildren();
            }
        }

        if (moveVertical > 0 && moveHorizontal < 0)
        {
            player.velocity = movement * speed2;
            ChangeAnimationState(PLAYER_UPRIGHT);
            if (faceRight)
            {
                Flip();
                FlipChildren();
            }
        }

        if (moveVertical < 0 && moveHorizontal == 0)
        {
            player.velocity = movement * speed;
            ChangeAnimationState(PLAYER_DOWN);
        }

        if (moveVertical < 0 && moveHorizontal > 0)
        {
            player.velocity = movement * speed2;
            ChangeAnimationState(PLAYER_DOWNRIGHT);
            if (!faceRight)
            {
                Flip();
                FlipChildren();
            }
        } 
        
        if (moveVertical < 0 && moveHorizontal < 0)
        {
            player.velocity = movement * speed2;
            ChangeAnimationState(PLAYER_DOWNRIGHT);
            if (faceRight)
            {
                Flip();
                FlipChildren();
            }
        }

        if (moveHorizontal == 0 && moveVertical == 0)
        {
            player.velocity = movement;
            ChangeAnimationState(PLAYER_IDLE);
        }
    }

    void ChangeAnimationState(string newState)
    {
        // prevents animation from getting interrupted by itself
        if (currentAnimation == newState) return;

        animator.Play(newState);
    }

    private void Flip()
    {
        faceRight = !faceRight;

        Vector2 theScale = transform.localScale;
        theScale.x = theScale.x * -1;
        transform.localScale = theScale;       
    }

    private void FlipChildren()       
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).localScale *= -1;
        }
    }
}
