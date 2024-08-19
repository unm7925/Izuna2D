using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Boss1 : EnemyComponent
{
    public GameObject EnemyAttackA;
    public GameObject EnemyAttackB;
    public GameObject EnemyAttackC;
    public float curDelay;
    public int patternIndex;
    public int curPatternCount;
    public int[] maxPatternCount;

    public float curShotDelay;
    public float maxShotDelay;
    private bool isThinking = false;



    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        playerPos = GameObject.FindWithTag("Player");
        Think();
    }


    void Think()
    {
        patternIndex = UnityEngine.Random.Range(0,3);
        curPatternCount = 0;
        switch (patternIndex)
        {
            case 0:
                
                anim.SetTrigger("FireMagic");
                Invoke("FireMagic", 1.0f);
                break;
            case 1:
                anim.SetTrigger("IceMagic");
                Invoke("IceMagic", 1.0f);
                break;
            case 2:
                anim.SetTrigger("Spark");
                Invoke("Spark", 1.0f);
                break;

        }
    }
    void Idle()
    {
        anim.SetTrigger("Idle");
        Invoke("Think", attackDelay);
    }
    void FireMagic()
    {

        GameObject attackR = Instantiate(EnemyAttackA);
        attackR.transform.position = transform.position + Vector3.right * 1.2f;
        GameObject attackL = Instantiate(EnemyAttackA);
        attackL.transform.position = transform.position + Vector3.left * 1.2f;

        Rigidbody2D rigidR = attackR.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidL = attackL.GetComponent<Rigidbody2D>();

        Vector2 dirVec = playerPos.transform.position - transform.position;

        rigidR.AddForce(dirVec.normalized * 8, ForceMode2D.Impulse);
        rigidL.AddForce(dirVec.normalized * 8, ForceMode2D.Impulse);

        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("FireMagic", 1.0f); //ź�� ����
        else

            Idle();
    }
    void IceMagic()
    {
        int roundNumA = 20;
        int roundNumB = 15;
        int roundNum = curPatternCount % 2 == 0 ? roundNumA : roundNumB;

        for (int index = 0; index < roundNum; index++)
        {
            GameObject attack = Instantiate(EnemyAttackB);
            attack.transform.position = transform.position;
            attack.transform.rotation = Quaternion.identity;
            
            Rigidbody2D rigid = attack.GetComponent<Rigidbody2D>();
            Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * 2 * index / roundNum),
                                            Mathf.Sin(Mathf.PI * 2 * index / roundNum));

            rigid.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);

            Vector3 rotVec = Vector3.forward * 360 * index / roundNum + Vector3.forward * 90;
            attack.transform.Rotate(rotVec);
        }

        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("IceMagic", 1.5f);  //ź�� ����
        else
            Idle();
    }
    void Spark()
    {
        GameObject attack = Instantiate(EnemyAttackC);
        attack.transform.position = playerPos.transform.position + Vector3.up*3;
        Rigidbody2D rigid = attack.GetComponent<Rigidbody2D>();
        Vector2 dirVec = transform.position + Vector3.down;
        rigid.AddForce(dirVec.normalized * 10, ForceMode2D.Impulse);
        Vector3 rotVec = Vector3.forward * 270;
        attack.transform.Rotate(rotVec);

        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("Spark", 1f);  //ź�� ����
        else
            Idle();
    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }
}