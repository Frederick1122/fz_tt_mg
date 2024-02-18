using UnityEngine;
using JetBrains.Annotations;

namespace CookingPrototype.Kitchen {
	[RequireComponent(typeof(FoodPlace))]
	public sealed class FoodTrasher : MonoBehaviour {
		FoodPlace _place = null;

		bool _isFirstClickDone = false;
		
		void Start() {
			_place = GetComponent<FoodPlace>();
		}

		/// <summary>
		/// Освобождает место по двойному тапу если еда на этом месте сгоревшая.
		/// </summary>
		[UsedImplicitly]
		public void TryTrashFood() {
			var food = _place.CurFood;

			if ( food == null )
			{
				return;
			}

			if ( food.CurStatus != Food.FoodStatus.Overcooked ) 
			{
				return;
			}

			if ( _isFirstClickDone ) 
			{
				_place.FreePlace();	
				_isFirstClickDone = false;
			}
			else 
			{
				_isFirstClickDone = true;
			}
		}
	}
}