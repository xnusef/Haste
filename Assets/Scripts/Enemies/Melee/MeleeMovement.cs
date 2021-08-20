using UnityEngine;

public class MeleeMovement : MonoBehaviour
{
    [System.NonSerialized]public Melee enemyScript;
    [SerializeField] private float movementSpeed;
    private Rigidbody2D enemyRb;
    private bool facingRight = false;
    void Awake()
    {
        this.enemyScript = GetComponent<Melee>();
        this.enemyRb = GetComponent<Rigidbody2D>();
    }
    public void ManageMovement(int direction)
    {  
        direction = -direction;
        if (direction != 0)
            this.enemyScript.enemyAnimator.SetBool("Running", true);
        else
            this.enemyScript.enemyAnimator.SetBool("Running", false);
        Move(direction);
    }
    void Move(int internalDirection)
    {
        SetVelocity(this.movementSpeed * internalDirection, this.enemyRb.velocity.y);
    }
    public void ManageFlip(int internalDirection)
    {
        internalDirection = -internalDirection;
        if ((internalDirection < 0 && this.facingRight) || (internalDirection > 0 && !this.facingRight))
            Flip();
    }
    private void Flip()
	{
		this.facingRight = !this.facingRight;
		Vector3 theScale = this.transform.localScale;
		theScale.x *= -1;
		this.transform.localScale = theScale;
	}
    void SetVelocity(float x, float y)
    {
        this.enemyRb.velocity = new Vector2(x,y);
    }
}