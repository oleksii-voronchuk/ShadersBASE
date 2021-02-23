using UnityEngine;

namespace Assets.Scripts
{
    public class RotationComponent : MonoBehaviour
    {
#pragma warning disable 649
        [SerializeField] private float speed;
#pragma warning restore 649
        private void Update()
        {
            transform.Rotate(Vector3.up, Time.deltaTime * speed);
        }
    }
}
