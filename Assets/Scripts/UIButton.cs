using UnityEngine;
using System.Collections;

public class UIButton : MonoBehaviour {
	[SerializeField] private GameObject targetObject;
	[SerializeField] private string targetMessage;
	public Color higlightColor = Color.cyan;

	// Реакция на наведение курсора	
	public void OnMouseOver(){
		SpriteRenderer sprite = GetComponent<SpriteRenderer>();
		if(sprite != null)
			sprite.color = higlightColor;
	}

	// Реакция на убирание курсора
	public void OnMouseExit(){
		SpriteRenderer sprite = GetComponent<SpriteRenderer>();
		if(sprite != null)
			sprite.color = Color.white;
	}

	// Реакция на клик
	public void OnMouseDown(){
		transform.localScale = new Vector3(1.1f,1.1f,1.1f);
	}

	//Реакция после клика
	public void OnMouseUp(){
		transform.localScale = Vector3.one;
		if(targetObject != null)
			targetObject.SendMessage(targetMessage); 
	}
}
