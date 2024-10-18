using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CoroutineSamples : MonoBehaviour
{
    int cnt = 0;
    void Start()
    {
        //StartCoroutine(ReturnNull());
        //============================
        //������������
        //for (int i = 0; i < 10000; i++)
        //{
        //    print(cnt);
        //}
        //���� �������� ������ �� �������� �ٽ� ReturnNull�� ���� ��.
        //���� ���� �ֱⰡ ������ ���⼭ �ٽ� ������.
        //============================

        //StartCoroutine(ReturnWaitForSeconds(2f,5));
        //StartCoroutine(ReturnWaitForSecondsRealtime(2f,5));

        //StartCoroutine(ReturnUntilWhile());
        //StartCoroutine(ReturnFrames());

        StartCoroutine(_1st());

        //StartCoroutine�� ȣ���� �ϸ� �ڷ�ƾ�� �ڵ鸵�ϴ� ��ü�� �� �ڽ��� �ǹǷ�
        //�� ���� ������Ʈ�� ��Ȱ��ȭ �ǰų� Component�� ��Ȱ��ȭ �Ǹ�
        //���� StartCoroutine�� ���� ������ ��� �ڷ�ƾ�� ������ ����.

    }
    //yeild return null : �� �����Ӹ��� ���� yield return�� ��ȯ
    private IEnumerator ReturnNull()
    {
        print("Return Null �ڷ�ƾ�� ���۵Ǿ����ϴ�.");
        while (true)
        {
            yield return null;
            print($"Return null �ڷ�ƾ�� ����Ǿ����ϴ�.{Time.time}");
        }
    }
    //yield return new WaitForSeconds(param) :
    //�ڷ�ƾ�� yield return Ű���带 ������ �Ķ���͸�ŭ ��� �� ����.
    private IEnumerator ReturnWaitForSeconds(float interval, int count)
    {
        print("Return Wait For Seconds �ڷ�ƾ�� ���۵Ǿ����ϴ�.");
        for (int i = 0; i< count; i++)
        {
            yield return new WaitForSeconds(interval);
            print($"ReturnWaitForSeconds {i+1}�� ȣ���. {Time.time}");
        }
        print($"Return Wait For Seconds �ڷ�ƾ�� �������ϴ�.");
    }
    //yield return new WaitForSecondsRealtime(param) :
    //WaitForSeconds�� ������ ������ TimeScale�� ���� ���� �ʴ´�.
    private IEnumerator ReturnWaitForSecondsRealtime(float interval, int count)
    {
        print("Return Wait For Seconds Realtime �ڷ�ƾ�� ���۵Ǿ����ϴ�.");
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSecondsRealtime(interval);
            print($"ReturnWaitForSecondsRealtime {i + 1}�� ȣ���. {Time.time}");
        }
        print($"Return Wait For Seconds Realtime �ڷ�ƾ�� �������ϴ�.");
    }

    public bool continueKey;

    private bool IsContinue()
    {
        return continueKey;
    }

    //yield return new WaitUntil / WaitWhile (param): Ư�� ������ True/False�� �� ������ ���
    private IEnumerator ReturnUntilWhile()
    {
        print("Return Until While �ڷ�ƾ �����");
        while (true)
        {
            //new WaitUntil : �Ű������� �Ѿ �Լ�(�븮��)�� return�� false�� ���� ���, true�� �Ѿ
            yield return new WaitUntil(()=>continueKey);
            print("��Ƽ�� Ű�� ����");
            //new WaitWhile : �Ű������� �Ѿ �Լ�(�븮��)�� return�� true�� ���� ���, false�� �Ѿ
            yield return new WaitWhile(IsContinue);
            print("��Ƽ�� Ű�� ������");
        }
    }

    //yield return new (Frame �迭) : �� ������ Ư�� ������ �ڿ� �����.
    private IEnumerator ReturnFrames()
    {
        //EndOfFrame : �ش� �������� ���� ���������� ��ٸ�.
        yield return new WaitForEndOfFrame();
        print("End of Frame");
        isFirstFrame = false;
    }

    private IEnumerator ReturnFixedUpdate()
    {
        //FixedUpdate : ���������� ���� ������ ��ٸ�.
        yield return new WaitForFixedUpdate();
    }

    bool isFirstFrame = true;

    private void Update()
    {
        //if (isFirstFrame)
        //{
        //    print("Update �޽��� �Լ� ȣ��");
        //}
        //for (int i = 0; i < 100; i++)
        //{
        //    print(i);
        //}
    }
    //private void LateUpdate()
    //{
    //    if (isFirstFrame)
    //    {
    //        print("LateUpdate �޽��� �Լ� ȣ��");
    //    }
    //}

    //yield return �ڷ�ƾ : �ش� �ڷ�ƾ�� ���������� ���.
    private IEnumerator _1st()
    {
        print("1��° �ڷ�ƾ ���۵�");
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1f);
            print($"1��° �ڷ�ƾ {i + 1}��° �����");
        }
        print("1��° �ڷ�ƾ�� 2��° �ڷ�ƾ�� �����ϰ� �����");
        yield return StartCoroutine(_2nd());
        print("1��° �ڷ�ƾ ����.");
    }

    Coroutine _3rdCoroutine;
    private IEnumerator _2nd()
    {
        print("2��° �ڷ�ƾ ���۵�");
        print("2��° �ڷ�ƾ�� 3��° �ڷ�ƾ�� �����ϰ� �����");
        _3rdCoroutine =  StartCoroutine(_3nd());
        yield return _3rdCoroutine;
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1f);
            print($"2��° �ڷ�ƾ {i + 1}��° �����");
        }
        print("2��° �ڷ�ƾ ����.");
    }
    private IEnumerator _3nd()
    {
        print("3��° �ڷ�ƾ ���۵�.");
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1f);
            print($"3��° �ڷ�ƾ {i + 1}��° �����");
        }
        print("3��° �ڷ�ƾ ����.");
    }
}
