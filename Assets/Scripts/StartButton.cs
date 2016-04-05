using UnityEngine;
using System.Collections; 
using UnityEngine.UI;

public class StartButton : MonoBehaviour {
	public Color higlightColor = Color.cyan;


	public void OnMouseOver(){
		SpriteRenderer sprite = GetComponent<SpriteRenderer>();
		if(sprite != null)
			sprite.color = higlightColor;
	}

	public void OnMouseExit(){
		SpriteRenderer sprite = GetComponent<SpriteRenderer>();
		if(sprite != null)
			sprite.color = Color.white;
	}

	public void OnMouseDown(){		
		Application.LoadLevel("Scene");
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape))
			Application.Quit ();
	}
}
