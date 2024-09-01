using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// �����������Խű�
/// </summary>
public class ShowGuideMono : MonoBehaviour 
{
    void Start(){
        //StartCoroutine("ok");
        //����ĳ��UI�ϵ��������ݼ��뵽����Mgr
        var guideDataList = transform.GetComponentInChildren<UIBeginnerGuideDataList>();
        UIBeginnerGuideManager.Instance.AddGuideList(guideDataList);
        //��ʼ������������ӵ�һ����ʼ����
        UIBeginnerGuideManager.Instance.ShowGuideList();
    }
    
    IEnumerator ok(){
        yield return new WaitForSeconds(0.5f);
        //UIBeginnerGuideManager.Instance.SetGuideID("MiddleGuide");
        UIBeginnerGuideManager.Instance.ShowGuideList();
    }
}