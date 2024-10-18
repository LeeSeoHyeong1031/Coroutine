using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CoroutineStarter : MonoBehaviour
{
    //StartCoroutine�� ȣ���� �ϸ� �ڷ�ƾ�� �ڵ鸵�ϴ� ��ü�� �� �ڽ��� �ǹǷ�
    //�� ���� ������Ʈ�� ��Ȱ��ȭ �ǰų� Component�� ��Ȱ��ȭ �Ǹ�
    //���� StartCoroutine�� ���� ������ ��� �ڷ�ƾ�� ������ ����.


    //���� �ٰ� + �� ����
    //Ÿ���� ū �ڷ�ƾ(������)�� ����Ǵϱ� ���� Ŭ������ ������Ʈ�� �׾(������)
    //������ ��.

    public NewBehaviourScript target;
    void Start()
    {
        target.StartCoroutine(DamageOnTime());
        
    }

    private IEnumerator DamageOnTime()
    {
        print($"{name}�� {target.name}���� ��Ʈ �������� �־����ϴ�.");

        for(int i = 0; i<10; i++)
        {
            yield return new WaitForSeconds(1f);
            print($"{target.name}: �ƾ�!x{i}");
        }
    }
}
