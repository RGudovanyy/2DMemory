using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {
	[SerializeField] private MemoryCard originalCard;
	[SerializeField] private Sprite[] images;
	[SerializeField] private TextMesh turnsLabel;

	public const int gridRows = 2; // Количество строк
	public const int gridCols = 5; // Количество столбцов
	public const float offsetX = 1.5f;
	public const float offsetY = 2.5f;

	private MemoryCard _firstRevealed;
	private MemoryCard _secondRevealed;

	public bool canReveal{
		get{return _secondRevealed == null;}
	}

	private int _turns = 0;

	// Use this for initialization
	void Start () {
		Vector3 startPos = originalCard.transform.position; // Положение первой карты, от которой высчитываются остальные
		// Массив с парами идентификаторов для всех спрайтов с изображениями карт
		int[] numbers = {0,0,1,1,2,2,3,3,4,4};

		// Перемешиваем массив
		numbers = ShuffleArray(numbers);

		// Вложенными циклами задаем столбцы и строки таблицы
		for(int i = 0; i < gridCols; i++){
			for(int j = 0; j < gridRows; j++){
				MemoryCard card; // Ссылка на контейнер  для исходной карты и ее копий
				if(i == 0 && j == 0){
					card = originalCard;
				}else{
					card = Instantiate(originalCard) as MemoryCard;
				}
				int index = j * gridCols + i;
				// Получаем id из массива
				int id = numbers[index];
				card.SetCard(id,images[id]);

				float posX = (offsetX * i) + startPos.x;
				float posY = -(offsetY * j) + startPos.y;
				card.transform.position = new Vector3(posX, posY, startPos.z);
			}
		}
	}

	public void CardRevealed(MemoryCard card){
		if(_firstRevealed == null){
			_firstRevealed = card;
		}else{
			_secondRevealed = card;
			StartCoroutine(CheckMath());
		}
	}

	private IEnumerator CheckMath(){
		if(_firstRevealed.id != _secondRevealed.id){
			yield return new WaitForSeconds(0.6f);
			_firstRevealed.Unreveal();
			_secondRevealed.Unreveal();		
		}
		_turns++;
		turnsLabel.text = "Turns: " + _turns;
		_firstRevealed = null;
		_secondRevealed = null;
	}

	// Реализация алгоритма тасования Кнута
	private int[] ShuffleArray(int[] numbers){
		int[] newArray = numbers.Clone() as int[];
		for(int i = 0; i < newArray.Length; i++){
			int tmp = newArray[i];
			int r = Random.Range(i, newArray.Length);
			newArray[i] = newArray[r];
			newArray[r] = tmp;
		}
		return newArray;
	}

	public void Restart(){
		Application.LoadLevel("Scene");
	}
}
