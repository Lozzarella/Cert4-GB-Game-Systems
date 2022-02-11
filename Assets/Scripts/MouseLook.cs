using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script can be found in the Component section under the option PRG/Mouse Look
[AddComponentMenu("RPG Game/Character/Mouse Look")]
public class MouseLook : MonoBehaviour
{
    /*
     enums are what we call state value variables
    they are comma separated lists of identifiers
    we can use them to create Types or Categorys
     */

    public enum RotationalAxis
    {
        MouseX,
        MouseY,
    }
    #region Variables
    [Header("Rotation")]
    public RotationalAxis axis;
    [Header("Sensitivity")]
    [Range(0, 500)]
    public float sensitivity = 100f;
    [Header("Rotation Clamp")]
    public float minY = -60f;
    public float maxY = 60f;
    private float m_rotY;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //Lock Cursor to middle of screen
        Cursor.lockState = CursorLockMode.Locked;
        //Hide Cursor from view
        Cursor.visible = false;
        //if our game object has a rigidbody attached to it
        if(GetComponent<Rigidbody>())
        {
            //set the rigidbodys freezRotation to true
            GetComponent<Rigidbody>().freezeRotation = true;
        }
        //if the object is the camera 
        if (GetComponent<Camera>())
        {
            //we can now look up and down
            axis = RotationalAxis.MouseY;
        }
    }

    // Update is called once per frame
    void Update()
    {
        #region Mouse X
        //if we are rotating on the X
        if (axis == RotationalAxis.MouseX)
        {
            //transform the rotation on our game objects Y by our Mouse input Mouse X times X sensitivity
                           //x   y                           z
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity /** Time.deltaTime*/, 0);
        }

        #endregion
        #region Mouse Y
             //else we are only rotation on the Y
        else
        {

        //our rotation Y is pulse equals our mouse input for Mouse Y times Y sensitivity
        m_rotY += Input.GetAxis("Mouse Y") * sensitivity/**Time.deltaTime*/;
        //the rotation Y is clamped using Mathf and we are clamping the y rotation to the Y min and Y max
        m_rotY = Mathf.Clamp(m_rotY,minY,maxY);
        //transform our local position to the nex vector3 rotaion - y rotaion on the x axis and local euler angle Y on the y axis
         transform.localEulerAngles = new Vector3(-m_rotY, 0, 0);
        }

        #endregion
    }
}