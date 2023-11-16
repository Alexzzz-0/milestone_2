using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DMove : MonoBehaviour
{

    Rigidbody2D rig;
    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    //�ƶ�
    public float moveSpeed = 10;
    int thisMoveDir;
    public void SetDirMove(int dir)
    {
        thisMoveDir = dir;
        rig.velocity = transform.forward * dir * moveSpeed * actionPower;
    }
    public float actionPower = 1;
    //��ת
    public float rotateSpeed = 10;
    float rotatePower = 0;
    public void SetRotate(int power)
    {
        rotatePower = power;
    }
    //�������½�
    public float upSpeed = 10;



    //��ѹ��ѹ
    public float curPressure = 0.5f;
    public float addPressurePercentSpeed_Move = 0.5f;
    public float addPressurePercentSpeed_Touch = 0.7f;
    //�����ѹ��ѹ
    public void AddZengYa(float power)
    {
        curPressure += power;
        if (curPressure > 1)
        {
            curPressure = 1;

        }
        if (curPressure < 0)
        {
            curPressure = 0;

        }
        GameController2D.Instance.pressurePercent.SetValue(curPressure);
    }
    // Start is called before the first frame update
    void Start()
    {
        GameController2D.Instance.pressurePercent.SetValue(curPressure);
    }
    public TouchMoveBangDingPlayer touchBall = null;
    public LayerMask ballMask;
    public float thisDistance = 100;
    bool isTouchBall = false;
    // Update is called once per frame
    void Update()
    {


        rig.velocity = transform.forward * thisMoveDir * moveSpeed * actionPower;

        //��ת
        transform.Rotate(Vector3.back * rotatePower * Time.deltaTime * rotateSpeed * actionPower);
        //�����½�
        float v = Input.GetAxis("Vertical");
        transform.position += Vector3.up * upSpeed * Time.deltaTime * v * actionPower;
        //ѹ��ֵ����
        if (v != 0)
        {
            //����ѹ��ֵ
            curPressure += addPressurePercentSpeed_Move * v * Time.deltaTime;

            if (curPressure > 1)
            {
                curPressure = 1;

            }
            if (curPressure < 0)
            {
                curPressure = 0;

            }
            //�ֶ���ѹ��ѹ
            if (Input.GetKey(KeyCode.Mouse0))
            {
                AddZengYa(addPressurePercentSpeed_Touch * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Mouse1))
            {
                AddZengYa(-addPressurePercentSpeed_Touch * Time.deltaTime);
            }
        }
        else
        {
            //�Զ��ظ�ƽ��ֵ
            // curPressure = 0.5f;
        }



        GameController2D.Instance.pressurePercent.SetValue(curPressure);

        {
            //����������� �Ϳ�����קС��
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                var ray = GameController2D.Instance.gameCamera.ScreenPointToRay(Input.mousePosition);
                //�������� ���С��
                RaycastHit hit;
                bool isRay = Physics.Raycast(ray, out hit, 2000, ballMask);
                if (isRay)
                {

                    thisDistance = hit.distance;
                    Debug.Log("���߼�⵽��" + hit.transform.name + hit.distance);
                    isTouchBall = true;
                    touchBall = hit.transform.GetComponent<TouchMoveBangDingPlayer>();
                }
            }
            if (isTouchBall)
            {
                var ray = GameController2D.Instance.gameCamera.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;
                bool isRay = Physics.Raycast(ray, out hit, thisDistance, ballMask);
                touchBall.transform.position = ray.origin + thisDistance * ray.direction;
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                touchBall = null;
                isTouchBall = false;
            }

        }

    }
}
