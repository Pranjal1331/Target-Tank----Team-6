using UnityEngine;

namespace TinForge.KV2
{
	public class Rotate : MonoBehaviour
	{
		public float speed;
		void Update()
		{
			transform.Rotate(Vector3.up * speed * Time.deltaTime);
		}
	}
}