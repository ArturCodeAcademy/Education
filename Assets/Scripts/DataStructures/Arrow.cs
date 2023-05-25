using Unity.VisualScripting;
using UnityEngine;

public class Arrow : MonoBehaviour
{
	public Transform Start { get; private set; }
	public Transform End { get; private set; }

	[SerializeField] private Transform _line;

    private const float TOP_OFFSET = 0.3f; 
    private const float BOTTOM_OFFSET = 0.14f; 

    public void SetPosition(Transform startTransform, Transform endTransform, float endCenterOffset = 0.55f)
    {
		Start = startTransform;
		End = endTransform;
		Vector2 start = startTransform.position;
		Vector2 end = endTransform.position;

		Vector2 direction = (end - start).normalized;
		float offset = endCenterOffset + TOP_OFFSET + BOTTOM_OFFSET;
		float distance = Vector2.Distance(end, start);
		float length = distance - offset;
		transform.up = direction;

		transform.position = end - direction * (endCenterOffset + TOP_OFFSET);
		_line.localScale = new Vector3(1, 0, 1) + Vector3.up * length;
    }
}
