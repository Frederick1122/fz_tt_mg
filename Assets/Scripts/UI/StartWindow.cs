using CookingPrototype.Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CookingPrototype.UI {
	public sealed class StartWindow : MonoBehaviour {
		public TMP_Text GoalText    = null;
		public Button   OkButton    = null;
		
		const string DISH = "блюд(о)";
		
		bool _isInit = false;

		void Init() {
			var gc = GameplayController.Instance;

			
			
			OkButton.onClick.AddListener(gc.StartGame);
		}
		
		public void Show () {
			if ( !_isInit ) {
				Init();
			}

			SetNewOrderTarget();
			GameplayController.Instance.TotalOrdersServedChanged += SetNewOrderTarget;
			
			gameObject.SetActive(true);
		}
		
		public void Hide() {
			GameplayController.Instance.TotalOrdersServedChanged -= SetNewOrderTarget;
			gameObject.SetActive(false);
		}

		void SetNewOrderTarget() {
			GoalText.text = $"{GameplayController.Instance.OrdersTarget} {DISH}";
		}
	}
}