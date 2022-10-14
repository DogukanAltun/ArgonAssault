using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("General Set Up Settings")]
    [SerializeField] private float SpeedForce = 10f;
    [Tooltip("Our Ships camera rangeX")]
    [SerializeField] private float rangeX = 10f;
    [Tooltip("Our Ships camera rangeY")]
    [SerializeField] private float rangeY = 7f;
    float xThrow;
    float yThrow;
    [Header("Screen Position based tuning")]
    [SerializeField] float positionPitchFactor = -4f;
    [SerializeField] float positionYawFactor = 4f;
    [Header("Screen Input based tuning")]
    [SerializeField] float pitchToControl = -10f;
    [SerializeField] float rollToControl = -20f;
    [SerializeField] GameObject[] lasers;
    void Update()
    {
        ProcessToMove();
        ProcessToRotate();
        ProcessToFiring();
    }

    private void ProcessToFiring()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SetActivatelasers(true);
        }
        else
        {
            SetActivatelasers(false);
        }
    }
    private void ProcessToRotate()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yThrow * pitchToControl;
        float Pitch = pitchDueToPosition + pitchDueToControl;
        float Yaw = transform.localPosition.x * positionYawFactor;
        float Roll = xThrow * rollToControl;
        transform.localRotation = Quaternion.Euler(Pitch, Yaw, Roll);
    }
    private void ProcessToMove()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * SpeedForce;
        float newXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(newXPos, -rangeX, rangeX);

        float yOffset = yThrow * Time.deltaTime * SpeedForce;
        float newYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(newYPos, -rangeY, rangeY);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private void SetActivatelasers(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var EmissionMode = laser.GetComponent<ParticleSystem>().emission;
            EmissionMode.enabled = isActive;
        }
    }

}
