using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayReloadTime = 1f;
    [SerializeField] ParticleSystem particalEffect;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            particalEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", delayReloadTime);
        }
    }

    void ReloadScene() {
        SceneManager.LoadScene(0);
    }
}
