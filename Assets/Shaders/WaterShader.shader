﻿Shader "Custom/WaterShader"
{
    SubShader
    {
        //Tags { "RenderType"="Opaque" }
        //Tags { "Queue" = "Geometry" }
        //LOD 200
        
        Pass {
        
        GLSLPROGRAM
           
            #ifdef VERTEX
           
            void main()
            {
                gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
            }
           
            #endif
           
            #ifdef FRAGMENT
            
            // Found this on GLSL sandbox. I really liked it, changed a few things and made it tileable.
            // :)
            // by David Hoskins.

            // Water turbulence effect by joltz0r 2013-07-04, improved 2013-07-07

            // Redefine below to see the tiling...
            //#define SHOW_TILING

            #define TAU 6.28318530718
            #define MAX_ITER 5
            
            uniform float time;

           
            void main()
            {
                float time = time;// * .5+23.0;
                // uv should be the 0-1 uv of texture...
                vec2 uv = gl_FragCoord.xy / vec2(500,500);
        
                
                #ifdef SHOW_TILING
                    vec2 p = mod(uv*TAU*2.0, TAU)-250.0;
                #else
                    vec2 p = mod(uv*TAU, TAU)-250.0;
                #endif
                
                vec2 i = vec2(p);
                float c = 1.0;
                float inten = .005;

                for (int n = 0; n < MAX_ITER; n++) 
                {
                    float t = time * (1.0 - (3.5 / float(n+1)));
                    i = p + vec2(cos(t - i.x) + sin(t + i.y), sin(t - i.y) + cos(t + i.x));
                    c += 1.0/length(vec2(p.x / (sin(i.x+t)/inten),p.y / (cos(i.y+t)/inten)));
                }
                c /= float(MAX_ITER);
                c = 1.17-pow(c, 1.4);
                vec3 colour = vec3(pow(abs(c), 8.0));
                colour = clamp(colour + vec3(0.0, 0.35, 0.5), 0.0, 1.0);
                    
                gl_FragColor = vec4(colour, 1.0);
            }
           
            #endif
           
            ENDGLSL
            
        }
    }
    FallBack "Diffuse"
}
