// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Colour/Sky1" {
	Properties {
		_ColorTop ("Top Color", Color) = (0.97, 0.67, 0.51, 1)
		_ColorBottom ("Bottom Color", Color) = (0, 0.7, 0.74, 1)
		_Intensity ("Intensity", Float) = 1
		_Exponent ("Exponent", Float) = 1
		_Direction ("Direction", Vector) = (0, 1, 0, 0)
	}
	SubShader {
		Tags { "RenderType" = "Background" "Queue" = "Background" }
		Pass {
			ZWrite Off Cull Off Fog { Mode Off }
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			fixed4 _ColorBottom, _ColorTop;
			half3 _Direction;
			half _Intensity, _Exponent;
			struct v2f
			{
				float4 position : SV_POSITION;
				float3 texcoord : TEXCOORD0;
			};
			v2f vert (appdata_base v)
			{
				v2f o;
				o.position = UnityObjectToClipPos(v.vertex);
				o.texcoord = v.texcoord;
				return o;
			}
			fixed4 frag (v2f i) : SV_TARGET
			{
				half d = dot(normalize(i.texcoord), _Direction) * 0.5 + 0.5;
				return lerp(_ColorBottom, _ColorTop, pow(d, _Exponent)) * _Intensity;
			}
			ENDCG
		}
	}
	Fallback Off
}
