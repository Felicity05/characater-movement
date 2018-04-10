using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverOverCommandHandler : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler{

	public GameObject removeButton;
	public GameObject editButton; 

	#region IPointerEnterHandler implementation

	public void OnPointerEnter (PointerEventData eventData)
	{
		removeButton.SetActive (true);
		editButton.SetActive (true);
		//Debug.Log ("You have hovered over a command");
	}

	#endregion

	#region IPointerExitHandler implementation

	public void OnPointerExit (PointerEventData eventData)
	{
		removeButton.SetActive (false);
		editButton.SetActive (false);
	}

	#endregion




	void OnMouseEnter()
	{
		Debug.Log ("You have hovered over a command");
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
