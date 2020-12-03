using UnityEngine;

namespace Vagonetka
{
    public class RoadPartsSettings : MonoBehaviour
    {
		public int count = 1;
		public int offset = 0;
		public GameObject obj;
		public float Test;
		private Transform _root;

		public void CreateObj()
		{
			_root = new GameObject("RoadParts").transform;
			for (var i = 1; i <= count; i++)
			{
				Instantiate(obj, new Vector3(0, 0, offset * i), Quaternion.identity, _root);
			}
		}
	}
}