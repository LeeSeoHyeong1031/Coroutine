using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BuiltInClasses : MonoBehaviour
{
	//유니티 엔진에서 제공하는 라이브러리에 내장된 클래스를 활용.
	//Debug : 디버깅에 사용되는 기능을 제공하는 클래스.
	void Start()
	{
		//Debug.Log("Log");
		//Debug.LogWarning("");
		//Debug.LogError("");
		//Debug.LogFormat("{0}, {1}", 1, 2);//XXFormat으로 끝나는 함수들 : 파라미터를 포맷에 따라 치환하는 문자열 ex) printf
		//Debug.DrawLine(Vector3.zero, new Vector3(0, 3), Color.magenta, 5f);

		//Mathf : UnityEngine에서 제공하는 다양한 수학 연산 함수가 포함된 클래스.
		//Mathf.Abs : 절대값을 반환.
		//float a = -0.3f;
		//a = Mathf.Abs(a);
		//print(a);
		//a = Mathf.Abs(+0.3f);
		//print(a);
		//Debug.DrawRay(Vector3.right, Vector3.up * 2, Color.red,5f);
		//Debug.DrawLine(new Vector3(1, 0, 0), new Vector3(1, 2, 0), Color.green,5f);

		////Mathf.Approximately : 실수의 근사값 비교. 정확히 같은지를 검사할 수 없으므로.
		//print(Mathf.Approximately(1.1f + 0.1f,1.2f));
		//print(Mathf.Approximately(0.1f, 0.1f));

		//Mathf.Lerp : 선형 보간([L]inear Int[erp]olation) :
		////a값과 b 값 사이의 t의 비율만큼에 위치하는 값.(0<t<1)
		//print(Mathf.Lerp(-1f, 1f, 0.5f));
		////Lerp(선형 보간)함수는 Color, Vector(2,3,4), Material, Quaternion 등의 클래스에도 존재함.
		//Mathf.InverseLerp(0,0,0); //Lerp의 a, b 파라미터가 반대

		//Mathf.Ceil, Floor, Round : 올림, 내림, 반올림
		float value = 5.1f;
		float ceil = Mathf.Ceil(value);
		float floor = Mathf.Floor(value);
		float round = Mathf.Round(value);
		print($"Ceil :{ceil} Floor :{Mathf.Floor(floor)} Round :{round}");

		print(Mathf.Sign(-10f)); //부호  결과 :1
		print(Mathf.Sign(10f)); //부호  결과 :-1
		print(Mathf.Sin(60f));//삼각함수(사인)
		print(Mathf.Pow(2, 4)); //제곱  결과 :16

		//Random : 난수를 생성하는 클래스.
		//int를 반환하는 Range 함수는 최대값은 제외하고 반환
		int  intRandom = Random.Range(-1, 1); //-1, 0
		//float를 반환하는 Range 함수는 최대값과 같다고 간주되는 값이 반환될 수도 있음.
		float floatRandom = Random.Range(-1f, 1f); //-1f~1f

		float randomValue = Random.value; // == Random.Range(0f,1f); 백분율 확률을 편하게 얻기 위함.

		//Vector3 randomPosition = new Vector3(Random.value * 5f, Random.value * 5f, Random.value * 5f);
		Vector3 randomPosition = Random.insideUnitSphere;
		//Vector3(-1~1,-1~1,-1~1);
		//구체안에서 랜덤한 Vector3값을 리턴함
		print(randomPosition);

		Vector3 randomDirection = Random.onUnitSphere;
		//랜덤한 Vector3가 오는데, 길이가 항상 1. 구체에서 겉 표면(Point)에
		//랜덤한 지점에 Vector3값을 리턴함
		print(randomDirection);

		Vector2 randomPosition2D = Random.insideUnitCircle;
		//2D용 Random Vector

		//Random.rotation;
		Random.InitState(11234);//난수의 시드값 초기화.
		//연산 부하가 많이 걸리는 함수이므로, 제한적으로(씬 로드 초기때쯤에나) 사용할 것.


	}

    //Gizmo : Scene창에서만 볼 수 있는 "기즈모"를 그리는 클래스.(Debug.DrawXX의 확장 기능처럼)

    private void Update()
    {
        Gizmos.DrawCube(Vector3.zero, Vector3.one);//<<--의미 없음
    }
	//Gizmo 클래스는 OnDrawGizmos, OnDrawGizmosSelected, OnSceneGUI등 Scene창과 에디터에서만
	//활성화 되는 메시지 함수에서만 유요하게 기능함.
    private void OnDrawGizmos()
    {
		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(Vector3.zero, Mathf.PI);
    }
    private void OnDrawGizmosSelected()
    {
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(Vector3.one, 0.5f);
    }
}
