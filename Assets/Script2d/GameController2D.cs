using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController2D : MonoBehaviour
{
    public enum HunZhuo
    {
        ��,
        ��,
        ��
    }
    public void SetHunZhuo(HunZhuo hunzhuo)
    {
        switch (hunzhuo)
        {
            case HunZhuo.��:
                {
                    player.actionPower = 1;
                }
                break;
            case HunZhuo.��:
                {
                    player.actionPower = 0.5f;
                }
                break;
            case HunZhuo.��:
                {
                    player.actionPower = 0;
                }
                break;
            default:
                break;
        }
    }
    static GameController2D _instance;
    public static GameController2D Instance
    {
        get
        {
            if (_instance==null)
            {
                _instance = FindObjectOfType<GameController2D>();
            }
            return _instance;
        }
    }
    public Player2DMove player;
    public Camera gameCamera;
    public Camera uiCamera;
    public Transform mouseMove;
    //ѹ����
    public PressurePercent pressurePercent;

    // Start is called before the first frame update
    void Start()
    {
        //Ĭ�ϲ���ʾ��� �������������
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        MouseRefeshPos();
    }
    void MouseRefeshPos()
    {
        //��ָ�����λ��
        Vector3 touchPos = Input.mousePosition;
        //Vector3 worldPos= gameCamera.ScreenToWorldPoint(touchPos);
        Vector3 uiPos = uiCamera.ScreenToWorldPoint(touchPos);
        uiPos.z = mouseMove.transform.position.z;
        mouseMove.transform.position = uiPos;
    }
    // Update is called once per frame
    void Update()
    {
        //����Ұ���

        MouseRefeshPos();


    }
}
