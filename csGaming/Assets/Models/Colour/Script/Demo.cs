using UnityEngine;
using System.Collections;

public class Demo : MonoBehaviour
{
	public Skybox m_Skybox;
	public enum ESky { Sky1, Sky2 };
	public ESky m_SkyShader = ESky.Sky1;
	public Color m_ColorTop = new Color (0.97f, 0.67f, 0.51f, 1f);
	public Color m_ColorBottom = new Color (0f, 0.7f, 0.74f, 1f);
	[Header("Sky1")]
	[Range(0f, 3f)] public float m_Exponent = 1f;
	[Header("Sky2")]
	public Color m_ColorMiddle = new Color (1f, 1f, 0f, 1f);
	[Range(0f, 3f)] public float m_ExponentTop = 2.5f;
	[Range(0f, 3f)] public float m_ExponentBottom = 2.5f;
	Shader[] m_Sdr = new Shader[2];

	void Start ()
	{
		QualitySettings.antiAliasing = 8;
		m_Sdr[0] = Shader.Find ("Colour/Sky1");
		m_Sdr[1] = Shader.Find ("Colour/Sky2");
		ApplySkyMaterial ();
	}
	void Update ()
	{
		ApplySkyMaterial ();
	}
	void ApplySkyMaterial ()
	{
		if (m_SkyShader == ESky.Sky1)
			m_Skybox.material.shader = m_Sdr[0];
		else
			m_Skybox.material.shader = m_Sdr[1];
		m_Skybox.material.SetColor ("_ColorTop", m_ColorTop);
		m_Skybox.material.SetColor ("_ColorBottom", m_ColorBottom);
		m_Skybox.material.SetFloat ("_Exponent", m_Exponent);
		m_Skybox.material.SetColor ("_ColorMiddle", m_ColorMiddle);
		m_Skybox.material.SetFloat ("_ExponentTop", m_ExponentTop);
		m_Skybox.material.SetFloat ("_ExponentBottom", m_ExponentBottom);
	}
	void OnGUI ()
	{
		GUI.Box (new Rect (10, 10, 100, 25), "Colour Demo");
	}
}
