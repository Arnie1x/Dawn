using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class GunSystem : MonoBehaviour
{
    //Gun stats
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    public GameObject shootPoint;
    public GameObject projectile;

    public float attackSpeed = 8f;
    public float timeBetweenAttacks = 2f;
    public int attackDamage = 10;


    //bools
    bool shooting, readyToShoot, reloading, alreadyAttacked;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;
    public AudioClip Clip;

    //Graphics
    // public GameObject muzzleFlash, bulletHoleGraphic;
    // public CamShake camShake;
    // public float camShakeMagnitude, camShakeDuration;
    // public TextMeshProUGUI text;

    // Input
    private InputSystem controls;

    private void Start()
    {
        controls = InputSystem.Instance;
    }
    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    private void Update()
    {
        MyInput();

        //SetText
        // text.SetText(bulletsLeft + " / " + magazineSize);
    }
    private void MyInput()
    {
        // if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        // else shooting = Input.GetKeyDown(KeyCode.Mouse0);
        // shooting = controls.attackAction.ReadValue<float>() > 0;
        shooting = true;

        if (controls.reloadAction.ReadValue<float>() > 0 && bulletsLeft < magazineSize && !reloading) Reload();

        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0){
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }
    // ReSharper disable Unity.PerformanceAnalysis
    private void Shoot()
    {
        if (!alreadyAttacked)
        {
            ///Attack code here
            GameObject _projectile = Instantiate(projectile, shootPoint.transform.position, Quaternion.identity);
            Rigidbody rb = _projectile.GetComponent<Rigidbody>();
            rb.AddForce(fpsCam.transform.forward * attackSpeed, ForceMode.Impulse);
            // rb.AddForce(transform.up, ForceMode.Impulse);

            projectile.GetComponent<Projectile>().damage = attackDamage;
            ///End of attack code
            AudioSystem.Instance.PlaySound();

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }
    // ReSharper disable Unity.PerformanceAnalysis
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
