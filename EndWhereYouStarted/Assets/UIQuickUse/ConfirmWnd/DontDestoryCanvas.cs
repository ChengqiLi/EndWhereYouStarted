using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoryCanvas : MonoBehaviour
{

    private static bool origional = true; //��¼�Ƿ���ԭ����һ�γ���������
    private void Awake()
    {
        //ע�⣺��δ���Ҫ�����Awake�е���ǰ�棬��Ȼ����ʵʱ�ġ�
        //������л����������ɵģ�����
        if (origional == false)
        {
            Destroy(gameObject);
            return;
        }
        origional = false;
        // �������л���ʱ��, ������ĳ������
        DontDestroyOnLoad(gameObject);
    }
}
