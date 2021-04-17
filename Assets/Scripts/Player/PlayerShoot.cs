using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(AudioSync))]
public class PlayerShoot : NetworkBehaviour
{
    public Weapon weapon;
    public float fireRate = 1;
    public ParticleSystem muzzleFlash;
    public AudioSource _audioSource;
    private AudioSync audioSync;
    [SerializeField]
    private Camera cam;

    public Transform bulletSpawnPoint;
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private LayerMask mask;
    
    void Start()
    {
        if (cam == null) { 
            Debug.LogError("PlayerShoot: No Camera");
            this.enabled = false;
        }
        audioSync = this.GetComponent<AudioSync>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        
    }

    [Client]
    void Shoot()
    {
        audioSync.PlaySound(0); 
        muzzleFlash.Play();
        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask))
        {
            print("We shot at " + _hit.collider.name);
            if (_hit.collider.tag == "Player")
            {
              CmdPlayerShoot(_hit.collider.name, weapon.damage);
            }
            else
            {
              CmdPlayerShoot(this.gameObject.name, (weapon.damage/5));
            }
        }
        

    }

    [Command]
    void CmdPlayerShoot(string _id, float damage)
    {
        Player player = GameManager.GetPlayer(_id);
        player.TakeDamage(damage);
    }
}
