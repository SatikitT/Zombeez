using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float minY = -4.5f;  
    public float maxY = 4.5f;
    public TMP_Text coinText;
    public int initialCarHealth = 10;
    public int initialCarEnergy = 100;
    public Image Heatlbar;
    public ToggleLight light;

    private int coin = 0;
    private int currentCarHealth;
    private AudioManager audioManager;
    private GunController gun;
    private Vector3 initialPosition = new Vector3(-5.89f, -1.34f, 0f);

    void Awake()
    {
        currentCarHealth = initialCarHealth;
    }

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        gun = GetComponent<GunController>();
        light.energy = initialCarEnergy;
    }

    void Update()
    {
        coinText.text = coin.ToString();
        Heatlbar.fillAmount = currentCarHealth / 10f;
        MoveCar();
    }

    public void ResetCar()
    {
        light.highLight.SetActive(false);
        light.lowLight.SetActive(true);
        currentCarHealth = initialCarHealth;
        light.energy = initialCarEnergy;
        GetComponent<Transform>().localPosition = initialPosition;
    }

    public int GetCurrentCarHealth()
    {
        return currentCarHealth;
    }

    void MoveCar()
    {
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 newPosition = transform.position + new Vector3(0, verticalInput * moveSpeed * Time.deltaTime, 0);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        transform.position = newPosition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Debug.Log("hit coin");
            audioManager.PlaySFX(audioManager.collectCoin);
            coin += 1;
            Destroy(other.gameObject);
        } else if (other.gameObject.CompareTag("Zombie"))
        {
            Debug.Log("hit zombie");
            currentCarHealth -= 1;  
            Destroy(other.gameObject);
        } else if (other.gameObject.CompareTag("Battery"))
        {
            Debug.Log("hit batt");
            light.energy += 10;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("BulletRefill"))
        {
            Debug.Log("add bullet");
            gun.ammo += 3;
            Destroy(other.gameObject);
        }
    }
}
