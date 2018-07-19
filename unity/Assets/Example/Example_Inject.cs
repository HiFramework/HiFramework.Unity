using HiFramework;
using UnityEngine;

public class Example_Inject : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Framework.Init();

        Init();
    }

    // Update is called once per frame
    void Update()
    {
        Framework.Tick();
    }

    void Init()
    {
        var testInject1 = new TestInject1();
        var testInject2 = new TestInject2();
        var c = Center.Get<InjectComponent>();
        c.Bind<TestInject2>().To(testInject2);
        
        var anoterTestInject2 = new TestInject2();
        anoterTestInject2.x = 10;
        c.Bind<TestInject2>().To(anoterTestInject2).AsName("another");
        c.Inject(testInject1);

        Debug.Log(testInject1.t1.x);
        Debug.Log(testInject1.t2.x);
    }

    public class TestInject1
    {
        [Inject]
        public TestInject2 t1;

        [Inject("another")]
        public TestInject2 t2;
    }

    public class TestInject2
    {
        public int x;
    }
}
