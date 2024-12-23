Shader "Lab36/Twirl"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Alpha ("Alpha",float) = 0.0
        _OffsetY ("Offset y",float) = 0.0
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

            #define t   _Time

            #define pos(x) ((x) * .5 + .5)
            #define rot(a) mat2(cos(a), -sin(a), sin(a), cos(a))
            #define sat(x) clamp(x, 0., 1.)

            #define iResolution _ScreenParams
            #define gl_FragCoord ((_iParam.scrPos.xy/_iParam.scrPos.w) * _ScreenParams.xy)
            float _Alpha;
            float _OffsetY;

            #define uNumSticks 10.0
            #define uRotationSpeed 0.5
            #define uTwistAmount 10.0


            float Unity_SawtoothWave_float(float In)
            {
                return 2.0 * (In - floor(0.5 + In));
            }

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

            fixed4 frag (v2f _iParam) : SV_Target
            {
                _iParam.scrPos.y += _OffsetY;

                float multiplier = (((step(0.5,_iParam.scrPos.y)) * 2.0) - 1.0);
                
                float2 uv = (multiplier * 2 * gl_FragCoord.xy - iResolution.xy * multiplier) / iResolution.y;

                uv.x *= 1.75;
                uv.y *= 1.75;

                float radius = length(uv);
                float angle = atan2(uv.y, uv.x);

                float sint = sin(t*0.5)*0.1+0.9;    
                float sint2 = sin(t*10)*0.5+0.5;  

                // Apply twisting effect
                angle += radius * uTwistAmount + t*10 * uRotationSpeed;

                // Calculate stick index
                float stickIndex = fmod(angle * uNumSticks * sint/ (2.0 * 3.14159265), 1.0);

                // Create stripes
                //float stripe = step(1.-radius-0.15*sin(radius*25.), stickIndex);
                float stripe = 0.7-smoothstep(.7-radius-0.13*Unity_SawtoothWave_float(radius*sint2*19.),.7-radius-0.13000003*Unity_SawtoothWave_float(radius*19.), stickIndex);

                // Create the tunnel effect by fading the stripes with distance
                float tunnel = exp(-radius * 20 * (1- _Alpha*0.8));

                float3 color = float3(stripe * tunnel,stripe * tunnel,stripe * tunnel);

                return float4(color * _Alpha * 0.5, 1.0);
                
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
