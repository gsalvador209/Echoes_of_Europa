Shader "Custom/Ocean2"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _DeltaTime("Time",Float)=0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

			float Random(float3 seed)
			{
				// Convierte la semilla a un único valor
				return frac(sin(dot(seed, float3(12.9898, 78.233, 45.164))) * 43758.5453);
			}


            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _DeltaTime;

            v2f vert (appdata v)
            {
                v2f o;
				float randomOffset = Random(v.vertex.xyz)*0.01;
                //asociando ec matem�tica 
                v.vertex.z += 0.005f*sin(10.0f*v.vertex.y + 2*_DeltaTime); //disminuir frecuencia reduce la fuerza 
                v.vertex.z += 0.005*sin(20.0f*v.vertex.y + 0.1*_DeltaTime); //disminuir frecuencia reduce la fuerza 
                //v.vertex.y += sin(v.vertex.y/10000 + _DeltaTime); //disminuir frecuencia reduce la fuerza 
				v.vertex += randomOffset;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
			ENDCG
        }
    }
}
