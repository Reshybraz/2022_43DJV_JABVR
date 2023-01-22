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
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float3 normal : TEXCOORD2;
            };

            sampler2D UPTexture;
            float4 UPTexture_ST;

            sampler2D FrontTexture;
            float4 FrontTexture_ST;

            float Threshold;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.normal =v.normal;
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 tex1 = tex2D(UPTexture, i.uv * UPTexture_ST.xy + UPTexture_ST.zw );
                fixed4 tex2 = tex2D(FrontTexture, i.uv * FrontTexture_ST.xy + FrontTexture_ST.zw );
                
                float N = 1- saturate( dot(normalize(i.normal),float3(0,1,0)));
                N = smoothstep(Threshold,Threshold + 0.01,N);
                
                float3 col = lerp(tex1,tex2,N.x);

      
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return float4(col,1);
            }
            ENDCG
        }
    }
}
