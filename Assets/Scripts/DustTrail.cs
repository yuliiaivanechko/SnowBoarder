using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] private ParticleSystem trailEffect;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Snow")
            trailEffect.Play();

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Snow")
            trailEffect.Stop();

    }
}
