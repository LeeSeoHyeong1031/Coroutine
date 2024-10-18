using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TransformControlTest : MonoBehaviour
{
    public Transform target;

    //기본적으로 Transform의 position, rotation, localScale 프로퍼티를 통해
    //해당 오브젝트의 위치, 각도, 크기등을 제어 할 수 있다.
    private void Start()
    {
        //ControlStraightly();
        //ControlByDirection();
        //ControlByMethod();
    }

    //값을 직접 대입하여 Transfrom을 제어
    private void ControlStraightly()
    {
        transform.position = new Vector3(3, 2, 1);
        //transform.rotation = new Quaternion(0.3f, 0.02f, 0.001f, 0);
        transform.rotation = Quaternion.Euler(30,20,10);
        print(transform.rotation);
        transform.localScale = new Vector3(4, 5, 6);
    }
    //방향(좌,우,상,하,전,후)에 방향벡터를 대입하여 Rotation제어
    private void ControlByDirection()
    {
        Vector3 lookDir = target.position - transform.position;
        //내 위치에서 target 위치로 이동하기 위해 향해야 하는 방향 벡터를 구함.
        transform.up = target.position - transform.position; //해당 방향이 나의 up이 됨.

        //해당 방향이 나의 right가 되려면?
        //transform.right = lookDir;

        //해당 방향이 나의 foward가 되려면?
        //transform.forward = lookDir;

        //해당 방향이 나의 down이 되려면?
        //transform.up = -lookDir;
        //해당 방향이 나의 left이 되려면?
        //transform.right = -lookDir;
        //해당 방향이 나의 backward이 되려면?
        transform.forward = -lookDir;
    }
    //Transfrom의 제어 함수를 호출
    private void ControlByMethod()
    {
        //Translate : 내 현재 위치에서 Position을 제어하는 함수
        transform.Translate(5, 0, 0);
        //Rotate : 내 현재 각도에서 Rotation을 제어하는 함수
        transform.Rotate(30, 0, 0);

        //Translate, Rotate 함수를 사용하여 제어하는 것은
        //translate.position, rotation에 값을 직접 할당하는 것과 비교하면
        //현재 position, rotation 기준으로 상대적인 연산이 이루어지는 것이다.
    }

    private void Update()
    {
        //transform.position = (transform.position + new Vector3(3,2,1)) * Time.deltaTime;
        //transform.rotation = (Quaternion.Euler(transform.rotation.eulerAngles + new Vector3
        //    (30,20,10)*Time.deltaTime));

        transform.Translate(new Vector3(3,2,1)*Time.deltaTime);
        transform.Rotate(new Vector3(30,20,10)*Time.deltaTime);
    }
}
