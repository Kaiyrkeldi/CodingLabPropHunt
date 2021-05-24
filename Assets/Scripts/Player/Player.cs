using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    [SerializeField]
    private float maxHealth = 100f;

    [SyncVar]
    public float currHealth;
    private Transform health;
    private Text healthText;
    private GameObject hud;
    private bool shouldDie = false;
    public bool isDead = false;

    public delegate void DieDelegate();
    public event DieDelegate EventDie;

    public delegate void RespawnDelegate ();
    public event RespawnDelegate EventRespawn;

    void Awake()
    {
        currHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currHealth -= damage;
        Debug.Log(transform.name + "has " + currHealth);
    }
    void Start()
    {
        health = GameObject.Find("HUD/Health/Bar").transform;
        healthText = GameObject.Find("HUD/Health/healthText").GetComponent<Text>();
        hud = GameObject.Find("HUD");
        SetHealth();
    }
    void Update()
    {
        CheckCondition();
        SetHealth();
    }
    void SetHealth()
    {
        if (isLocalPlayer) {
            float t_health_ratio = currHealth / maxHealth;
            health.localScale = Vector3.Lerp(health.localScale, new Vector3(t_health_ratio, 1, 1), Time.deltaTime * 8f);
            healthText.text = "Health: " + currHealth.ToString();


        }
    }

    void CheckCondition()
    {
        if(currHealth<= 0 && !shouldDie && !isDead)
        {
            shouldDie = true;
        }
        if (currHealth <= 0 && shouldDie)
        {
            if (EventDie != null)
            {
                EventDie();
            }
        }
        shouldDie = false;

        if (currHealth > 0 && isDead)
        {
            if (EventRespawn != null)
            {
                EventRespawn();
            }
            isDead = false;
        }
    }

    public void ResetHealth()
    {
        currHealth = maxHealth;
    }
}
