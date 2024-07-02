using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class EnemyContrllerTest
{    /// <summary>
     /// シーンロード完了フラグ
     /// </summary>
    bool sceneLoading;

    /// <summary>
    /// テスト対象オブジェクトの参照
    /// </summary>
    GameObject testObject;

    /// <summary>
    /// テストスクリプトの参照
    /// </summary>
    EnemyController targetScript;

    [OneTimeSetUp]
    public void InitializeTest()
    {
        sceneLoading = true;
        SceneManager.LoadSceneAsync("SampleScene").completed += _ => {
            testObject = GameObject.Find("Enemy");
            targetScript = testObject.GetComponent<EnemyController>();
            sceneLoading = false;
            Debug.Log("Scene Load Complete");
        };
    }

    // Order：優先度を指定して最初にロードの完了待ちを行う
    [UnityTest]
    [Order(-100)]
    public IEnumerator LoadWait()
    {
        yield return new WaitWhile(() => sceneLoading);
    }
}