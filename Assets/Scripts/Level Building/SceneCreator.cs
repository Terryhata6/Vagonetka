using UnityEngine;
using NaughtyAttributes;


namespace Vagonetka
{
    [CreateAssetMenu(fileName = "Scene_1", menuName = "ScenesCreator", order = 0)]
    public class SceneCreator : ScriptableObject
    {
        [ReorderableList] public LevelPartPreset[] LevelPartsArray;
    }
}