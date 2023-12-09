using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] private AudioClip crashSound;
    bool hasCrashed = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSound);
            Invoke("ReloadScene", 1.0f);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
