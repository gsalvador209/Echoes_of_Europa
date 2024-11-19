Shader "Custom/DistantPlanetShader"
{
    Properties
    {
        _MainTex ("Base Texture", 2D) = "white" {}
        //_SkyColor ("Sky Color", Color) = (0.5, 0.7, 1, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 100

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha   // Asegura la mezcla para transparencia
            ZWrite On
			ZTest LEqual 
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;    
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
                float3 normal : TEXCOORD2;
            };

            sampler2D _MainTex; //Textura principal
            float4 _MainTex_ST; //Control del desplazamiento y escala de la textura

            // Colores para el cielo en diferentes momentos del día
            float4 skyColorBlue = float4(0.5, 0.7, 1, 1);     // Azul
            float4 skyColorOrange = float4(1.0, 0.5, 0.2, 1); // Naranja
            float4 skyColorBlack = float4(0.0, 0.0, 0.0, 1);  // Negro

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.normal = UnityObjectToWorldNormal(v.normal);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                o.uv = v.uv;
               
				return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                // Get texture Color
                float3 texColor = tex2D(_MainTex, i.uv).rgb;

                // Calculate light phase based on light direction
                float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                float3 upDirection = float3(0.0, 1.0, 0.0);  // The "up" vector (for day/night detection)
                float dotProduct = dot(lightDir, upDirection);  // Dot product with the "up" vector

                // Determine sky color based on the light direction
                float3 interpolatedSkyColor;

                if (dotProduct > 0.5) // Midday (sun is high in the sky)
                {
                    interpolatedSkyColor = skyColorBlue.rgb;
                }
                else if (dotProduct > 0.0) // Sunset or sunrise (sun near the horizon)
                {
                    interpolatedSkyColor = skyColorOrange.rgb;
                }
                else // Night (sun is below the horizon)
                {
                    interpolatedSkyColor = skyColorBlack.rgb;
                }

                // Blend the interpolated sky color with the texture based on light intensity
                float lightIntensity = saturate(dot(lightDir, i.normal)); // Light intensity based on the angle
                lightIntensity = pow(lightIntensity, 0.8);  // Optional: adjust light intensity contrast (smooths light transitions)

                // Instead of affecting the sky color with light intensity, only blend it
                float3 skyBlend = lerp(interpolatedSkyColor, texColor, lightIntensity);

                // Calculate alpha (transparency) based on light intensity
                float alpha = lightIntensity; // Areas with less light become more transparent

                // Return final color with calculated transparency
                return float4(skyBlend, alpha);
            }
            ENDCG
        }
    }
}
