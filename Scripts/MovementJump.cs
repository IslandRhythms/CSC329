using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementJump : MonoBehaviour
{
    public float speed = 5.0f;
    public float jump = 20f;
    bool facingright = true;
    private BoxCollider2D boxcol;
    private Animator anim;
    private Rigidbody2D rigidb;
    [SerializeField]private LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidb = GetComponent<Rigidbody2D>();
        boxcol = transform.GetComponent<BoxCollider2D>();
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("move",move);
        Flip(move);
        rigidb.velocity = new Vector2(move*speed,rigidb.velocity.y);
        
    }

    void Update(){
        if(IsGrounded() && Input.GetKeyDown(KeyCode.Space)){
            rigidb.velocity = Vector2.up * jump;
        }

    }

    private bool IsGrounded(){
      RaycastHit2D raycast = Physics2D.BoxCast(boxcol.bounds.center,boxcol.bounds.size,0f,Vector2.down, .1f,ground);
      //Debug.Log(raycast.collider);
      return raycast.collider != null;
    }

    private void Flip(float move){
        if (move > 0 && !facingright || move < 0 && facingright){
            facingright = !facingright;
            transform.Rotate(0f,-180f,0f);
        }
    }
}
