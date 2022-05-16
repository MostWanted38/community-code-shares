using System;
using System.Collections.Generic;
using UnityEngine;

namespace MostWanted38.Stream.CodeShare
{
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(MeshFilter))]
    public class QuadMeshGeneratorBehaviour : MonoBehaviour
    {
        public MeshRenderer MeshRenderer;
        public MeshFilter MeshFilter;

        public Mesh Mesh;
        public Vector3[] Vertices;
        public int[] Indices;
        public Vector2[] UVs;

        public void CreateSampleMesh()
        {
            Mesh = new Mesh();
            Vertices = new Vector3[4]
            {
                new Vector3(0, 0, 0), //Index 0 (Bottom-Left)
                new Vector3(2, 0, 0), //Index 1 (Bottom-Right)
                new Vector3(0, 2, 0), //Index 2 (Top-Left)
                new Vector3(2, 2, 0)  //Index 3 (Top-Right)
            };
            Indices = new int[4]
            {
                0, 2, 3, 1  //Bottom-Left, Top-Left, Top-Right, Bottom-Right (Clockwise!!!)
            };
            UVs = new Vector2[4]
            {
                new Vector2(0, 0), //UV Coord for Index 0
                new Vector2(1, 0), //UV Coord for Index 1
                new Vector2(0, 1), //UV Coord for Index 2
                new Vector2(1, 1)  //UV Coord for Index 3
            };

            Mesh.vertices = Vertices;
            Mesh.SetIndices(Indices, MeshTopology.Quads, 0);
            Mesh.uv = UVs;

            MeshFilter.mesh = Mesh;
            MeshFilter.sharedMesh = Mesh;
        }

        private void Awake()
        {
            MeshRenderer = this.GetComponent<MeshRenderer>();
            MeshFilter = this.GetComponent<MeshFilter>();
            CreateSampleMesh();
        }
    }
}