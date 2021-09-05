using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider healthSlider;
    
    void Start()
    {
        this.healthSlider = this.GetComponent<Slider>();
    }
    public void SetMaxHealth(int health)
    {
        healthSlider.maxValue = health;
        SetHealth(PlayerManager.pM.currentPlayerHealth);
    }
    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }
}