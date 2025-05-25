using UnityEngine;

public class Destroy : MonoBehaviour
{
	void Update()
	{
		if (transform.position.x <= -20)
		{
			Destroy(gameObject);
		}
	}
}
