using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveOnTouch : MonoBehaviour
{
    private DuckTouchControl inputActions;
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private bool isSwiping = false;
    private bool isDiving = false;

    [SerializeField] private float swipeThreshold = 20f;
    [SerializeField] private float upForce = 100f;
    [SerializeField] private float downForce = 100f;
    [SerializeField] private float tiltAngle = 45f;
    [SerializeField] private float smooth = 5f;
    [SerializeField] private float timeBeforeFly = 0.3f;
    private float flyTimer = 0f;
    private bool jumpQueued = false;
    private float queuedJumpForce = 0f;

    private Rigidbody2D rb;

    private void Awake()
    {
        inputActions = new DuckTouchControl();
    }

    private void OnEnable()
    {
        inputActions.Enable();

        // Touch Controls
        inputActions.TouchControls.TouchPress.started += ctx => StartTouch();
        inputActions.TouchControls.TouchPress.canceled += ctx => EndTouch();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        swipeThreshold = Screen.height * 0.07f; // 7% of screen height
    }

    private void StartTouch()
    {
        startTouchPosition = inputActions.TouchControls.TouchPosition.ReadValue<Vector2>();
        isSwiping = true;
        isDiving = true;
    }

    private void EndTouch()
    {
        if (!isSwiping) return;

        isDiving = false;
        endTouchPosition = inputActions.TouchControls.TouchPosition.ReadValue<Vector2>();
        Vector2 swipeDelta = endTouchPosition - startTouchPosition;

        if (Mathf.Abs(swipeDelta.y) > swipeThreshold)
        {
            if (swipeDelta.y > 0)
            {
                // Swipe Up (Fly)
                Fly(swipeDelta.y);
            }
        }

        isSwiping = false;
    }

    private void Update()
    {
        if (isDiving)
        {
            Dive();
        }
        else
        {
            ResetRotation();
        }
    }

    private void FixedUpdate()
    {
        if (jumpQueued)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // Reset velocity
            rb.AddForce(new Vector2(0, queuedJumpForce), ForceMode2D.Impulse);
            jumpQueued = false;
        }
    }

    private void Dive()
    {
        rb.AddForce(Vector2.down * downForce * 1f, ForceMode2D.Force);
        Quaternion target = Quaternion.Euler(0, 0, -tiltAngle * 2f);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

    }

    private void ResetRotation()
    {
       //Reset Duck Rotation when not Diving
        float currentAngle = transform.rotation.eulerAngles.z;
        float targetAngle = 0f;

        float smoothedAngle = Mathf.LerpAngle(currentAngle, targetAngle, Time.deltaTime * smooth * 3);
        Quaternion baseTarget = Quaternion.Euler(0, 0, smoothedAngle);
        transform.rotation = Quaternion.Slerp(transform.rotation, baseTarget, Time.deltaTime * smooth);
    }

    private void Fly(float swipeDistance)
    {
        if (Time.time > flyTimer && transform.rotation.z > -45 && transform.position.y > -1.5 && transform.position.y < 2)
        {
            float forceMultiplier = Mathf.Clamp(swipeDistance / (Screen.height * 0.3f), 0.5f, 2f);
            queuedJumpForce = upForce * forceMultiplier;
            jumpQueued = true;
            flyTimer = Time.time + timeBeforeFly;
        }
    }
}