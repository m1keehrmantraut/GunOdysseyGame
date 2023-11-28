using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class BaseHealth : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 100;
    private int currentHealth;
    [SerializeField] private HealthBar healthBar;

    [SerializeField] private Shooting[] guns;
    [SerializeField] private Laser[] lasers;

    [SerializeField] private Image[] Cells;

    [SerializeField] private Sprite activeSprite;
    [SerializeField] private Sprite defaultSprite;

    public UnityEvent OnBaseDestroy;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip changeButtonSound;
    
    private bool firstGun = false;
    private bool secondGun = false;

    private int damager;
    
    void Start ()
    {
        UpdateMaxHealth();
    }

    public void TakeDamage (int damage)
    {
        damage += damager;
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        
        if (currentHealth <= 0)
        {
            audioSource.clip = deathSound;
            audioSource.Play();
            OnBaseDestroy.Invoke();
            Debug.Log("You lose");
        }
    }

    public void UpdateMaxHealth()
    {
        currentHealth = maxHealth;  
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && firstGun)
        {
            DeactivateCells();
            ActivateGun(0);
            Cells[0].sprite = activeSprite;
            PlayChangeSound();
        }
        
        if (Input.GetKeyDown(KeyCode.S) && secondGun)
        {
            DeactivateCells();
            ActivateGun(1);
            Cells[1].sprite = activeSprite;
            PlayChangeSound();
        }

        if (Input.GetKeyDown(KeyCode.D) )
        {
            DeactivateCells();
            ActivateLaser(0);
            Cells[2].sprite = activeSprite;
            PlayChangeSound();
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            DeactivateCells();
            ActivateLaser(1);
            Cells[3].sprite = activeSprite;
            PlayChangeSound();
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void ActivateGun(int index)
    {
        DeactivateAllGuns();
        guns[index].ChangeGunMode(true);
    }
    
    private void ActivateLaser(int index)
    {
        DeactivateAllGuns();
        lasers[index].ChangeLaserMode(true);
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    private void DeactivateAllGuns()
    {
        if (firstGun)
        {
            guns[0].ChangeGunMode(false);    
        }

        if (secondGun)
        {
            guns[1].ChangeGunMode(false);
        }
        lasers[0].ChangeLaserMode(false);
        lasers[1].ChangeLaserMode(false);
    }

    public void ActivateFirst()
    {
        firstGun = true;
    }
    public void ActivateSecond()
    {
        secondGun = true;
    }

    public void DeactivateCells()
    {
        for (int i = 0; i < Cells.Length; i++)
        {
            Cells[i].sprite = defaultSprite;
        }
    }

    private void PlayChangeSound()
    {
        audioSource.clip = changeButtonSound;
        audioSource.Play();
    }

    public void IncreaseDamage(int amount)
    {
        damager += amount;
    }
}

