using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    public Rigidbody2D Body {get; private set;}
    private float _direction;

    private bool _canMove = true;
    private bool _jump = false;

    private void Awake() {
        Body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        if(_canMove){
            Move();
        }

        if(_jump){
            ApplyJumpForce();
        }
    }

    private void Move(){
        Body.velocity = new Vector2(_direction * _moveSpeed, Body.velocity.y);
    }

    public void SetDirection(float direction){
        _direction = direction;
    }

    public void AllowMovement(bool canMove){
        _canMove = canMove;
    }

    public void Jump(bool jump){
        _jump = jump;
    }

    public void ApplyJumpForce(){
        Body.AddForce(new Vector2(0,_jumpForce), ForceMode2D.Impulse);
        _jump = false;
    }

    public void StopJumpForce(){
        Body.velocity = new Vector2(0,0);
    }
}