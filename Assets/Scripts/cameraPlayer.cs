using UnityEngine;

public class cameraPlayer : MonoBehaviour
{
	public Transform player;
	public float yOffset = 0.0f;
	public float xOffset = 0.0f;

	void LateUpdate()
	{
		if (player != null)
		{
			Vector3 position = player.position;
			position.x += xOffset;
			position.y += yOffset;
			position.z = transform.position.z;
			transform.position = position;
		}
	}
}