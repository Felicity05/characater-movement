// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Colour/Surface" {
	Properties {
		_ColorTop         ("Top", Color) = (0.97, 0.67, 0.51, 1)
		_ColorBottom      ("Bottom", Color) = (0, 0.7, 0.74, 1)
		_ColorRightTop    ("Right Top", Color) = (0, 0, 1, 1)
		_ColorRightBottom ("Right Bottom", Color) = (0, 0, 1, 1)
		_ColorLeftTop     ("Left Top", Color) = (0.5, 0, 0.5, 1)
		_ColorLeftBottom  ("Left Bottom", Color) = (0.5, 0, 0.5, 1)
		_ColorFrontTop    ("Front Top", Color) = (1, 0, 0, 1)
		_ColorFrontBottom ("Front Bottom", Color) = (1, 0, 0, 1)
		_ColorBackTop     ("Back Top", Color) = (0.5, 0.5, 0, 1)
		_ColorBackBottom  ("Back Bottom", Color) = (0.5, 0.5, 0, 1)
		_GradientYStart   ("Gradient Y Start", Float) = 0
		_GradientHeight   ("Gradient Height", Float) = 10
	}
	SubShader {
		Tags { "Queue" = "Geometry" "RenderType" = "Opaque" }
		CGPROGRAM
		#include "UnityCG.cginc"
		#pragma surface surf Unlit vertex:vert
		#define PI_HALF 1.57079632679
		static const float3 kUP = float3(0, 1, 0);
		static const float3 kDOWN = float3(0, -1, 0);
		static const float3 kFRONT = float3(0, 0, 1);
		static const float3 kBACK = float3(0, 0, -1);
		static const float3 kRIGHT = float3(1, 0, 0);
		static const float3 kLEFT = float3(-1, 0, 0);
		sampler2D _MainTex;
		fixed4 _ColorTop, _ColorBottom, _ColorRightTop, _ColorRightBottom, _ColorLeftTop, _ColorLeftBottom, _ColorFrontTop, _ColorFrontBottom, _ColorBackTop, _ColorBackBottom;
		float _GradientYStart, _GradientHeight;
		struct Input
		{
			float4 vertexColor;
		};
		void vert (inout appdata_full v, out Input o) 
		{
			UNITY_INITIALIZE_OUTPUT(Input, o);
				
			float3 N = normalize(mul((float3x3)unity_ObjectToWorld, SCALED_NORMAL));
			float up =    1 - acos(saturate(dot(kUP, kUP * N))) / PI_HALF;
			float down =  1 - acos(saturate(dot(kDOWN, kUP * N))) / PI_HALF;
			float right = 1 - acos(saturate(dot(kRIGHT, kRIGHT * N))) / PI_HALF;
			float left =  1 - acos(saturate(dot(kLEFT, kRIGHT * N))) / PI_HALF;
			float front = 1 - acos(saturate(dot(kFRONT, kFRONT * N))) / PI_HALF;
			float back =  1 - acos(saturate(dot(kBACK, kFRONT * N))) / PI_HALF;
			
			float4 wldpos = mul(unity_ObjectToWorld, v.vertex);
			float f = saturate((wldpos.y - _GradientYStart) / _GradientHeight);
			float4 cr = lerp(_ColorRightBottom, _ColorRightTop, f);
			float4 cl = lerp(_ColorLeftBottom, _ColorLeftTop, f);
			float4 cf = lerp(_ColorFrontBottom, _ColorFrontTop, f);
			float4 cb = lerp(_ColorBackBottom, _ColorBackTop, f);
			
			fixed4 part1 = N.y > 0 ? (_ColorTop * up) : (_ColorBottom * down);
			fixed4 part2 = N.x > 0 ? (cr * right) : (cl * left);
			fixed4 part3 = N.z > 0 ? (cf * front) : (cb * back);
			o.vertexColor = part1 + part2 + part3;
		}
		inline fixed4 LightingUnlit (SurfaceOutput s, fixed3 lightDir, fixed atten)
		{
			return fixed4(s.Albedo, s.Alpha);
		}
		void surf (Input IN, inout SurfaceOutput o)
		{
			o.Albedo = IN.vertexColor.rgb;
			o.Alpha = IN.vertexColor.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}