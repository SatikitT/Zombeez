using UnityEngine;
using TMPro;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab of the bullet
    public Transform firePoint;     // The point from which the bullet is fired
    public float fireRate = 0.5f;   // Time between shots in seconds
    public float damage = 10f;      // Damage per bullet
    public int ammo = 30;           // Total ammo
    public bool isAutomatic = true;
    public AudioClip fireSound;  
    public AudioClip reloadSound;
    public TMP_Text ammoText;

    private float nextFireTime = 0f;
    private bool isFiring = false;
    private AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        ammoText.text = ammo.ToString();

        if (isAutomatic)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextFireTime && ammo > 0)
            {
                Fire();
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime && ammo > 0)
            {
                Fire();
            }
        }
    }

    void Fire()
    {
        nextFireTime = Time.time + fireRate;
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        ammo--;

        if (fireSound != null && audioManager != null)
        {
            audioManager.PlaySFX(audioManager.shoot);
        }
    }

    public void Reload(int amount)
    {
        ammo += amount;

        if (reloadSound != null && audioManager != null)
        {
            //audioSource.PlayOneShot(reloadSound);
        }
    }
}
