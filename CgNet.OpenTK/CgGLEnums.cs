﻿/*
 CgNet v1.0
 Copyright (c) 2010 Tobias Bohnen

 Permission is hereby granted, free of charge, to any person obtaining a copy of this
 software and associated documentation files (the "Software"), to deal in the Software
 without restriction, including without limitation the rights to use, copy, modify, merge,
 publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
 to whom the Software is furnished to do so, subject to the following conditions:

 The above copyright notice and this permission notice shall be included in all copies or
 substantial portions of the Software.

 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
 PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
 FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
 OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
 DEALINGS IN THE SOFTWARE.
 */
namespace CgNet.GL
{
    #region Enumerations

    public enum CgGLAll
    {
        MatrixIdentity = 0,
        MatrixTranspose = 1,
        MatrixInverse = 2,
        MatrixInverseTranspose = 3,
        ModelviewMatrix = 4,
        ProjectionMatrix = 5,
        TextureMatrix = 6,
        ModelviewProjectionMatrix = 7,
        Vertex = 8,
        Fragment = 9,
        Geometry = 10,
        TessellationControl = 11,
        TessellationEvaluation = 12
    }

    public enum GlslVersion
    {
        Default = 0,
        Glsl_100     = 1,
        Glsl_110     = 2,
        Glsl_120     = 3
    }

    public enum MatrixTransform
    {
        MatrixIdentity = 0,
        MatrixTranspose = 1,
        MatrixInverse = 2,
        MatrixInverseTranspose = 3,
    }

    public enum MatrixType
    {
        ModelviewMatrix = 4,
        ProjectionMatrix = 5,
        TextureMatrix = 6,
        ModelviewProjectionMatrix = 7,
    }

    public enum ProfileClass
    {
        Vertex = 8,
        Fragment = 9,
        Geometry = 10,
        TessellationControl = 11,
        TessellationEvaluation = 12
    }

    #endregion Enumerations
}