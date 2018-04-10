using UnityEngine;
using System.Collections;

public class Colour : MonoBehaviour
{
	public Color m_ColorTop = new Color (0.97f, 0.67f, 0.51f, 1f);
	public Color m_ColorBottom = new Color (0f, 0.7f, 0.74f, 1f);
	public Color m_ColorRightTop = new Color (0f, 0f, 1f, 1f);
	public Color m_ColorRightBottom = new Color (0f, 0f, 1f, 1f);
	public Color m_ColorLeftTop = new Color (0.5f, 0f, 0.5f, 1f);
	public Color m_ColorLeftBottom = new Color (0.5f, 0f, 0.5f, 1f);
	public Color m_ColorFrontTop = new Color (1f, 0f, 0f, 1f);
	public Color m_ColorFrontBottom = new Color (1f, 0f, 0f, 1f);
	public Color m_ColorBackTop = new Color (0.5f, 0.5f, 0f, 1f);
	public Color m_ColorBackBottom = new Color (0.5f, 0.5f, 0f, 1f);
	public float m_GradientYStart = 0f;
	public float m_GradientHeight = 1f;
	Renderer m_Rd;

	void Start ()
	{
		m_Rd = GetComponent<Renderer> ();
	}
	void Update ()
	{
		Material[] mats = m_Rd.materials;
		for (int i = 0; i < mats.Length; i++)
		{
			mats[i].SetColor ("_ColorTop", m_ColorTop);
			mats[i].SetColor ("_ColorBottom", m_ColorBottom);
			mats[i].SetColor ("_ColorRightTop", m_ColorRightTop);
			mats[i].SetColor ("_ColorRightBottom", m_ColorRightBottom);
			mats[i].SetColor ("_ColorLeftTop", m_ColorLeftTop);
			mats[i].SetColor ("_ColorLeftBottom", m_ColorLeftBottom);
			mats[i].SetColor ("_ColorFrontTop", m_ColorFrontTop);
			mats[i].SetColor ("_ColorFrontBottom", m_ColorFrontBottom);
			mats[i].SetColor ("_ColorBackTop", m_ColorBackTop);
			mats[i].SetColor ("_ColorBackBottom", m_ColorBackBottom);
			mats[i].SetFloat ("_GradientYStart", m_GradientYStart);
			mats[i].SetFloat ("_GradientHeight", m_GradientHeight);
		}
	}
}
