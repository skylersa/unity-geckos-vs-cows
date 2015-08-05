using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyTextController : MonoBehaviour {
	
	int money;
	Text moneyText;
//	Animator animator;
	
	static MoneyTextController instance;
	
	void Awake() {
		instance = this;
	}
	
	void Start () {
		moneyText = gameObject.GetComponent<Text> ();
//		animator = gameObject.GetComponent<Animator> ();
		ResetScore ();
	}
	
	public void ResetScore() {
		money = 650;
		UpdateText ();
	}
	
	public static void AddMoney(int money) {
		instance.money += money;
		instance.UpdateText ();
	}
	
	void UpdateText () {
		moneyText.text = string.Format ("${0,-4:n0}", money);
//		animator.SetTrigger ("ValueChanged");
	}
	
}