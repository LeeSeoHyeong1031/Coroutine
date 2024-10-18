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
        //만번돌려보기
        //for (int i = 0; i < 10000; i++)
        //{
        //    print(cnt);
        //}
        //만번 돌려보니 만번이 다 돌려지고 다시 ReturnNull이 수행 됨.
        //이쪽 실행 주기가 끝나면 저기서 다시 수행함.
        //============================

        //StartCoroutine(ReturnWaitForSeconds(2f,5));
        //StartCoroutine(ReturnWaitForSecondsRealtime(2f,5));

        //StartCoroutine(ReturnUntilWhile());
        //StartCoroutine(ReturnFrames());

        StartCoroutine(_1st());

        //StartCoroutine을 호출을 하면 코루틴을 핸들링하는 객체가 나 자신이 되므로
        //내 게임 오브젝트가 비활성화 되거나 Component가 비활성화 되면
        //내가 StartCoroutine을 통해 생성한 모든 코루틴도 동작을 멈춤.

    }
    //yeild return null : 매 프레임마다 다음 yield return을 반환
    private IEnumerator ReturnNull()
    {
        print("Return Null 코루틴이 시작되었습니다.");
        while (true)
        {
            yield return null;
            print($"Return null 코루틴이 수행되었습니다.{Time.time}");
        }
    }
    //yield return new WaitForSeconds(param) :
    //코루틴이 yield return 키워드를 만나면 파라미터만큼 대기 후 수행.
    private IEnumerator ReturnWaitForSeconds(float interval, int count)
    {
        print("Return Wait For Seconds 코루틴이 시작되었습니다.");
        for (int i = 0; i< count; i++)
        {
            yield return new WaitForSeconds(interval);
            print($"ReturnWaitForSeconds {i+1}번 호출됨. {Time.time}");
        }
        print($"Return Wait For Seconds 코루틴이 끝났습니다.");
    }
    //yield return new WaitForSecondsRealtime(param) :
    //WaitForSeconds와 동작은 같으나 TimeScale에 영향 받지 않는다.
    private IEnumerator ReturnWaitForSecondsRealtime(float interval, int count)
    {
        print("Return Wait For Seconds Realtime 코루틴이 시작되었습니다.");
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSecondsRealtime(interval);
            print($"ReturnWaitForSecondsRealtime {i + 1}번 호출됨. {Time.time}");
        }
        print($"Return Wait For Seconds Realtime 코루틴이 끝났습니다.");
    }

    public bool continueKey;

    private bool IsContinue()
    {
        return continueKey;
    }

    //yield return new WaitUntil / WaitWhile (param): 특정 조건이 True/False가 될 때까지 대기
    private IEnumerator ReturnUntilWhile()
    {
        print("Return Until While 코루틴 시잠됨");
        while (true)
        {
            //new WaitUntil : 매개변수로 넘어간 함수(대리자)의 return이 false인 동안 대기, true면 넘어감
            yield return new WaitUntil(()=>continueKey);
            print("컨티뉴 키가 참됨");
            //new WaitWhile : 매개변수로 넘어간 함수(대리자)의 return이 true인 동안 대기, false면 넘어감
            yield return new WaitWhile(IsContinue);
            print("컨티뉴 키가 거짓됨");
        }
    }

    //yield return new (Frame 계열) : 인 게임의 특정 프레임 뒤에 수행됨.
    private IEnumerator ReturnFrames()
    {
        //EndOfFrame : 해당 프레임의 가장 마지막까지 기다림.
        yield return new WaitForEndOfFrame();
        print("End of Frame");
        isFirstFrame = false;
    }

    private IEnumerator ReturnFixedUpdate()
    {
        //FixedUpdate : 물리연산이 끝날 때까지 기다림.
        yield return new WaitForFixedUpdate();
    }

    bool isFirstFrame = true;

    private void Update()
    {
        //if (isFirstFrame)
        //{
        //    print("Update 메시지 함수 호출");
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
    //        print("LateUpdate 메시지 함수 호출");
    //    }
    //}

    //yield return 코루틴 : 해당 코루틴이 끝날때까지 대기.
    private IEnumerator _1st()
    {
        print("1번째 코루틴 시작됨");
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1f);
            print($"1번째 코루틴 {i + 1}번째 수행됨");
        }
        print("1번째 코루틴이 2번째 코루틴을 시작하고 대기함");
        yield return StartCoroutine(_2nd());
        print("1번째 코루틴 끝남.");
    }

    Coroutine _3rdCoroutine;
    private IEnumerator _2nd()
    {
        print("2번째 코루틴 시작됨");
        print("2번째 코루틴이 3번째 코루틴을 시작하고 대기함");
        _3rdCoroutine =  StartCoroutine(_3nd());
        yield return _3rdCoroutine;
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1f);
            print($"2번째 코루틴 {i + 1}번째 수행됨");
        }
        print("2번째 코루틴 끝남.");
    }
    private IEnumerator _3nd()
    {
        print("3번째 코루틴 시작됨.");
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1f);
            print($"3번째 코루틴 {i + 1}번째 수행됨");
        }
        print("3번째 코루틴 끝남.");
    }
}
