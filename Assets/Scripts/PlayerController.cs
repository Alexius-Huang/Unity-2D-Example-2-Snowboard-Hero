using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    SurfaceEffector2D se2d;
    CapsuleCollider2D capsuleC2d;
    [SerializeField] float torque = 5;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 15f;
    [SerializeField] ParticleSystem snowTrailEffect;

    bool isMovable = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        capsuleC2d = GetComponent<CapsuleCollider2D>();
        se2d = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if (isMovable) {
            RotatePlayer();
            RespondToBoost();
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torque);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torque);
        }
    }

    private void RespondToBoost() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            se2d.speed = boostSpeed;
        } else {
            se2d.speed = baseSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "LevelGround" && capsuleC2d.IsTouching(other.collider)) {
            snowTrailEffect.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "LevelGround" && !capsuleC2d.IsTouching(other.collider)) {
            snowTrailEffect.Stop();
        }
    }

    public void DisableControl() {
        isMovable = false;
    }
}
