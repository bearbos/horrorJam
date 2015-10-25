using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class maskController : MonoBehaviour {

	public List<GameObject> maskCollection = new List<GameObject>();
	GameObject activeMask;
	int currentIndex;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 5; ++i) {
			maskCollection.Add(null);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (activeMask != null) {
			activeMask.transform.position = this.transform.position;
			activeMask.GetComponent<SpriteRenderer> ().enabled = true;
			activeMask.GetComponent<Mask> ().enabled = true;
			if (this.transform.localScale.x < 0)
				activeMask.transform.localScale = new Vector3 (-1.0f, 1.0f, 1.0f);
			else
				activeMask.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		}
	}

	/// <summary>
	/// Changes the mask.
	/// </summary>
	/// <param name="dir">If set to <c>true</c> dir.</param>
	public void ChangeMask(bool dir)
	{
		if (dir)
			++currentIndex;
		else
			--currentIndex;

		if (currentIndex < 0)
			currentIndex = maskCollection.Count - 1;
		else if (currentIndex >= maskCollection.Count)
			currentIndex = 0;

		if (activeMask != null) {
			activeMask.GetComponent<SpriteRenderer> ().enabled = false;
			activeMask.GetComponent<Mask> ().enabled = false;
		}

		activeMask = maskCollection [currentIndex];
	}

	/// <summary>
	/// Pickups a mask.
	/// </summary>
	public void AddAMask(GameObject mask)
	{
		maskCollection.Add (mask);
		currentIndex = maskCollection.Count - 1;
		activeMask = maskCollection [currentIndex];
	}
}
