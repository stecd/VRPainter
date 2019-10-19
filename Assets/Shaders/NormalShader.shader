Shader "Custom/NormalShader" {
    SubShader {
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
         
            struct v2f {
                float4 pos : SV_POSITION;
                fixed4 color : COLOR;
            };
            
            
            v2f vert (appdata_base v)
            {
                v2f o;
                float time = _Time.y;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.color.x = (abs(v.normal.x) + 1) + cos(time * 2);
                o.color.y = (abs(v.normal.y * 0.25) + 0.25);
                o.color.z = (abs(v.normal.z) + 1.5) + sin(time * 2);
                o.color.w = 1.0;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target { return i.color; }
            ENDCG
        }
    } 
}