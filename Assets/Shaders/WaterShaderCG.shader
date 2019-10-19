Shader "Custom/WaterShaderCG"
{
    SubShader
    {
        //Tags { "RenderType"="Opaque" }
        //Tags { "Queue" = "Geometry" }
        //LOD 200
        
        Pass {
        
        CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
            
           // adapted from code by David Hoskins on Shadertoy
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _TintColor;
            float _Transparency;
            float _CutoutThresh;
            float _Distance;
            float _Amplitude;
            float _Speed;
            float _Amount;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            #define TAU 6.28318530718
            #define MAX_ITER 5

            float4 frag (v2f i) : SV_Target
            {
                float time = _Time.y * .5+23.0;
                float2 uv = i.uv;// / float2(0.5,0.5);//_ScreenParams.xy;
                
                #ifdef SHOW_TILING
                    float2 p = fmod(uv*TAU*2.0, TAU)-250.0;
                #else
                    float2 p = fmod(uv*TAU, TAU)-250.0;
                #endif
                
                float2 p2 = p;
                float c = 1.0;
                float inten = .005;
                
                for (int n = 0; n < MAX_ITER; n++) 
                {
                    float t = time * (1.0 - (3.5 / float(n+1)));
                    p2 = p + float2(cos(t - p2.x) + sin(t + p2.y), sin(t - p2.y) + cos(t + p2.x));
                    c += 1.0/length(float2(p.x / (sin(p2.x+t)/inten),p.y / (cos(p2.y+t)/inten)));
                }
                c /= float(MAX_ITER);
                c = 1.17-pow(c, 1.4);
                float x = pow(abs(c), 8.0);
                float3 colour = float3(x, x, x);
                colour = clamp(colour + float3(0.0, 0.35, 0.5), 0.0, 1.0);
               
                
                // sample the texture
                return float4(colour, 1.0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
