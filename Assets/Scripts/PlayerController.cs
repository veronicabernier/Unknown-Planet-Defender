using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEditor.UIElements;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float xControlSpeed = 15f;
    [Tooltip("In ms^-1")] [SerializeField] float yControlSpeed = 15f;
    [Tooltip("In m")] [SerializeField] float xRange = 5f;
    [Tooltip("In m")] [SerializeField] float yMinRange = -3f;
    [Tooltip("In m")] [SerializeField] float yMaxRange = 3f;

    [Header("Sceen-position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;

    [Header("Control-throw Based")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;


    float xThrow, yThrow;
    bool isControlEnabled = true;

    // Update is called once per frame
    void Update()
    {
        if(!isControlEnabled) { return; }
        ApplyThrowMovement();
        ApplyRotation();
    }

    //called by String message in CollisionHandler
    void OnPlayerDeath()
    {
        isControlEnabled = false;
    }

    private void ApplyThrowMovement()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xControlSpeed * Time.deltaTime; //in frame, if delta(the change) is longer, we need to move further
        float rawNewXPos = transform.localPosition.x + xOffset;

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * yControlSpeed * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;

        transform.localPosition = new Vector3(Mathf.Clamp(rawNewXPos, -xRange, xRange),
            Mathf.Clamp(rawNewYPos, yMinRange, yMaxRange), transform.localPosition.z); //dont change z
    }

    private void ApplyRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor; //due to position
        float roll = xThrow  * controlRollFactor; //due to control
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
