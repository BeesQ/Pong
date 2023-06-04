using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerManager : MonoBehaviour
{
    // public GameManager.PlayerType playerType;
    public enum PlayerType { One, Two };
    public PlayerType myPlayerType;
    PlayerMovement myPlayerMovement = null;



    void Awake()
    {
        myPlayerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    void FixedUpdate()
    {
        myPlayerMovement.HandleMovement((int)myPlayerType);
    }
}

// [CustomEditor(typeof(PlayerManager))]
// public class PlayerManagerEditor : Editor
// {
//     SerializedProperty playerTypeProp;

//     private void OnEnable()
//     {
//         playerTypeProp = serializedObject.FindProperty("playerType");
//     }

//     public override void OnInspectorGUI()
//     {
//         serializedObject.Update();

//         GameManager.PlayerType selectedType = (GameManager.PlayerType)playerTypeProp.enumValueIndex;
//         selectedType = (GameManager.PlayerType)EditorGUILayout.EnumPopup("Player Type", selectedType);
//         playerTypeProp.enumValueIndex = (int)selectedType;

//         serializedObject.ApplyModifiedProperties();
//     }
// }