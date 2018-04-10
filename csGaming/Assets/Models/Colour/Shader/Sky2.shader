// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Colour/Sky2" {
	Properties {
		_ColorTop ("Top", Color) = (1, 1, 1, 0)
		_ColorMiddle ("Middle", Color) = (1, 1, 1, 0)
		_ColorBottom ("Bottom", Color) = (1, 1, 1, 0)
		_ExponentTop ("Exponent Top", Float) = 1
		_ExponentBottom ("Exponent Bottom", Float) = 1
		_Intensity ("Intensity", Float) = 1
	}
	SubShader {
		Tags { "RenderType" = "Background" "Queue" = "Background" }
		Pass {
			ZWrite Off Cull Off Fog { Mode Off }
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION;
				float3 texcoord : TEXCOORD0;
			};
			half4 _ColorTop, _ColorMiddle, _ColorBottom;
			half _Intensity, _ExponentTop, _ExponentBottom;
			v2f vert (appdata_base v)
			{
				v2f o;
				o.position = UnityObjectToClipPos(v.vertex);
				o.texcoord = v.texcoord;
				return o;
			}
			fixed4 frag (v2f i) : COLOR
			{
				float p = normalize(i.texcoord).y;
				float p1 = 1 - pow(min(1, 1 - p), _ExponentTop);
				float p3 = 1 - pow(min(1, 1 + p), _ExponentBottom);
				float p2 = 1 - p1 - p3;
				return (_ColorTop * p1 + _ColorMiddle * p2 + _ColorBottom * p3) * _Intensity;
			}
            ENDCG
        }
    }
	Fallback Off
}