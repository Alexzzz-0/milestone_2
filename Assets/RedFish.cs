using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFish : FishBase
{
    public enum RedFishState
    {

        EnterHaiCao,
        MoveToBlackFish
    }
    RedFishState redFishState = RedFishState.EnterHaiCao;

    HaiCaoSC targetHaiCao;
    void FindHaiCao()
    {
        List<HaiCaoSC> haicaoList = new List<HaiCaoSC>();
        for (int i = 0; i < GameController.Instance.haicaoParent.childCount; i++)
        {
            var haicao = GameController.Instance.haicaoParent.GetChild(i).GetComponent<HaiCaoSC>();
            if (haicao.isDie)
            {
                continue;
            }
            haicaoList.Add(haicao);
        }
        var array = haicaoList.ToArray(); System.Array.Sort(array, (a, b) => Vector3.Distance(a.enterPos.position, transform.position).CompareTo(Vector3.Distance(b.enterPos.position, transform.position)));
        if (array.Length > 0)
        {
            targetHaiCao = array[0];
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<RedFish>())
        {
            var redFish=other.transform.GetComponent<RedFish>();
           // Debug.Log("����");
            if (scaleSize>=redFish.scaleSize)
            {
                Vector3 targetForceDir = (other.transform.position - transform.position).normalized;
                other.transform.GetComponent<Rigidbody>().AddForce(targetForceDir * tankai_power);
            }
        
            //Vector3 thisForceDir = -targetForceDir;
            //rig.AddForce(thisForceDir * tankai_power);
        }
    }
    HaiCaoCircle targetHaiCaoCircle;
    protected override void OnEnable()
    {
        if (transform.GetComponentInParent<HaiCaoCircle>())
        {
            targetHaiCaoCircle = transform.GetComponentInParent<HaiCaoCircle>();
            GetRandomMove();
        }
   
        base.OnEnable();
     
    }
    public float findBlackRange = 100;
    BlackFish trackblackFish;

    public static float tankai_power = 2000;
   
    public float DownScaleTime_NoEatFish = 10;
    float downScaleTimer_NoEatFish = 0;
    public void RefeshScaleTimer_NoEatFish()
    {
        downScaleTimer_NoEatFish = 0;
    }
    public float minMoveDistance = 2;
    Vector3 targetMovePos;
    public void GetRandomMove()
    {
        List<Vector3> posList = new List<Vector3>();
        Vector3[] poses=targetHaiCaoCircle.GetRedFishPos();
        foreach (var pos in poses)
        {
            if (Vector3.Distance(transform.position,pos)> minMoveDistance)
            {
                posList.Add(pos);
            }
        }
        //Debug.Log(posList.Count);
        targetMovePos = posList[Random.Range(0,posList.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeedT = moveSpeed * GameController.Instance.RedMoveSpeedPower;
        /*
        switch (redFishState)
        {
            case RedFishState.EnterHaiCao:
                {
                    if (targetHaiCao == null)
                    {
                        FindHaiCao();
                        break;
                    }
                    if (targetHaiCao.isDie)
                    {
                        FindHaiCao();
                        break;
                    }
                   

                    //��ˮ��
                    Vector3 endPos = targetHaiCao.enterPos.position;
                    if (Vector3.Distance(endPos,transform.position)>0)
                    {
                        float moveDistance = moveSpeedT * Time.deltaTime;
                        float distance = Vector3.Distance(transform.position, endPos);
                        float angle = Vector3.SignedAngle(Vector3.forward, endPos - transform.position, Vector3.up);
                        transform.rotation = Quaternion.Euler(0, angle, 0);
                        if (distance < moveDistance)
                        {
                            transform.position = endPos;

                        }
                        else
                        {
                            transform.position += (endPos - transform.position).normalized * moveDistance;
                        }
                    }
                    //�������к���ʱ �������
                    List<BlackFish> blackFishList = new List<BlackFish>();
                    foreach (var item in GameController.Instance.fishParent.GetComponentsInChildren<BlackFish>())
                    {
                        if (Vector3.Distance(item.transform.position,transform.position)<findBlackRange)
                        {
                            blackFishList.Add(item);
                        }
                    }
                    if (blackFishList.Count>0)
                    {
                        var array = blackFishList.ToArray();
                        System.Array.Sort(array, (a, b) => Vector3.Distance(a.transform.position, transform.position).CompareTo(Vector3.Distance(b.transform.position, transform.position)));
                        trackblackFish = array[0];
                        targetHaiCao = null;
                        redFishState= RedFishState.MoveToBlackFish;
                    }
                  
                }
                break;
            case RedFishState.MoveToBlackFish:
                {
                    //�������
                    if (trackblackFish==null)
                    {
                        redFishState=RedFishState.EnterHaiCao;
                        break;
                    }
                    //�Ժ���
                    Vector3 endPos = trackblackFish.transform.position;
                    if (Vector3.Distance(endPos, transform.position) > 0)
                    {
                        float moveDistance = moveSpeedT * Time.deltaTime;
                        float distance = Vector3.Distance(transform.position, endPos);
                        float angle = Vector3.SignedAngle(Vector3.forward, endPos - transform.position, Vector3.up);
                        transform.rotation = Quaternion.Euler(0, angle, 0);
                        if (distance < moveDistance)
                        {
                            transform.position = endPos;

                        }
                        else
                        {
                            transform.position += (endPos - transform.position).normalized * moveDistance;
                        }
                    }
                }
                break;
            default:
                break;
        }
        */
        //�����ƶ�
        //���û��Ĭ�ϵĺ���Ȧ �Զ�ʶ��һ�����
        if (targetHaiCaoCircle == null)
        {
          //  Debug.Log("Ѱ�Һ���Ȧ");
            List<HaiCaoCircle> targetcircleList = new List<HaiCaoCircle>();
            for (int i = 0; i < GameController.Instance.haicaoQuanParent.childCount; i++)
            {
                targetcircleList.Add(GameController.Instance.haicaoQuanParent.GetChild(i).GetComponent<HaiCaoCircle>());
            }
            var array = targetcircleList.ToArray();
            System.Array.Sort(array, (a, b) => Vector3.Distance(a.transform.position, transform.position).CompareTo(Vector3.Distance(b.transform.position, transform.position)));
            if (array.Length > 0)
            {
                targetHaiCaoCircle = array[0];
                //Debug.Log("�ҵ�����Ȧ��");
                GetRandomMove();
            }

        }
        else
        {
            //������˺���Ȧ �ƶ�
            Vector3 targetPos = targetMovePos;
            float distance = Vector3.Distance(transform.position,targetPos);
            float moveDistance = moveSpeedT * Time.deltaTime;
            float angle = Vector3.SignedAngle(Vector3.forward, targetPos - transform.position, Vector3.up);
            transform.rotation = Quaternion.Euler(0, angle, 0);
            if (moveDistance < distance)
            {
                //Debug.Log("�ƶ���"+distance);
                transform.position += (targetPos - transform.position).normalized * moveDistance;
            }
            else
            {
                //Debug.Log("˲�ƣ�");
                transform.position = targetMovePos;
                GetRandomMove();
            }
        }

        downScaleTimer_NoEatFish += Time.deltaTime;
        if (downScaleTimer_NoEatFish> DownScaleTime_NoEatFish)
        {
            downScaleTimer_NoEatFish = 0;
            LoseScale();
        }


    }
}
