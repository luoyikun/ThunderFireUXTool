using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ǿ����
/// </summary>
public class GuideTargetStroke : GuideWidgetBase
{
    private GameObject target;
    public GameObject square;
    public GameObject circle;
    public Button m_btnTarget = null; //Ŀ�갴ť
    UIBeginnerGuideData m_guideData;
    public override void Init(GuideWidgetData data)
    {
        GuideTargetStrokeData targetStrokeData = data as GuideTargetStrokeData;
        if (targetStrokeData != null)
        {
            targetStrokeData.ApplyTransformData(transform);
            if (targetStrokeData.targetType == TargetType.Target && target != null)
            {
                transform.position = target.transform.position;
                transform.eulerAngles = target.transform.eulerAngles;
                transform.localScale = target.transform.localScale;
                transform.GetComponent<RectTransform>().sizeDelta = target.GetComponent<RectTransform>().sizeDelta;
            }
            square.SetActive(targetStrokeData.strokeType == StrokeType.Square);
            circle.SetActive(targetStrokeData.strokeType == StrokeType.Circle);
            square.GetComponent<Animator>().enabled = targetStrokeData.playAnimator;
            circle.GetComponent<Animator>().enabled = targetStrokeData.playAnimator;
        }
    }

    public override List<int> GetControlledInstanceIds()
    {
        List<int> list = new List<int>();

        return list;
    }


    public void SetTarget(GameObject go)
    {
        BtnTargetRemoveListener();
        target = go;
        BtnTargetAddListener(go);
    }
    public override void Show()
    {
    }
    public override void Stop()
    {
    }

    void BtnTargetRemoveListener()
    {
        if (m_btnTarget != null)
        {
            m_btnTarget.onClick.RemoveListener(finish);
            Debug.Log($"�����Ƴ�Ŀ�갴ť�ص�-��{m_btnTarget.name}");
            m_btnTarget = null;
        }
    }

    void BtnTargetAddListener(GameObject go)
    {
        if (m_guideData.guideFinishType == GuideFinishType.Strong)
        {
            m_btnTarget = go.GetComponent<Button>();
            if (m_btnTarget != null)
            {
                m_btnTarget.onClick.AddListener(finish);
                Debug.Log($"ǿ������Ŀ�갴ť�ص�-��{m_btnTarget.name}");
            }
            else
            {
                Debug.LogError($"ǿ������ҪĿ�����button-��target{go.name}");
            }


        }
    }

    public void SetGuideData(UIBeginnerGuideData guideData)
    {
        m_guideData = guideData;
    }

    /// <summary>
    /// ������һ��
    /// </summary>
    public void finish()
    {
        //��Ҫ���Ƴ�target�ص��ٿ�����һ��
        BtnTargetRemoveListener();
        UIBeginnerGuideManager.Instance.FinishGuide(m_guideData.guideID);

    }
}
