using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class PopulateProperties : MonoBehaviour {


	// Use this for initialization
	void Start () {
		populateKnockUp (GetComponentsInChildren<KnockUpBlock> ().ToList());	
		print(GetComponentsInChildren<KnockUpBlock> ().ToList());
		print ("Count:" + GetComponentsInChildren<KnockUpBlock> ().ToList ().Count);

	}

	public void assignLeftAndRight(List<KnockUpBlock> children){

		List<KnockUpBlock> sortedChildren = merge_sort (children);
		populateKnockUp (sortedChildren);

	}

	public void populateKnockUp(List<KnockUpBlock> sortedChildren){
		
		sortedChildren.ElementAt(0).rightBlock = sortedChildren.ElementAt(1).gameObject;
		sortedChildren.ElementAt(sortedChildren.Count - 1).leftBlock = sortedChildren.ElementAt(sortedChildren.Count - 2).gameObject;

		for (int i = 1; i < sortedChildren.Count - 1; i++) {
			sortedChildren.ElementAt(i).leftBlock = sortedChildren.ElementAt(i-1).gameObject;
			sortedChildren.ElementAt(i).rightBlock = sortedChildren.ElementAt(i+1).gameObject;
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

		left = merge_sort (left);
		right = merge_sort (right);

		return merge(left, right);

	}

	public List<KnockUpBlock> merge (List<KnockUpBlock> left, List<KnockUpBlock> right){
		List<KnockUpBlock> result = new List<KnockUpBlock> ();
		while (left.Count != 0 && right.Count != 0) {
			if (left.ElementAt (0).gameObject.transform.position.x <= right.ElementAt (0).gameObject.transform.position.x) {
				KnockUpBlock first = left.ElementAt (0);
				left.RemoveAt (0);
				result.Add (first);
			}
			else{
				KnockUpBlock first = right.ElementAt(0);
				right.RemoveAt(0);
				result.Add(first);
			}
		}

		while (left.Count != 0) {
			KnockUpBlock first = left.ElementAt (0);
			left.RemoveAt (0);
			result.Add (first);
		}
		while (right.Count != 0) {
			KnockUpBlock first = right.ElementAt (0);
			right.RemoveAt (0);
			result.Add (first);
		}
		return result;
	}
}
