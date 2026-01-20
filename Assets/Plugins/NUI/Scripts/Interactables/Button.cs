using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace NUI {
	[AddComponentMenu("NUI/Button")]
	public class Button : MonoBehaviour, IPointerClickHandler {

		[SerializeField] private bool _interactable = true;
		[SerializeField] private bool _loop = true;
		[SerializeField] private InputButton _button = InputButton.Left;

		[Space]

		[SerializeField] protected UnityEvent _onClickEvent;

		protected Button() { }

		public bool Interactable {
			get => _interactable;
			set => _interactable = value;
		}

		public InputButton InputButton {
			get => _button;
			set => _button = value;
		}

		public UnityEvent OnClickEvent {
			get => _onClickEvent;
			set => _onClickEvent = value;
		}

		public void TryClick(bool checkCanBeClicked = true) {
			if (!checkCanBeClicked || isActiveAndEnabled && _interactable)
				_onClickEvent?.Invoke();
		}

		public void OnPointerClick(PointerEventData eventData) {
			if (eventData.button == PointerEventData.InputButton.Left && (_button & InputButton.Left) != 0 ||
				eventData.button == PointerEventData.InputButton.Right && (_button & InputButton.Right) != 0 ||
				eventData.button == PointerEventData.InputButton.Middle && (_button & InputButton.Middle) != 0) {
				TryClick();
			}
		}
	}
}