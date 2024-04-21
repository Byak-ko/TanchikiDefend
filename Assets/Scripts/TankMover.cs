    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TankMover : MonoBehaviour
{
    public Rigidbody2D rb2d;

    public TankMovementData movementData;

    private Vector2 movementVector;
    private float currentSpeed = 0;
    private float currentForewardDirection = 1;
    private float _remainingTime;
    private Slider _nitroSlider;

    public UnityEvent<float> OnSpeedChange = new UnityEvent<float>();

    private bool isBoosting = false;

    private void Start()
    {
        GameObject nitroSlObj = GameObject.Find("NitroHUD");
        _nitroSlider = nitroSlObj.GetComponent<Slider>();
    }
    private void Awake()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
    }

    public void Move(Vector2 movementVector)
    {
        this.movementVector = movementVector;
        CalculateSpeed(movementVector);
        OnSpeedChange?.Invoke(this.movementVector.magnitude);
        if (movementVector.y > 0)
        {
            if (currentForewardDirection == -1)
                currentSpeed = 0;
            currentForewardDirection = 1;
        }  
        else if (movementVector.y < 0)
        {
            if (currentForewardDirection == 1)
                currentSpeed = 0;
            currentForewardDirection = -1;
        }
            
    }

    private void CalculateSpeed(Vector2 movementVector)
    {
        if (Mathf.Abs(movementVector.y) > 0)
        {
            currentSpeed += movementData.acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed -= movementData.deacceleration * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, movementData.maxSpeed);
    }

    private void FixedUpdate()
    {
        rb2d.velocity = (Vector2)transform.up * currentSpeed * currentForewardDirection * Time.fixedDeltaTime;
        rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * movementData.rotationSpeed * Time.fixedDeltaTime));
    }

    public void ActivateBoost()
    {

         StartCoroutine(BoostCoroutine());
        
    }

    private IEnumerator BoostCoroutine()
    {
        isBoosting = true;
        float originalMaxSpeed = movementData.maxSpeed;
        movementData.maxSpeed *= 2;

        _remainingTime = 10f;
        _nitroSlider.value = 1f;

        while (_remainingTime > 0)
        {
            _remainingTime -= Time.deltaTime;

            if (_nitroSlider != null)
            {
                _nitroSlider.value = _remainingTime / 10f;
            }

            yield return null;
        }

        movementData.maxSpeed = originalMaxSpeed;
        isBoosting = false;
        Debug.Log("Nitro work");
    }
}
