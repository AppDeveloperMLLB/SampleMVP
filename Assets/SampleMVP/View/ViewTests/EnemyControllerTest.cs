using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class EnemyContrllerTest
{    /// <summary>
     /// �V�[�����[�h�����t���O
     /// </summary>
    bool sceneLoading;

    /// <summary>
    /// �e�X�g�ΏۃI�u�W�F�N�g�̎Q��
    /// </summary>
    GameObject testObject;

    /// <summary>
    /// �e�X�g�X�N���v�g�̎Q��
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

    // Order�F�D��x���w�肵�čŏ��Ƀ��[�h�̊����҂����s��
    [UnityTest]
    [Order(-100)]
    public IEnumerator LoadWait()
    {
        yield return new WaitWhile(() => sceneLoading);
    }
}