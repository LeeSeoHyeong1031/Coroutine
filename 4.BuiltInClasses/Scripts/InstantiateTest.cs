using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class InstantiateTest : MonoBehaviour
{
	public GameObject original;
	void Start()
	{
		//original ��ü�� �Ȱ��� ���� ������Ʈ�� �ϳ� �� ����� ���� ��ġ�ϰ� ������.
		//GameObject clone = new GameObject("Clone");
		//MeshFilter mf = clone.AddComponent<MeshFilter>();
		//MeshRenderer mr = clone.AddComponent<MeshRenderer>();

		//mf.mesh = original.GetComponent<MeshFilter>().mesh;
		//mr.material = original.GetComponent<MeshRenderer>().material;
		//clone.transform.position = original.transform.position + Vector3.right;
		//�̷� ���� ���ϰ� �������� �ѹ��� �ϴ� ���!

		//Instantiate:�Ķ���� ��ü�� �Ȱ��� �����ϴ� �Լ�
		//Instantiate(original).transform.position = original.transform.position + Vector3.right *2;
		//����� ���ÿ� Hierachy�󿡼� Ư�� ��ü�� �ڽ��� �Ǿ�� �� ���
		//Instantiate(original, transform);
		//����� ���ÿ� Ư�� ��ġ�� Ư�� ���������� �����Ǿ�� �� ���.
		//Instantiate(original,Vector3.right*2,Quaternion.identity);
		//Instantiate �Լ��� �Ķ���͸� ���� ������ ��ü�� Retrun��
		GameObject clone = Instantiate(original,Vector3.right*2,Quaternion.identity);
		clone.name = "this is clone";

	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
