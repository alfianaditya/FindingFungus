using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;


public class AxeThrow : MonoBehaviour
{

    GameObject weapon;
    Rigidbody weaponRb;
    WeaponMono weaponScript;

    [Header("State Control Bools")]
    public bool isAiming;
    public bool hasWeapon = true;
    public bool pulling = false;
    public float throwPower;
    [Space]
    [Header("Public References for Return Path")]
    //weapon pull variables
    public Transform curvePoint;
     public Transform hand;
    Vector3 originalLoc;
    Vector3 reachPoint;
    float time = 0f;

    //axe position in hand
    Vector3 originalHandLoc;
    Vector3 originalHandRot;



    ThirdPersonController tpc;


    Animator thisPlayerAnimator;
    [Header("UI")]
    public Animator aimCursorAnimator;



    [Space]
    [Header("Public References for Effects")]
    //effect variables
    public CinemachineImpulseSource impulseSource;
    public TrailRenderer trail;
    void Start()
    {
        thisPlayerAnimator = GetComponentInChildren<Animator>();
        tpc = GetComponent<ThirdPersonController>();
        
        //weapon init
        weapon = GameObject.FindGameObjectWithTag("Weapon");
        weaponRb = weapon.GetComponent<Rigidbody>();
        weaponScript = weapon.GetComponent<WeaponMono>();
        originalHandLoc = weapon.transform.localPosition;
        originalHandRot = weapon.transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        
        if(isAiming && hasWeapon && Input.GetKeyDown(KeyCode.Mouse0)){
            ThrowAxe();
        }

        if(!hasWeapon && Input.GetKeyDown(KeyCode.E)){
            PullWeapon();
        }

        if(pulling){
            CalculateAxePath();
        }
             
        
    }

    void Aim(){
        if(Input.GetKeyDown(KeyCode.Mouse1) && hasWeapon){
            isAiming = true;
            thisPlayerAnimator.SetBool("Aiming", isAiming);
            //tpc.RotateToCameraWhileAiming();
            aimCursorAnimator.SetBool("Aim", isAiming);
        }
        
        if(Input.GetKeyUp(KeyCode.Mouse1) && hasWeapon)
        {
            isAiming = false;
            thisPlayerAnimator.SetBool("Aiming", isAiming);
            aimCursorAnimator.SetBool("Aim", isAiming);
        }
    }

    public void ThrowWeapon(){
            hasWeapon = false;
            weaponScript.rotationSpeed *= -1;
            weaponScript.isThrown = true;
            weapon.transform.parent = null;
            weaponRb.isKinematic = false;
            weaponRb.collisionDetectionMode = CollisionDetectionMode.Continuous;
            weapon.transform.eulerAngles = new Vector3(0, -90 +transform.eulerAngles.y, 0);
            weapon.transform.position += transform.right/5;
            weaponRb.AddForce(Camera.main.transform.forward * throwPower + transform.up * 2, ForceMode.Impulse);
    }

    void ThrowAxe(){
        //isAiming=false;
        //thisPlayerAnimator.SetBool("Aiming", isAiming);
        
        thisPlayerAnimator.SetTrigger("Throw");
       

        //effects
        trail.emitting = true;
    }

    void PullWeapon(){
        pulling = true;
        originalLoc = weapon.transform.position;
        weaponScript.rotationSpeed *= -1;
        weaponRb.isKinematic = true;
        weaponRb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        weaponScript.isThrown = true;

        thisPlayerAnimator.SetBool("Pulling", pulling);
    }

    void CalculateAxePath(){
        if(time<1f){
            weapon.transform.position = GetBezierQCCurvePoint(time, originalLoc, curvePoint.position, hand.position);
            time += Time.deltaTime;
        }
        else
        {
            CatchWeapon();
        }
    }

    
    void CatchWeapon(){
        weaponScript.isThrown = false;
        weapon.transform.parent = hand;
        pulling = false;
        thisPlayerAnimator.SetBool("Pulling", pulling);
        weapon.transform.localPosition = originalHandLoc;
        weapon.transform.localEulerAngles = originalHandRot;
        hasWeapon = true;
        time = 0f;

        //effects
        impulseSource.GenerateImpulse(Vector3.right);
        trail.emitting = false;
    }

    public Vector3 GetBezierQCCurvePoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        return (uu * p0) + (2 * u * t * p1) + (tt * p2);
    }
}
