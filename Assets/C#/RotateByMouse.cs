using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByMouse : MonoBehaviour
{
    public float rotateSpeedX=50,rotateSpeedY=50;//旋转XY
    public Camera curCamera;
    private float accelerate = 0.5f;
    private float hRotateSpeed = 50f;
    private Vector2 hRotateSpeedRange = new Vector2(20f, 1000f);
    private float hPressTime = 0;
    private float vRotateSpeed = 15f;
    private Vector2 vRotateSpeedRange = new Vector2(15f, 1000f);
    private float vPressTime = 0;
    private Quaternion targetRotation;
    private float hangle;
    private float vangle;
    //private float hPressTime = 0;
    private bool hrotateInteria;
    private bool vrotateInteria;
    public float moveSpeed = 0.5f;
    private Rigidbody rig;
    void RotateDir(int hdir)
    {
        //计算要旋转到的目标
        //加速度
        
        
        // if (hPressTime <= 1f)
        // {
        //     hPressTime += Time.deltaTime;
        // }
        
        // if (hRotateSpeed <= hRotateSpeedRange.y)
        // {
        //     hPressTime += Time.deltaTime;
        //     hRotateSpeed += 40f * hPressTime;
        //     Debug.Log(hPressTime.ToString());
        // }

        hPressTime += Time.deltaTime;

        if (hPressTime <= 0.3f)
        {
            hRotateSpeed += 20f * hPressTime;
        }else if (hPressTime <= 0.6f)
        {
            if (hRotateSpeed >= hRotateSpeedRange.x)
            {
                hRotateSpeed -= 30f * hPressTime;
            }
        }
        
        hangle = hRotateSpeed * Time.deltaTime * hdir;
        
        if (hangle >= 180f)
        {
            hangle -= 360f;
        }
        
        if (hangle <= -180f)
        {
            hangle += 360f;
        }
        
        Quaternion newRotation = Quaternion.Euler(new Vector3(0, hangle, 0));
        targetRotation = transform.rotation * newRotation;
        
    }
    
    void VRotateDir(int vdir)
    {
        //计算要旋转到的目标
        //加速度
        
        vPressTime += Time.deltaTime;

        if (vPressTime <= 0.4f)
        {
            if (vRotateSpeed <= vRotateSpeedRange.y)
            {
                vRotateSpeed += 5f * vPressTime;
            }
           
        }else if (vPressTime <= 0.6f)
        {
            if (vRotateSpeed >= vRotateSpeedRange.x)
            {
                vRotateSpeed -= 5f * vPressTime;
            }
        }
        
        vangle = vRotateSpeed * Time.deltaTime * vdir;
        
        if (vangle >= 180f)
        {
            vangle -= 360f;
        }
        
        if (vangle <= -180f)
        {
            vangle += 360f;
        }
        
        Quaternion newRotation = Quaternion.Euler(new Vector3(vangle, 0, 0));
        targetRotation = transform.rotation * newRotation;
        
    }
    void hRotateInteria()
    {
        // hPressTime -= Time.deltaTime;
        // if (hPressTime <= 0)
        // {
        //     hrotateInteria = false;
        // }
        //
        // if (hangle < 0)
        // {
        //     hangle = -hRotateSpeed * Time.deltaTime * hPressTime;
        // }
        //
        // if (hangle > 0)
        // {
        //     hangle = hRotateSpeed * Time.deltaTime * hPressTime;
        // }
        //
        // targetRotation = Quaternion.Euler(new Vector3(0, hangle, 0));
        // targetRotation *= transform.rotation;
    }

    void vRotateInteria()
    {
        // vPressTime -= Time.deltaTime;
        // if (vPressTime <= 0)
        // {
        //     vrotateInteria = false;
        // }
        //
        // if (vangle < 0)
        // {
        //     vangle = -vRotateSpeed * Time.deltaTime * hPressTime;
        // }
        //
        // if (vangle > 0)
        // {
        //     vangle = vRotateSpeed * Time.deltaTime * hPressTime;
        // }
    }
    void RotateMouse()
    {
        //transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, hAccelerate * Time.deltaTime);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, accelerate);
    }
    
    public Vector2 cameraRotateRange=new Vector2(-40,60);
    float curAngle = 0;
    public float getCurAngle
    {
        get
        {
            return curAngle;
        }
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {

        //判断鼠标是否显示
        //if (Cursor.visible)
        //{
        //    return;
        //}
        //获取鼠标旋转
        //float x = Input.GetAxis("Mouse X");
        //float y = Input.GetAxis("Mouse Y");
        //transform.Rotate(0,x*rotateSpeedX*Time.deltaTime,0);
        //curCamera.transform.Rotate(-y* rotateSpeedY, 0,0);
        //Vector3 cameraRotate = curCamera.transform.localRotation.eulerAngles;
        //if (cameraRotate.x > 180)
        //{
        //    cameraRotate.x -= 360;
        //}
        //else if (cameraRotate.x < -180)

        //{
        //    cameraRotate.x += 360;
        //}
        // Debug.Log("旋转前"+cameraRotate.x);
        //cameraRotate.x += -y * rotateSpeedY*Time.deltaTime;
        //Debug.Log("旋转后"+cameraRotate.x);
        //cameraRotate.x = Mathf.Clamp(cameraRotate.x, cameraRotateRange.x, cameraRotateRange.y);
        //Debug.Log("控制后" + cameraRotate.x);
        //curAngle = cameraRotate.x;
        //curCamera.transform.localRotation = Quaternion.Euler(cameraRotate);
        
        #region Alex
        
        //The fish automatically move forward
        rig.velocity = transform.forward * moveSpeed;
        
        //左右旋转
        if (Input.GetKey(KeyCode.A))
        {
            //call the clicker to turn left
            RotateDir(-1);
        }else if (Input.GetKey(KeyCode.D))
        {
            //call the clicker to turn right
            RotateDir(1);
        }

        if (Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D))
        {
            hPressTime = 0;
            hRotateSpeed = hRotateSpeedRange.x;
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            //move the player's position
            //SetUpOrDown(1);
            //rotate the camera's angle
            VRotateDir(-1);
            
        }else if (Input.GetKey(KeyCode.S))
        {
            //SetUpOrDown(-1);
            VRotateDir(1);
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            vPressTime = 0;
            vRotateSpeed = vRotateSpeedRange.x + 5F;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 10f;
        }
        else
        {
            moveSpeed = 2f;}
        
        RotateMouse();
        
        
        #endregion
    }
}
