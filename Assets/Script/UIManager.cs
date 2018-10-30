using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
	public RectTransform colorMenu;
	public RectTransform actionMenu;

	private bool menuAnimating;
	private bool areMenusShowing;
	private float menuAnimationTransition;
	private float animationDuration = 0.2f;

	private void Update()
	{
		if (Input.GetKeyDown (KeyCode.A))
			OnTheOneButtonClick ();

		if (menuAnimating) 
		{
			if (areMenusShowing) 
			{
				menuAnimationTransition += Time.deltaTime * (1-animationDuration);
				if (menuAnimationTransition >= 1) 
				{
					menuAnimationTransition = 1;
					menuAnimating = false;
				}
			} 
			else 
			{
				menuAnimationTransition -= Time.deltaTime * (1-animationDuration);
				if (menuAnimationTransition <= 0) 
				{
					menuAnimationTransition = 0;
					menuAnimating = false;
				}
			}

			colorMenu.anchoredPosition = Vector2.Lerp (new Vector2 (0,500), new Vector2 (0, -125), menuAnimationTransition);
			actionMenu.anchoredPosition = Vector2.Lerp (new Vector2 (-500, 0), new Vector2 (1125, 0), menuAnimationTransition);
		}
	}

	public void OnTheOneButtonClick()
	{
		areMenusShowing = !areMenusShowing;
		PlayMenuAnimation ();
	}

	private void PlayMenuAnimation()
	{
		menuAnimating = true;
	}
}
