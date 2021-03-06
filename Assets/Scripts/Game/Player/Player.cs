using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector]public PlayerState stateScript;
    [HideInInspector]public PlayerMovement movementScript;
    [HideInInspector]public PlayerAttack attackScript;
    [HideInInspector]public PlayerSpecial specialScript;
    [HideInInspector]public EntityAudio playerAudio;
    [HideInInspector]public Animator playerAnimator;
    [HideInInspector]public HealthBar healthBar;

    #region Getters & Setters
    public void SetAnimationBool(string name, bool value)
    {
        playerAnimator.SetBool(name, value);
    }
    #endregion

    void Awake()
    {
        this.stateScript = this.GetComponent<PlayerState>();
        this.movementScript = this.GetComponent<PlayerMovement>();
        this.attackScript = this.GetComponent<PlayerAttack>();
        this.specialScript = this.GetComponent<PlayerSpecial>();
        this.playerAudio = this.GetComponent<EntityAudio>();
        this.playerAnimator = this.GetComponent<Animator>();
        this.healthBar = GameObject.Find("/UI/Canvas/HealthBar/Slider").GetComponent<HealthBar>();
    }
    void Start()
    {
        this.healthBar.SetMaxHealth(GameManager.gM.maxPlayerHealth);
        this.healthBar.SetHealth(GameManager.gM.currentPlayerHealth);
    }
    public void Damaged(int damage)
    {
        if(!stateScript.GetState("Dashing"))
        {
            if (GameManager.gM.currentPlayerHealth > 0)
            {
                playerAudio.Play("Hurt");
                this.playerAnimator.SetTrigger("Hurt");
            }
            GameManager.gM.currentPlayerHealth = GameManager.gM.currentPlayerHealth - damage;
            this.healthBar.SetHealth(GameManager.gM.currentPlayerHealth);
            if (GameManager.gM.currentPlayerHealth <= 0)
                Die();
        }
    }
    void Die()
    {
        playerAudio.Play("Die");
        this.stateScript.SetState("IsDead", true);
    }
    public void EndDie()
    {
        GameManager.gM.SetMaxHealth();
        LevelManager.lM.RestartLevel();
    }
}