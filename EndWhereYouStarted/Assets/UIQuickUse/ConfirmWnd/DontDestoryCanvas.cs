using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoryCanvas : MonoBehaviour
{

    private static bool origional = true; //记录是否是原来第一次场景的物体
    private void Awake()
    {
        //注意：这段代码要求放在Awake中的最前面，不然不是实时的。
        //如果是切换场景新生成的，销毁
        if (origional == false)
        {
            Destroy(gameObject);
            return;
        }
        origional = false;
        // 当场景切换的时候, 不销毁某个对象
        DontDestroyOnLoad(gameObject);
    }
}
