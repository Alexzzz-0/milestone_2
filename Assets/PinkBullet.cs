using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkBullet : BulletBase
{
    bool isDie = false;
    private void OnTriggerEnter(Collider other)
    {
        if (isDie)
        {
            return;
        }
        if (true)
        {

        }
      //  isDie = true;
      /*
        //�������� ɱ������ ��ʧ 
        if (other.GetComponent<RedFish>())
        {
            Debug.Log("Ŀ���Ǻ���");
            isDie = true;
            Destroy(this.gameObject);
            other.GetComponent<RedFish>().DeleteThis();
            // Update is called once per frame

            //���Ŵ�
            GameController.Instance.player.AddScale();
        }
        
        else if (other.GetComponent<HaiCaoSC>())
        {
            Debug.Log("Ŀ����ˮ��");
            
            isDie = true;
            Destroy(this.gameObject);
            GameController.Instance.player.SetFishDie();
            
        }
    
        */
    }
}
