using UnityEngine;


namespace Vagonetka
{
    public class TestBuild : MonoBehaviour
    {
        [SerializeField] private SceneCreator _kit;

        private void Start()
        {
            SceneBuilder builder = FindObjectOfType<SceneBuilder>();

            builder.BuildScene(_kit);
        }
    }
}
