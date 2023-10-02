using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullePET : MonoBehaviour
{
    public bool isShootable = false;
    public GameObject bullet;
    public float bulletSpeed;
    public float timeBtwFire;
    public float fireCooldown;
    public GameObject vitri;
    Vector3 vitriban;
    public Transform chimngu;
    public float lifetime = 2.0f;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fireCooldown -= Time.deltaTime;
        if (fireCooldown < 0)
        {
            vitriban = vitri.transform.position;
            fireCooldown = timeBtwFire;
            PETFireBullet();
            
        }
    }

    void PETFireBullet()
    {
        var bulletTMP = Instantiate(bullet, vitriban, Quaternion.identity);
        Rigidbody2D rb = bulletTMP.GetComponent<Rigidbody2D>();
        Vector3 playerpos = FindObjectOfType<enemiB>().transform.position;
        Vector3 direction = playerpos - vitriban;
        rb.AddForce(direction.normalized * bulletSpeed, ForceMode2D.Impulse);

        
    }


}