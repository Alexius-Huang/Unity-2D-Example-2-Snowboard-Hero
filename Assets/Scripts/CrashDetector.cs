using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    /*private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "LevelGround") {
            Debug.Log("Dead!!");
        }
    }*/

    CircleCollider2D cc2d;
    [SerializeField] float delayReloadTime = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    bool hasAlreadyCrashed = false;

    void Start() {
        cc2d = GetComponent<CircleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "LevelGround" && cc2d.IsTouching(other.collider) && !hasAlreadyCrashed) {
            hasAlreadyCrashed = true;
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            FindObjectOfType<PlayerController>().DisableControl();
            Invoke("ReloadScene", delayReloadTime);
            Debug.Log("Dead!!");
        }
    }

    public void ReloadScene() {
        SceneManager.LoadScene(0);
    }
}
