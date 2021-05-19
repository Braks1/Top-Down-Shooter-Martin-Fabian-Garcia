using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fireButton : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    bool reloading;
    public int ammo = 20;
    public float bulletForce = 20f;
    public Sprite[] bulletDisplay;
    public int ammoDisplay = 0;
    public GameObject iD;
    public GameObject reloadObject;
    public timerReload timerReload;
    public AudioSource reloadSound;
    public AudioClip impact;
    public AudioSource shootSfx;


   
    void Update()
    {
        
        if (reloading == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {

                shootSfx.PlayOneShot(impact, 0.7F);
                Shoot();
                
            }
        }


        if (ammoDisplay >= 0)
        {
            iD.GetComponent<SpriteRenderer>().sprite = bulletDisplay[ammoDisplay];
        }



        

    }

    void Shoot()
    {
        GameObject Bollet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = Bollet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        
        ammo--;
        ammoDisplay += 1;
        if (ammo <= 0)
        {
            reloading = true;
            reloadTimer();
            reloadSound.Play();
            StartCoroutine(Reload());
            


            IEnumerator Reload()
            {
                yield return new WaitForSecondsRealtime(5);
                ammo = 20;
                ammoDisplay = 0;
                reloading = false;
                



            }

           

            
        }

        void reloadTimer ()
        {
            reloadObject.SetActive(true);
            timerReload.maxTime = 5f;
            timerReload.timeLeft = 5f;
            if (timerReload.maxTime == 0f)
            {
                reloadObject.SetActive(false);
                timerReload.timeLeft = 0;
            }

        }

        
        
    }

    





}
