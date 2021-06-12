using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class crosshairscript : MonoBehaviour
{
	private GameObject crossButtons;
	public Texture firstTexture, secondTexture, thirdTexture, fourthTexture, fifthTexture, sixthTexture, seventhTexture, eighthTexture, ninthTexture,
		tenthTexture, eleventhTexture, twelfthTexture, thirteenthTexture, fourteenthTexture, fiveteenthTexture, sixteenthTexture, seventeenthTexture,
		eighteenthTexture, nineteenthTexture, twentiethTexture, twentyfirstTexture, twentysecondTexture, twentythirdTexture, twentyfourthTexture, twentyfifthTexture;

	public void first()
    {
		GameObject.Find("crossHairImage").GetComponent<RawImage>().texture = firstTexture;
		GameObject.Find("GM").GetComponent<GameManager_References>().crosshairs.SetActive(false);
	}
	public void second()
	{
		GameObject.Find("crossHairImage").GetComponent<RawImage>().texture = secondTexture;
		GameObject.Find("GM").GetComponent<GameManager_References>().crosshairs.SetActive(false);
	}
	public void third()
	{
		GameObject.Find("crossHairImage").GetComponent<RawImage>().texture = thirdTexture;
	}
	public void fourth()
	{
		GameObject.Find("crossHairImage").GetComponent<RawImage>().texture = fourthTexture;
	}
	public void fifth()
	{
		GameObject.Find("crossHairImage").GetComponent<RawImage>().texture = fifthTexture;
	}
	public void sixth()
	{
		GameObject.Find("crossHairImage").GetComponent<RawImage>().texture = sixthTexture;
	}
	public void seventh()
	{
		GameObject.Find("crossHairImage").GetComponent<RawImage>().texture = seventhTexture;
	}
	public void eighth()
	{
		GameObject.Find("crossHairImage").GetComponent<RawImage>().texture = eighthTexture;
	}
	public void ninth()
	{
		GameObject.Find("crossHairImage").GetComponent<RawImage>().texture = ninthTexture;
	}
	public void tenth()
	{
		GameObject.Find("crossHairImage").GetComponent<RawImage>().texture = tenthTexture;
	}
	public void eleventh()
	{
		GameObject.Find("crossHairImage").GetComponent<RawImage>().texture = eleventhTexture;
	}
	public void twelfth()
	{
		GameObject.Find("crossHairImage").GetComponent<RawImage>().texture = twelfthTexture;
	}
	public void thirteenth()
	{
		GameObject.Find("crossHairImage").GetComponent<RawImage>().texture = thirteenthTexture;
	}
	public void fourteenth()
	{
		GameObject.Find("crossHairImage").GetComponent<RawImage>().texture = fourteenthTexture;
	}
	public void fiveteenth()
	{
		GameObject.Find("crossHairImage").GetComponent<RawImage>().texture = fiveteenthTexture;
	}
	public void sixteenth()
	{
		GameObject.Find("crossHairImage").GetComponent<RawImage>().texture = sixteenthTexture;
	}
	public void seventeenth()
	{
		GameObject.Find("crossHairImage").GetComponent<RawImage>().texture = seventeenthTexture;
	}
	public void eighteenth()
	{
		GameObject.Find("crossHairImage").GetComponent<RawImage>().texture = eighteenthTexture;
	}
	public void nineteenth()
	{
		GameObject.Find("crossHairImage").GetComponent<RawImage>().texture = nineteenthTexture;
	}
	public void twentieth()
	{
		GameObject.Find("crossHairImage").GetComponent<RawImage>().texture = twentiethTexture;
	}
	public void twentyfirst()
	{
		GameObject.Find("crossHairImage").GetComponent<RawImage>().texture = twentyfirstTexture;
	}
	public void twentysecond()
	{
		GameObject.Find("crossHairImage").GetComponent<RawImage>().texture = twentysecondTexture;
	}
	public void twentythird()
	{
		GameObject.Find("crossHairImage").GetComponent<RawImage>().texture = twentythirdTexture;
	}
	public void twentyfourth()
	{
		GameObject.Find("crossHairImage").GetComponent<RawImage>().texture = twentyfourthTexture;
	}
	public void twentyfifth()
	{
		GameObject.Find("crossHairImage").GetComponent<RawImage>().texture = twentyfifthTexture;
	}
}
