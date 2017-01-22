using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateProperties : MonoBehaviour {


	// Use this for initialization
	void Start () {
		assignLeftAndRight (GetComponentsInChildren<KnockUpBlock> ());	
	}

	public void assignLeftAndRight(List<KnockUpBlock> children){

		List<KnockUpBlock> sortedChildren = merge_sort (children);

		sortedChildren [0].rightBlock = sortedChildren [1].gameObject;
		sortedChildren [sortedChildren.Count - 1].leftBlock = sortedChildren [sortedChildren.Count - 2].gameObject;

		for (int i = 1; i < sortedChildren.Count - 1; i++) {
			sortedChildren [i].leftBlock = sortedChildren [i - 1];
			sortedChildren [i].rightBlock = sortedChildren [i + 1];
		}
	}

	public List<KnockUpBlock> merge_sort(List<KnockUpBlock> a){
		if (a.Count <= 1) {
			return a;
		}

		List<KnockUpBlock> left = new List<KnockUpBlock> ();
		List<KnockUpBlock> right = new List<KnockUpBlock> ();

		for (int i = 0; i < a.Count; i++) {
			if (i <= (a.Count) / 2) {
				left.Add (a.ElementAt (i));
			} else {
				right.Add (a.ElementAt (i));
			}
		}

		left += merge_sort (left);
		right += merge_sort (right);

		return merge(left, right);

	}

	public List<KnockUpBlock> merge (List<KnockUpBlock> left, List<KnockUpBlock> right){
		List<KnockUpBlock> result = new List<KnockUpBlock> ();
		while (left.Count != 0 && right.Count != 0) {
			if (left.ElementAt (0).gameObject.transform.position.x <= right.ElementAt (0).gameObject.transform.position.x) {
				KnockUpBlock first = left.RemoveAt (0);
				result.Add (first);
			}
			else{
				KnockUpBlock first = right.RemoveAt(0);
				result.Add(first);
			}
		}

		while (left.Count != 0) {
			KnockUpBlock first = left.RemoveAt (0);
			result.Add (first);
		}
		while (right.Count != 0) {
			KnockUpBlock first = right.RemoveAt (0);
			result.Add (first);
		}
		return result;
	}
}
