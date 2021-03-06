using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class Player : NetworkBehaviour
{
    [SerializeField]
    private float maxHealth = 100f;
    private bool menu = false;

    [SyncVar]
    public float currHealth;
    private Transform health;
    private Text healthText;
    private GameObject hud;
    private bool shouldDie = false;
    public bool isDead = false;

    public delegate void DieDelegate();
    public event DieDelegate EventDie;

    public delegate void RespawnDelegate();
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
        GameObject.Find("GM").GetComponent<GameManager_References>().hud.SetActive(true);
        health = GameObject.Find("HUD/Health/Bar").transform;
        healthText = GameObject.Find("HUD/Health/healthText").GetComponent<Text>();
        hud = GameObject.Find("HUD");
        SetHealth();
        //GameObject.Find("timerText").GetComponent<GameTimer>().timer = -1;

    }
    void Update()
    {
        CheckCondition();
        SetHealth();
    }
    void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && menu == false)
        {
            menu = true;
            Cursor.visible = true;
            GameObject.Find("GM").GetComponent<GameManager_References>().menu.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Escape) && menu == true)
        {
            menu = false;
            Cursor.visible = false;
            GameObject.Find("GM").GetComponent<GameManager_References>().menu.SetActive(false);
        }
    }
    void SetHealth()
    {
        if (isLocalPlayer)
        {
            float t_health_ratio = currHealth / maxHealth;
            health.localScale = Vector3.Lerp(health.localScale, new Vector3(t_health_ratio, 1, 1), Time.deltaTime * 8f);
            healthText.text = "Health: " + currHealth.ToString();


        }
    }

    void CheckCondition()
    {
        if (currHealth <= 0 && !shouldDie && !isDead)
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