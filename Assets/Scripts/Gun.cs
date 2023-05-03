using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject hitPrefab;
    public GameObject muzzlePrefab;
    public float maxDistance = 100;
    public float gunfireTime;
    public AudioSource gunshotSound;

    private void Start()
    {

        muzzlePrefab.SetActive(false);
    }

    private void Update()
    {
        var ray = new Ray(transform.position, transform.forward);

        if (Time.time < gunfireTime)
        {
            muzzlePrefab.SetActive(true);
        }
        else
        {
            muzzlePrefab.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            muzzlePrefab.SetActive(true);

            if (Physics.Raycast(ray,out var hit, maxDistance))
            {
                print(hit.point);
                var hitObj = Instantiate(hitPrefab, hit.point, Quaternion.Euler(0, 0, 0));
                hitObj.transform.forward = hit.normal;
                hitObj.transform.position += hit.normal * 0.02f;
                gunfireTime = Time.time + 0.1f;
                gunshotSound.Play();

            }
        }
    }
}
