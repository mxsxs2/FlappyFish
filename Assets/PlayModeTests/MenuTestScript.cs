using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.UI;

public class MenuTestScript {

    [Test]
    public void MenuTestScriptSimplePasses() {
        // Use the Assert class to test conditions.
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator MenuTestScriptWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
    /*[UnityTest]
    public IEnumerator MonoBehaviourTest_Works()
    {
        
    }*/
    [Test]
    public void StartGameChangesToPlayGame()
    {
        Button btn = GameObject.Find("MainMenu").GetComponent<Button>();
        //btn.onClick.Invoke();
        Assert.AreEqual(true, GameObject.Find("MainMenu").active);
        // Assert.AreEqual(true, GameObject.Find("GamePlay").active);
    }

    [UnityTest]
    public IEnumerator MonoBehaviourTest_Works()
    {
        yield return new MonoBehaviourTest<MyMonoBehaviourTest>();
    }

    public class MyMonoBehaviourTest : MonoBehaviour, IMonoBehaviourTest
    {
        private int frameCount;
        public bool IsTestFinished
        {
            get { return frameCount > 10; }
        }

        void Update()
        {
            frameCount++;
        }
    }
}
