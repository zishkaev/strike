using System;

public interface IBar {
	float BarValue();
	Action OnChangeValue { get; set; }
}
