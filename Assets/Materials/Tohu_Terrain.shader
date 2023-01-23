Shader "Tohu Bohu/Terrain"
{
    Properties
    {
        UPTexture ("Up texture", 2D) = "white" {}
        FrontTexture ("Front texture", 2D) = "white" {}
        Threshold("Threshold",Range(0,1)) = 0.5
    }
    SubShader
    {
         Tags 
        {
            "RenderType"="Opaque"
            "LightMode" = "UniversalForward" 
            "PassFlags" = "OnlyDirectional"
            "RenderPipeline" = "UniversalPipeline"
        } 
        LOD 100

        Pass
        {
            HLSLPROGRAM
           #pragma vertex vert
            #pragma fragment frag
           	#pragma multi_compile_fwdbase
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS

            //#include "UnityCG.cginc"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 normal : TEXCOORD2;
                float4 shadowCoord : TEXCOORD3;
            };

            sampler2D UPTexture;
            float4 UPTexture_ST;

            sampler2D FrontTexture;
            float4 FrontTexture_ST;

            float Threshold;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = TransformObjectToHClip(v.vertex);
                o.uv = v.uv;
                o.normal =v.normal;
                
                float3 worldPos = GetVertexPositionInputs(v.vertex.xyz).positionWS;
                o.shadowCoord = TransformWorldToShadowCoord(worldPos);
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                // sample the texture
                float4 tex1 = tex2D(UPTexture, i.uv * UPTexture_ST.xy + UPTexture_ST.zw );
                float4 tex2 = tex2D(FrontTexture, i.uv * FrontTexture_ST.xy + FrontTexture_ST.zw );

                Light mainLight = GetMainLight(i.shadowCoord);
                 float shadow = mainLight.shadowAttenuation;
                
                float N = 1- saturate( dot(normalize(i.normal),float3(0,1,0)));
                N = smoothstep(Threshold,Threshold + 0.01,N);
                
                float3 col = lerp(tex1,tex2,N.x);

                shadow = saturate(shadow);
                    
                return float4(col,1);
            }
            ENDHLSL
        }
        UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
    }
}
