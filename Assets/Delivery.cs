using UnityEngine;
using System.Linq;
using System;

public class Delivery : MonoBehaviour
{   
    private Driver driver;
    private GameObject[] iceCreamSpots;
    private int range; 

    void Start()
    {   
        GetComponent<ParticleSystem>().Stop();
        driver = GetComponent<Driver>();
        iceCreamSpots = (Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[]).Where(obj => obj.tag == "Package").ToArray();
        range = iceCreamSpots.Length;

        Debug.Log(range);

        hideAllIceCreamSpots();
        spawnRandomIceCreamSpot();
    }
 
    void OnCollisionEnter2D(Collision2D collision)
    {
        driver.slowDown();
        Debug.Log("Çarpışma meydana geldi.");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {   
        
        if ( collision.CompareTag("Package") && !driver.hasPackage)
        {   
            Debug.Log("Paket alındı.");
            driver.hasPackage = true;
            GetComponent<ParticleSystem>().Play();
            collision.gameObject.SetActive(false);
            
        }
        else if (collision.CompareTag("Customer") && driver.hasPackage)
        {
            driver.hasPackage = false;
            GetComponent<ParticleSystem>().Stop();
            spawnRandomIceCreamSpot();

            Debug.Log("Müşteriye bırakıldı!");

        }
        else if (collision.CompareTag("Boost"))
        {
            driver.speedUp();
            Destroy(collision.gameObject,.1f);
        }

    }


    void spawnRandomIceCreamSpot()
    {   
        System.Random rand = new System.Random();
        int spawnPoint = rand.Next(0, range);
        iceCreamSpots[spawnPoint].SetActive(true);
    }

    void hideAllIceCreamSpots()
    {
        foreach (GameObject obj in iceCreamSpots)
        {
            obj.SetActive(false);
        }
    }
}
