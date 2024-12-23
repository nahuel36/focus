Shader "Lab36/Kalei"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Alpha ("Alpha",float) = 0.0

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
            #define PI  3.1415926535897932384626
            #define TAU (2. * PI)
            #define PHI 1.6180339887498948482045
            #define EPSILON 0.01

            #define pos(x) ((x) * .5 + .5)
            #define rot(a) mat2(cos(a), -sin(a), sin(a), cos(a))
            #define sat(x) clamp(x, 0., 1.)

            #define iResolution _ScreenParams
            #define gl_FragCoord ((_iParam.scrPos.xy/_iParam.scrPos.w) * _ScreenParams.xy)
            float _Alpha;

            float3 cos_palette(float3 a, float3 b, float3 c, float3 d, float x) 
            {
                return a + b * cos(TAU * (c * x + d));
            }

            float3 rainbow(float x) 
            {
                return cos_palette(float3(.5,.5,.5), float3(.5,.5,.5), float3(1.,1.,1.), float3(0., .33, .66), x);
            }

            float hash11(float seed) 
            {
                return frac(sin(seed * 123.456) * 123.456);
            }

            float _seed;

            float rand(void) 
            {
                return hash11(_seed++);
            }

            float one_periodic(float x) 
            {
                return sin(TAU * x);
            }


            // Function to create a kaleidoscopic effect
            float2 kaleidoscope(float2 uv, float segments) 
            {
                float angle = atan2(uv.y, uv.x);
                float radius = length(uv);
                angle = fmod(angle, TAU / segments);
                angle = abs(angle - TAU / segments / 2.);
                return float2(cos(angle), sin(angle)) * radius;
            }

            float fractal(float2 uv) {
                float s = 1.0;
                float d = 0.0;
                for (int i = 0; i < 5; i++) {
                    d += abs(sin(uv.x * s + t) * cos(uv.y * s + t)) / s;
                    s *= 2.0;
                    uv *= 1.5;
                }
                return d;
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
                float multiplier = (((step(0.5,_iParam.scrPos.y)) * 2.0) - 1.0);
                
                float2 uv = (multiplier * 2 * gl_FragCoord.xy - iResolution.xy * multiplier) / iResolution.y;

                _seed = t + tex2D(_MainTex, uv).y;
    
                // Apply kaleidoscopic transformation
                uv = kaleidoscope(uv, 6.0);

                // Fractal-like background pattern
                float pattern = fractal(uv * 5.0);

                // Color based on fractal pattern
                float3 color = rainbow(pattern * 2.0 + t * 0.1);

                // Adding some distortion and motion
                uv *= 12.0;
                float2 id = floor(uv);
                uv = fmod(uv, 1.0) - 0.5;
                float wave = sin(dot(id, float2(1.0,1.0)) + t) * 0.5 + 0.5;

                // Mix colors with a pattern-based factor
                color = lerp(color, rainbow(wave + pattern), 0.5 * sin(t * 2.0 + wave));

                float black_and_white = (color.r + color.g + color.b)/3;


                black_and_white = black_and_white + 0.3;//brillo

                black_and_white = pow(black_and_white,9);//contraste

                color = float3(black_and_white,black_and_white,black_and_white);

                return float4(color * _Alpha, 1.0);
                
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
