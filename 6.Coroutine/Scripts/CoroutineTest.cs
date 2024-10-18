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

        //정확히 3초 후에 MeshRenderer의 Material을 woodMaterial로 교체 하고 싶어요.
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
        //StartCoroutine(MaterialChange()); //하수용
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
            print("코루틴 스탑");
            //StopCoroutine(MaterialChange()); //하수용
            StopCoroutine(materialChangeCoroutine); //고수는 이렇게 사용함.
        }
    }

    private IEnumerator<string> StringEnumerator()
    {
        //IEnumerator를 반환하는 함수는
        //yield return 키워드를 통해
        //값을 순차적으로 반환 할 수 있음.
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
        print("바뀜");
        }
    }
}
