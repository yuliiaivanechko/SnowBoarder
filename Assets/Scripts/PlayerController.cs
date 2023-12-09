using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torkAmount = 1f;
    [SerializeField] private float boostSpeed = 30f;
    [SerializeField] private float normalSpeed = 20f;

    bool canMove = true;
    Rigidbody2D rBody;

    SurfaceEffector2D sEffector;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        sEffector = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rBody.AddTorque(torkAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rBody.AddTorque(-torkAmount);
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }
    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            sEffector.speed = boostSpeed;
        }
        else
        {
            sEffector.speed = normalSpeed;
        }
    }
}
