using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CoroutineStarter : MonoBehaviour
{
    //StartCoroutine을 호출을 하면 코루틴을 핸들링하는 객체가 나 자신이 되므로
    //내 게임 오브젝트가 비활성화 되거나 Component가 비활성화 되면
    //내가 StartCoroutine을 통해 생성한 모든 코루틴도 동작을 멈춤.


    //위에 근거 + 내 생각
    //타겟의 큰 코루틴(협력자)이 실행되니까 이쪽 클래스의 컴포넌트가 죽어도(꺼져도)
    //실행이 됌.

    public NewBehaviourScript target;
    void Start()
    {
        target.StartCoroutine(DamageOnTime());
        
    }

    private IEnumerator DamageOnTime()
    {
        print($"{name}이 {target.name}에게 도트 데미지를 주었습니다.");

        for(int i = 0; i<10; i++)
        {
            yield return new WaitForSeconds(1f);
            print($"{target.name}: 아야!x{i}");
        }
    }
}
