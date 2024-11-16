Shader "Lab36/Kalei"
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

            #define t   _Time
            #define PI  3.1415926535897932384626
            #define TAU (2. * PI)
            #define PHI 1.6180339887498948482045
            #define EPSILON 0.01

            #define pos(x) ((x) * .5 + .5)
            #define rot(a) mat2(cos(a), -sin(a), sin(a), cos(a))
            #define sat(x) clamp(x, 0., 1.)


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
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                
                float2 uv = i.uv;
                _seed = t + tex2D(_MainTex, uv).x;
    
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
    
                return float4(color, 1.0);
                                
                
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
