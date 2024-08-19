using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerGroundData
{
    [field: SerializeField][field: Range(0f, 25f)] public float baseSpeed { get; private set; } = 5f;
}

[Serializable]
public class PlayerAirData
{
    [field: Header("JumpData")]
    [field: SerializeField][field: Range(0f, 25f)] public float jumpForce { get; private set; } = 9f;
}

[Serializable]
public class PlayerAttackData
{
    [field: SerializeField] public List<AttackInfoData> attackInfoDatas { get; private set; }
    public int GetAttackInfoCount() { return attackInfoDatas.Count; }
    public AttackInfoData GetAttackInfoData(int index) { return attackInfoDatas[index]; }  
}

[Serializable]
public class AttackInfoData
{
    [field: SerializeField] public string attackName { get; private set; }
    [field: SerializeField] public int comboStateIndex { get; private set; }
    [field: SerializeField][field: Range(0f, 1f)] public float comboTransitionTime { get; private set; } = 0.8f;
    [field: SerializeField][field: Range(0f, 1f)] public float forceTransitionTime { get; private set; } = 0.1f;
    [field: SerializeField][field: Range(-10f, 10f)] public float force { get; private set; } = 1f;
    [field: SerializeField] public int damage { get; private set; } = 15;
}

[CreateAssetMenu(fileName = "Player", menuName = "Characters/Player")]
public class PlayerSO : ScriptableObject
{
    [field: SerializeField] public PlayerGroundData groundData { get; private set; }
    [field: SerializeField] public PlayerAirData airData { get; private set; }
    [field: SerializeField] public PlayerAttackData attackData { get; private set; }
}
