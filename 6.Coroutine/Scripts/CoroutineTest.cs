using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UIElements;

public class CoroutineTest : MonoBehaviour
{
    MeshRenderer mr;

    public Material woodMaterial;
    public Material redMaterial;
    private Material stoneMaterial;

    public Transform transformTest;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        stoneMaterial = mr.material;
    }
    void Start()
    {

        //��Ȯ�� 3�� �Ŀ� MeshRenderer�� Material�� woodMaterial�� ��ü �ϰ� �;��.
        //var enumerator = StringEnumerator();
        //while (enumerator.MoveNext())
        //{
        //    print(enumerator.Current);
        //}

        //List<int> list = new List<int>() { 1, 2, 3 };
        //foreach(int i in list)
        //{
        //    print(i);
        //}

        //foreach(Transform someTransform in transformTest)
        //{
        //    print(someTransform.name);
        //}
        //StartCoroutine(MaterialChange()); //�ϼ���
        //=======================
        //print(1);
        //StartCoroutine(Tmp());
        //print(2);
        //print(3);
        //=======================
        materialChangeCoroutine = StartCoroutine(MaterialChange(redMaterial, 3f));
    }
    private Coroutine materialChangeCoroutine;

    //private IEnumerator Tmp()
    //{
    //    print("tmp 1");
    //    print("tmp 2");
    //    yield return null;
    //    print("tmp 3");
    //    print("tmp 4");
    //    yield return null;
    //    print("tmp 5");
    //    print("tmp 6");
    //    yield return null;
    //}

        // Update is called once per frame
        void Update()
    {
        //if(Time.time > 3f)
        //{
        //    mr.material = woodMaterial;
        //}
        if (Input.GetButtonDown("Jump"))
        {
            mr.material = stoneMaterial;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            print("�ڷ�ƾ ��ž");
            //StopCoroutine(MaterialChange()); //�ϼ���
            StopCoroutine(materialChangeCoroutine); //����� �̷��� �����.
        }
    }

    private IEnumerator<string> StringEnumerator()
    {
        //IEnumerator�� ��ȯ�ϴ� �Լ���
        //yield return Ű���带 ����
        //���� ���������� ��ȯ �� �� ����.
        yield return "a";
        yield return "b";
        yield return "c";
    }  

    private IEnumerator MaterialChange(Material mat, float interval)
    {
        while (true)
        {
        yield return new WaitForSeconds(interval);
        mr.material = mat;
        print("�ٲ�");
        }
    }
}
