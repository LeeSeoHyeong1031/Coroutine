using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BuiltInClasses : MonoBehaviour
{
	//����Ƽ �������� �����ϴ� ���̺귯���� ����� Ŭ������ Ȱ��.
	//Debug : ����뿡 ���Ǵ� ����� �����ϴ� Ŭ����.
	void Start()
	{
		//Debug.Log("Log");
		//Debug.LogWarning("");
		//Debug.LogError("");
		//Debug.LogFormat("{0}, {1}", 1, 2);//XXFormat���� ������ �Լ��� : �Ķ���͸� ���˿� ���� ġȯ�ϴ� ���ڿ� ex) printf
		//Debug.DrawLine(Vector3.zero, new Vector3(0, 3), Color.magenta, 5f);

		//Mathf : UnityEngine���� �����ϴ� �پ��� ���� ���� �Լ��� ���Ե� Ŭ����.
		//Mathf.Abs : ���밪�� ��ȯ.
		//float a = -0.3f;
		//a = Mathf.Abs(a);
		//print(a);
		//a = Mathf.Abs(+0.3f);
		//print(a);
		//Debug.DrawRay(Vector3.right, Vector3.up * 2, Color.red,5f);
		//Debug.DrawLine(new Vector3(1, 0, 0), new Vector3(1, 2, 0), Color.green,5f);

		////Mathf.Approximately : �Ǽ��� �ٻ簪 ��. ��Ȯ�� �������� �˻��� �� �����Ƿ�.
		//print(Mathf.Approximately(1.1f + 0.1f,1.2f));
		//print(Mathf.Approximately(0.1f, 0.1f));

		//Mathf.Lerp : ���� ����([L]inear Int[erp]olation) :
		////a���� b �� ������ t�� ������ŭ�� ��ġ�ϴ� ��.(0<t<1)
		//print(Mathf.Lerp(-1f, 1f, 0.5f));
		////Lerp(���� ����)�Լ��� Color, Vector(2,3,4), Material, Quaternion ���� Ŭ�������� ������.
		//Mathf.InverseLerp(0,0,0); //Lerp�� a, b �Ķ���Ͱ� �ݴ�

		//Mathf.Ceil, Floor, Round : �ø�, ����, �ݿø�
		float value = 5.1f;
		float ceil = Mathf.Ceil(value);
		float floor = Mathf.Floor(value);
		float round = Mathf.Round(value);
		print($"Ceil :{ceil} Floor :{Mathf.Floor(floor)} Round :{round}");

		print(Mathf.Sign(-10f)); //��ȣ  ��� :1
		print(Mathf.Sign(10f)); //��ȣ  ��� :-1
		print(Mathf.Sin(60f));//�ﰢ�Լ�(����)
		print(Mathf.Pow(2, 4)); //����  ��� :16

		//Random : ������ �����ϴ� Ŭ����.
		//int�� ��ȯ�ϴ� Range �Լ��� �ִ밪�� �����ϰ� ��ȯ
		int  intRandom = Random.Range(-1, 1); //-1, 0
		//float�� ��ȯ�ϴ� Range �Լ��� �ִ밪�� ���ٰ� ���ֵǴ� ���� ��ȯ�� ���� ����.
		float floatRandom = Random.Range(-1f, 1f); //-1f~1f

		float randomValue = Random.value; // == Random.Range(0f,1f); ����� Ȯ���� ���ϰ� ��� ����.

		//Vector3 randomPosition = new Vector3(Random.value * 5f, Random.value * 5f, Random.value * 5f);
		Vector3 randomPosition = Random.insideUnitSphere;
		//Vector3(-1~1,-1~1,-1~1);
		//��ü�ȿ��� ������ Vector3���� ������
		print(randomPosition);

		Vector3 randomDirection = Random.onUnitSphere;
		//������ Vector3�� ���µ�, ���̰� �׻� 1. ��ü���� �� ǥ��(Point)��
		//������ ������ Vector3���� ������
		print(randomDirection);

		Vector2 randomPosition2D = Random.insideUnitCircle;
		//2D�� Random Vector

		//Random.rotation;
		Random.InitState(11234);//������ �õ尪 �ʱ�ȭ.
		//���� ���ϰ� ���� �ɸ��� �Լ��̹Ƿ�, ����������(�� �ε� �ʱ⶧�뿡��) ����� ��.


	}

    //Gizmo : Sceneâ������ �� �� �ִ� "�����"�� �׸��� Ŭ����.(Debug.DrawXX�� Ȯ�� ���ó��)

    private void Update()
    {
        Gizmos.DrawCube(Vector3.zero, Vector3.one);//<<--�ǹ� ����
    }
	//Gizmo Ŭ������ OnDrawGizmos, OnDrawGizmosSelected, OnSceneGUI�� Sceneâ�� �����Ϳ�����
	//Ȱ��ȭ �Ǵ� �޽��� �Լ������� �����ϰ� �����.
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
