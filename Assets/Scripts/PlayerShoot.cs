using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletForce;
    [SerializeField] private float timeBetweenShoot;
    [SerializeField] private int ammoInMagazine;
    [SerializeField] private float reloadingTime = 2f;
    [SerializeField] private Text ammoCapacityText;
    
    
    private float shootTimer = 0f;
    private bool isReloading = false;
    private PlayerHealth playerHealth;
    private int ammoCapacity;


    // Start is called before the first frame update
    void Start()
    {
        ammoCapacity = ammoInMagazine;
        ammoCapacityText.text = "Ammo: " + ammoCapacity.ToString();
        playerHealth = GameManager.Instance.player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isReloading == false)
            shootTimer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && timeBetweenShoot < shootTimer && !isReloading && playerHealth.isAlive)
        {
            Shoot();
            shootTimer = 0f;
        }
        else if(ammoCapacity == 0)
        {
            ammoCapacityText.text = "Reloading";
            StartCoroutine(Reloading());
            ammoCapacity = ammoInMagazine;
            shootTimer = timeBetweenShoot;
        }
    }



    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        ammoCapacity--;
        ammoCapacityText.text = "Ammo: " + ammoCapacity.ToString();
    }

    IEnumerator Reloading()
    {
        isReloading = true;
        //print("Reloading");
        yield return new WaitForSeconds(reloadingTime);
        //print("Reloaded");
        isReloading = false;
        ammoCapacityText.text = "Ammo: " + ammoCapacity.ToString();
    }
}
