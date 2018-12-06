using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.UI;

public class MenuTestScript {
    [Test]
    public void StartGameChangesToPlayGame()
    {
        //Get the button
        Button btn = GameObject.Find("StartButton").GetComponent<Button>();
        //Invoke click
        btn.onClick.Invoke();
        //Check if the gameplay is active
        Assert.AreEqual(true, GameObject.Find("GamePlay").active);
    }
}
