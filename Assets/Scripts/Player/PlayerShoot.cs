using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour
{
    public Weapon weapon;
    public float fireRate = 1;
    public GameObject muzzleFlash;
    public AudioSource _audioSource;
    public AudioClip aclip;
    [SerializeField]
    private Camera cam;

    public Transform bulletSpawnPoint;
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private LayerMask mask;

    void Start()
    {
        if (cam == null)
        {
            Debug.LogError("PlayerShoot: No Camera");
            this.enabled = false;
        }
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
        _audioSource.PlayOneShot(aclip);
        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask))
        {
            print("We shot at " + _hit.collider.name);
            GameObject _gfxIns = (GameObject)Instantiate(muzzleFlash, _hit.point, Quaternion.identity);
            Destroy(_gfxIns, 0.3f);
            if (_hit.collider.tag == "Prop")
            {
                CmdPlayerShoot(_hit.collider.name, weapon.damage);
            }
            else
            {
                CmdPlayerShoot(this.gameObject.name, (weapon.damage / 5));
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
