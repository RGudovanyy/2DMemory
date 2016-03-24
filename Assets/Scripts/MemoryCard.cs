using UnityEngine;
using System.Collections;

public class MemoryCard : MonoBehaviour {
	[SerializeField] private SceneController controller;
	private int _id;
	public int id{
		get {return _id;} // Добавление функции чтения
	}

	// Метод, которым можно пользоваться для передачи указанному объекту новых спрайтов
	public void SetCard(int id, Sprite image){
		_id = id;
		GetComponent<SpriteRenderer>().sprite = image;
	}



	[SerializeField] private GameObject cardBack;
	void OnMouseDown(){
		if(cardBack.activeSelf && controller.canReveal){ // Если объект в данный момент является активным/видимым
														// и он может быть перевернут
			cardBack.SetActive(false); // делаем его невидимым/неактивным
			controller.CardRevealed(this); //Уведомление контроллера об открытии этой карты
		}
	}

	// Метод, позволяющий снова скрыть карту
	public void Unreveal(){
		cardBack.SetActive(true);
	}
}
