 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class player : MonoBehaviour
{
    [SerializeField] float xSpeed = 4f;

    [SerializeField] float xMax = 5f;

    [SerializeField] float yMax = 2f;

    [SerializeField] float pitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -25f;

    [SerializeField] float YawlFactor = 5f;
    [SerializeField] float controlRollFactor = -25f;



    float xThrow = 0f;
    float yThrow = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        rotation();
    }

    private void rotation()
    {
        float pitch =0f;
        float yawl = 0f;
        float roll = 0f;

        pitch = transform.localPosition.y * pitchFactor + yThrow*controlPitchFactor;

        yawl = transform.localPosition.y * YawlFactor;

        roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch,yawl,roll) ;
    } 
    private void movement()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xSpeed * xThrow * Time.deltaTime;
        float xRaw = xOffset + transform.localPosition.x;
        float xClamp = Mathf.Clamp(xRaw, -xMax, xMax);
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = xSpeed * yThrow * Time.deltaTime;
        float yRaw = yOffset + transform.localPosition.y;
        float yClamp = Mathf.Clamp(yRaw, -yMax, yMax);
        transform.localPosition = new Vector3(xClamp, yClamp, transform.localPosition.z);
    }
}
