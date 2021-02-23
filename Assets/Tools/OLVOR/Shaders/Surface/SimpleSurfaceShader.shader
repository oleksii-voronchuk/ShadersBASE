Shader "OLVOR/Surface/Simple Surface Shader"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_Emission("Emission", Color) = (1,1,1,1)
	}
		SubShader
	{
		CGPROGRAM
			#pragma surface surf Lambert

			struct Input
			{
				float2 uv_MainTex;
			};

			fixed4 _Color;
			fixed4 _Emission;

			void surf(Input IN, inout SurfaceOutput o)
			{
				o.Albedo = _Color.rgb;
				o.Emission = _Emission;
			}
			ENDCG
	}
		FallBack "Diffuse"
}
