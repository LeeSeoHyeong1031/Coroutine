using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformTest: MonoBehaviour
{
    //Transform : ���� ��ü�� ���� ��� GameObject���� ������ 1���� Transform�� ����

    public GameObject yourObject;
    public Transform parent;

    public Transform grandParent;

    private void Start()
    {
        //��� GameObject, Component Ŭ������ transfrom�̶�� ������Ƽ��
        //�ش� ��ü�� Transform ������Ʈ�� ��ȯ.

        string someChildsName = parent.Find("ThirdChild").GetChild(0).name;
        print(someChildsName);

        parent.SetParent(grandParent,false);
        //parent.parent = grandParent; //=> �Ȱ��� ���� �ϳ�, �Ϲ������� SetParent �Լ��� ȣ����.

    }
}
