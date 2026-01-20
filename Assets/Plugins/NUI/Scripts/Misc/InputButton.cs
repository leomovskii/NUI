using System;

namespace NUI {
	[Flags]
	public enum InputButton {
		None = 0,
		Left = 1 << 0,
		Right = 1 << 1,
		Middle = 1 << 2
	}
}