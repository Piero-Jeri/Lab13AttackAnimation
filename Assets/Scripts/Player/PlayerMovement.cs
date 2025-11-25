using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;

    public float Speed = 1f;
    public float JumpForce = 5;
    public float DetectSize = 0.1f;
    public float Distance = 0.1f;
    private bool isGrounded;

    public Transform FeetReference;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        PlayerController.Instance.InputManager.OnJumpPerformed += Jump;

        SoundManager.Instance.PlaySound("JumpSFX", 10);
    }

   
    void Update()
    {
        isGrounded = CheckIfGrounded();
    }

    public void Jump()
    {

    }

    public void Movement()
    {

    }

    public bool CheckIfGrounded()
    {
        Vector2 size = new Vector2(DetectSize, DetectSize);
        RaycastHit2D[] hitInfos=  Physics2D.BoxCastAll(FeetReference.transform.position, size,0,Vector2.down, Distance);

        foreach (var coll in hitInfos)
        {
            GameObject go = coll.collider.gameObject;
            if (go.tag == "Ground")
            {
                //print(go.name);
                return true;
            }
        }
        
        return false;

    }

    public bool IsGrounded => isGrounded;


}
