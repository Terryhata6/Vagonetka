using UnityEditor;
using UnityEngine;

namespace Vagonetka
{
	[CustomEditor(typeof(RoadPartsSettings))]
	public class RoadPartsEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			RoadPartsSettings testTarget = (RoadPartsSettings)target;
			testTarget.count = EditorGUILayout.IntSlider("Количество объектов", testTarget.count, 1, 50);
			testTarget.offset = EditorGUILayout.IntSlider("Шаг спавна объектов по оси Z", testTarget.offset, 0, 50);
			testTarget.obj = EditorGUILayout.ObjectField("Объект который хотим вставить", testTarget.obj, typeof(GameObject), false) as GameObject;

			var isPressButton = GUILayout.Button("Создание объектов по кнопке", EditorStyles.miniButtonLeft);

			if (isPressButton)
			{
				testTarget.CreateObj();
			}
		}
	}
}
