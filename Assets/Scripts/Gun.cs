using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Gun : MonoBehaviour
{
    public GameObject hitPrefab;
    public float maxDistance = 100;
    public GameObject flashEffect;

    private AudioSource source;
    public AudioClip shootSound;

    public UnityEvent onShoot;

    public int maxAmmo = 30;
    public int ammo;

    public float recoilAngle = 1;
    public int shotsPerAmmo = 5;

    public int damage = 10;

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            TryShoot();
        }
    }

    void TryShoot()
    {
        if (ammo <= 0) return;
        ammo--;
        onShoot.Invoke();

        flashEffect.SetActive(true);
        Invoke("DisableFlashEffect", 0.05f);

        source.pitch = Random.Range(0.8f, 1.2f);
        source.PlayOneShot(shootSound);


        for (int i = 0; i < shotsPerAmmo; i++)
        {
            Shoot();
        }
    }


    void Shoot()
    {
        var cam = Camera.main;
        var dir = cam.transform.forward;

        var offsetX = Random.Range(-recoilAngle, recoilAngle);
        var offsetY = Random.Range(-recoilAngle, recoilAngle);
        dir = Quaternion.Euler(offsetX, offsetY, 0) * dir;

        var ray = new Ray(cam.transform.position, dir);


        if (Physics.Raycast(ray, out var hit, maxDistance))
        {
            var health = hit.transform.GetComponent<Health>();
            if (health)
            {
                health.Damage(damage);
            }

            if (!hit.transform.CompareTag("Enemy"))
            {
                var hitObj = Instantiate(hitPrefab, hit.point, Quaternion.Euler(0, 0, 0), hit.transform);
                hitObj.transform.forward = hit.normal;
                hitObj.transform.position += hit.normal * 0.02f;
            }
        }
    }

    void DisableFlashEffect()
    {
        flashEffect.SetActive(false);
    }
}