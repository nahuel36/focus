Shader "Lab36/Fractal"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
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

            #define iResolution _ScreenParams
            #define gl_FragCoord ((_iParam.scrPos.xy/_iParam.scrPos.w) * _ScreenParams.xy)
            #define iTime _Time*20


            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float4 scrPos : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos (v.vertex);
                o.scrPos = ComputeScreenPos(o.pos);
                return o;
            }

            float3 palette( float t ) 
            {
                float3 a = float3(0.0, 0.0, 0.5);
                float3 b = float3(0.5, 0.5, 0.5);
                float3 c = float3(1.0, 1.0, 1.0);
                float3 d = float3(5.163,5.216,0.257);
                float3 f = float3(0.5+cos(iTime).x,-0.5+cos(iTime).x,1.0+cos(iTime).x);
                return a*c*d*tan(f) + b*cos( 6.28318*(c*t+d) );
            }


            fixed4 frag (v2f _iParam) : SV_Target
            {
                float2 uv;
                if(_iParam.scrPos.y > 0.5)
                    uv = (2. * gl_FragCoord.xy - iResolution.xy) / iResolution.y;
                else
                    uv = (-2. * gl_FragCoord.xy + iResolution.xy) / iResolution.y;
    
                float2 uv0 = uv;

                float3 finalColor = float3(0,0,0);

                uv/=(length((uv)));

                for (float i = 0.0; i < 15.0; i++) 
                {
                    uv/=dot((uv.x,10.), (uv.y,0.5));
      
                    uv = frac(atan(uv) * 5.5) - 0.5;
                    
                    uv*=(length((uv)));
                    
                    float d = length(uv) * exp(-length(uv0));

                    float3 col = palette(length(uv0) + i*.4 + iTime*.4);

                    d = sin(d*8. + iTime)/8.;
                    
                    d = abs(d);

                    d = pow(0.01 / d, 1.2);

                    finalColor += col * d;
                }    

                return float4(finalColor, 1.0);
                
                /*
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
                */
            }
            ENDCG
        }
    }
}
