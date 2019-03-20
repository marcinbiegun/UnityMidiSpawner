Shader "Custom/VertexMovement" {
 Properties{
 _Color("Color", Color) = (1,1,1,1)
 _MainTex("Albedo (RGB)", 2D) = "white" {}
 
 _Amount("Amount", Range(0,1)) = 0 //slider
 _DisplacementTexture("Displacement Texture", 2D) = "white"{} //displacement texture
 }
 
 SubShader{
 Tags { "RenderType" = "Opaque" }
 
 CGPROGRAM
 #pragma surface surf Standard fullforwardshadows vertex:vert
 
 sampler2D _MainTex;
 
 struct Input {
 float2 uv_MainTex;
 float displacementValue; //stores how much we've displaced the object
 };
 
 fixed4 _Color;
 float _Amount;
 sampler2D _DisplacementTexture;
 
 void vert(inout appdata_full v, out Input o) {
 
 //How much we expand, based on our DisplacementTexture
 float value = tex2Dlod(_DisplacementTexture, v.texcoord*7).x * _Amount;
 v.vertex.xyz += v.normal.xyz * value * .3; //Expand
 
 UNITY_INITIALIZE_OUTPUT(Input, o);
 o.displacementValue = value; //Pass this info to the surface shader
 }
 
 void surf(Input IN, inout SurfaceOutputStandard o) {
 
 fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
 
 o.Albedo = lerp(c.rgb * c.a, float3(0, 0, 0), IN.displacementValue); //lerp based on the displacement
 
 o.Alpha = c.a;
 }
 ENDCG
 }
 
 FallBack "Diffuse"
}
 