using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject hitPrefab;
    public GameObject muzzlePrefab;
    public float maxDistance = 100;

    public AudioClip gunshotSound;
    private AudioSource source;

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        var cam = Camera.main;
        var ray = new Ray(cam.transform.position, cam.transform.forward);

        muzzlePrefab.SetActive(true);
        Invoke("DisableFlashEffect", 0.05f);

        source.pitch = Random.Range(0.8f, 1.2f);
        source.PlayOneShot(gunshotSound);

        if (Physics.Raycast(ray, out var hit, maxDistance))
        {
             print(hit.point);
             var hitObj = Instantiate(hitPrefab, hit.point, Quaternion.Euler(0, 0, 0));
             hitObj.transform.forward = hit.normal;
             hitObj.transform.position += hit.normal * 0.02f;

        }
    }

    void DisableFlashEffect()
    {
        muzzlePrefab.SetActive(false);
    }
}
