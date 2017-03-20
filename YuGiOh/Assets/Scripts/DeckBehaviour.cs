using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DeckBehaviour : MonoBehaviour, IPointerClickHandler
{


	public GameObject Card;
	public 	bool clicked = false;
	GameObject inst,tt;
	public GameObject Panel;
	public Image sp,dp,mp1,bp,mp2,ep;
	float ScaleX = 43f;
	float ScaleY = 65.4f;
	float ScaleZ = 65.28835f;
	public bool standend=false,Draw=false;
	float lerp = 0, duraation = 1,lerp2=0,startwait=5;
	public	GameObject Hand;
	Vector3 start, end;
	void Start()
	{
		bp.gameObject.SetActive (false);
		sp.gameObject.SetActive (false);
		mp1.gameObject.SetActive (false);
		mp2.gameObject.SetActive (false);
		dp.gameObject.SetActive (false);
		ep.gameObject.SetActive (false);
		//print(Card.GetComponent<RectTransform>().lossyScale);
		//Debug.Log(Card.GetComponent<RectTransform>().localScale);
		//Deck = GameObject.FindGameObjectWithTag("Deck");
		Hand = GameObject.FindGameObjectWithTag("PlayerHand");
	
		start = transform.position;
		end = Hand.transform.position;

		//inst = Instantiate(Card, this.transform.position, this.transform.rotation) as GameObject;
		//inst.transform.SetParent(Hand.transform.parent);
	}

	// Update is called once per frame
	public 	void Update()
	{
		
		if (Hand.transform.childCount == 6) {
		 
			dp.gameObject.SetActive (true);
			standend = true;
		}
			
		while (clicked == false && Hand.transform.childCount <6&&standend==false) {
			if (Hand.transform.childCount == 5) {
				sp.gameObject.SetActive (true);
			}
				wakeme ();
			
		}

		if (clicked)
		{
			//Debug.Log("here");
			lerp += Time.deltaTime / duraation;
			inst.transform.position = Vector3.Lerp(start, end, lerp);
			if (inst.transform.position == end)
			{
				//Debug.Log("here");
				inst.transform.SetParent(Hand.transform);
				//print(inst.GetComponent<DragAndDropCard>().panel.name);
				clicked = false;
			}
		}


	}

	public void OnPointerClick(PointerEventData eventData)
	{
		clicked = true;
		lerp = 0;
		inst = Instantiate(Card, this.transform.position, this.transform.rotation) as GameObject;
		inst.transform.SetParent(Hand.transform.parent);
		float rate = 68 / ScaleX;

		inst.GetComponent<RectTransform>().localScale = new Vector3(68, ScaleY * rate, ScaleZ * rate);
		Panel.transform.SetParent(inst.transform);
	

		Cards c = CardsDB.PlayerOne.RandomOrderPlayingCard[CardsDB.PlayerOne.RandomOrderPlayingCard.Count - 1];
		print(c.CardName);
		CardsDB.PlayerOne.RandomOrderPlayingCard.RemoveAt(CardsDB.PlayerOne.RandomOrderPlayingCard.Count - 1);
		//print(c.CardName);
		Debug.Log(c.GetType().ToString());
		if (c.GetType()==typeof(Monsters))
		{
			//Debug.Log("HERE");
			Monsters newMonster = new Monsters((Monsters)c);
			Debug.Log(newMonster.CardImage.name);
			inst.transform.GetChild(0).GetComponent<Image>().sprite = newMonster.CardImage;
			inst.transform.GetChild(1).GetComponent<Text>().text = "ATK/" + newMonster.AttackPoints + "   " + "DEF/" + newMonster.DefencePoints;
		}
		else if (c.GetType() == typeof(Spells))
		{
			Spells newMonster = new Spells((Spells)c);
			Debug.Log(newMonster.CardImage.name);
			inst.transform.GetChild(0).GetComponent<Image>().sprite = newMonster.CardImage;
			//inst.transform.GetChild(1).GetComponent<Text>().text = "ATK/" + newMonster.AttackPoints + "   " + "DEF/" + newMonster.DefencePoints;
		}
		else if (c.GetType() == typeof(Traps))
		{
			Traps newMonster = new Traps((Traps)c);
			Debug.Log(newMonster.CardImage.name);
			inst.transform.GetChild(0).GetComponent<Image>().sprite = newMonster.CardImage;
			//inst.transform.GetChild(1).GetComponent<Text>().text = "ATK/" + newMonster.AttackPoints + "   " + "DEF/" + newMonster.DefencePoints;
		}

	}
	void wakeme()
	{


		lerp = 0;
		inst = Instantiate(Card, this.transform.position, this.transform.rotation) as GameObject;
		inst.transform.SetParent(Hand.transform.parent);
		float rate = 68 / ScaleX;

		inst.GetComponent<RectTransform>().localScale = new Vector3(68, ScaleY * rate, ScaleZ * rate);
		Panel.transform.SetParent(inst.transform);
		clicked = true;

		Cards c = CardsDB.PlayerOne.RandomOrderPlayingCard[CardsDB.PlayerOne.RandomOrderPlayingCard.Count - 1];
		print(c.CardName);
		CardsDB.PlayerOne.RandomOrderPlayingCard.RemoveAt(CardsDB.PlayerOne.RandomOrderPlayingCard.Count - 1);
		//print(c.CardName);
		Debug.Log(c.GetType().ToString());
		if (c.GetType()==typeof(Monsters))
		{
			//Debug.Log("HERE");
			Monsters newMonster = new Monsters((Monsters)c);
			Debug.Log(newMonster.CardImage.name);
			inst.transform.GetChild(0).GetComponent<Image>().sprite = newMonster.CardImage;
			inst.transform.GetChild(1).GetComponent<Text>().text = "ATK/" + newMonster.AttackPoints + "   " + "DEF/" + newMonster.DefencePoints;
		}
		else if (c.GetType() == typeof(Spells))
		{
			Spells newMonster = new Spells((Spells)c);
			Debug.Log(newMonster.CardImage.name);
			inst.transform.GetChild(0).GetComponent<Image>().sprite = newMonster.CardImage;
			//inst.transform.GetChild(1).GetComponent<Text>().text = "ATK/" + newMonster.AttackPoints + "   " + "DEF/" + newMonster.DefencePoints;
		}
		else if (c.GetType() == typeof(Traps))
		{
			Traps newMonster = new Traps((Traps)c);
			Debug.Log(newMonster.CardImage.name);
			inst.transform.GetChild(0).GetComponent<Image>().sprite = newMonster.CardImage;
			//inst.transform.GetChild(1).GetComponent<Text>().text = "ATK/" + newMonster.AttackPoints + "   " + "DEF/" + newMonster.DefencePoints;
		}
	}




}








