/*
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
namespace CgNet.CgOO
{
    using System;

    using CgNet;

    internal static class CgOO
    {
        #region Methods

        #region Public Static Methods

        public static void ConnectParameter(IntPtr from, IntPtr to)
        {
            Cg.ConnectParameter(from, to);
        }

        public static IntPtr CreateArraySamplerState(CgContext context, string name, ParameterType type, int elementCount)
        {
            return Cg.CreateArraySamplerState(context.Handle, name, type, elementCount);
        }

        public static IntPtr CreateArrayState(CgContext context, string name, ParameterType type, int elementCount)
        {
            return Cg.CreateArrayState(context.Handle, name, type, elementCount);
        }

        public static IntPtr CreateEffectAnnotation(CgEffect effect, string name, ParameterType type)
        {
            return Cg.CreateEffectAnnotation(effect.Handle, name, type);
        }

        public static IntPtr CreateEffectParameter(CgContext context, string name, ParameterType type)
        {
            return Cg.CreateEffectParameter(context.Handle, name, type);
        }

        public static IntPtr CreateEffectParameterArray(CgEffect effect, string name, ParameterType type, int length)
        {
            return Cg.CreateEffectParameterArray(effect.Handle, name, type, length);
        }

        public static IntPtr CreateEffectParameterMultiDimArray(CgEffect effect, string name, ParameterType type, int dim, int[] lengths)
        {
            return Cg.CreateEffectParameterMultiDimArray(effect.Handle, name, type, dim, lengths);
        }

        public static IntPtr CreateObj(CgContext context, ProgramType programType, string source, ProfileType profile, params string[] args)
        {
            return Cg.CreateObj(context.Handle, programType, source, profile, args);
        }

        public static IntPtr CreateObjFromFile(CgContext context, ProgramType programType, string sourceFile, ProfileType profile, params string[] args)
        {
            return Cg.CreateObjFromFile(context.Handle, programType, sourceFile, profile, args);
        }

        public static IntPtr CreateParameter(CgContext context, ParameterType type)
        {
            return Cg.CreateParameter(context.Handle, type);
        }

        public static IntPtr CreateParameterAnnotation(CgParameter param, string name, ParameterType type)
        {
            return Cg.CreateParameterAnnotation(param.Handle, name, type);
        }

        public static IntPtr CreateParameterArray(CgContext context, ParameterType type, int length)
        {
            return Cg.CreateParameterArray(context.Handle, type, length);
        }

        public static IntPtr CreateParameterMultiDimArray(CgContext context, ParameterType type, int dim, int[] lengths)
        {
            return Cg.CreateParameterMultiDimArray(context.Handle, type, dim, lengths);
        }

        public static IntPtr CreatePassAnnotation(CgPass pass, string name, ParameterType type)
        {
            return Cg.CreatePassAnnotation(pass.Handle, name, type);
        }

        public static IntPtr CreateProgramAnnotation(CgProgram prog, string name, ParameterType type)
        {
            return Cg.CreateProgramAnnotation(prog.Handle, name, type);
        }

        public static IntPtr CreateSamplerState(CgContext context, string name, ParameterType type)
        {
            return Cg.CreateSamplerState(context.Handle, name, type);
        }

        public static IntPtr CreateSamplerStateAssignment(CgPass pass, CgState state)
        {
            return Cg.CreateSamplerStateAssignment(pass.Handle, state.Handle);
        }

        public static IntPtr CreateStateAssignment(CgPass pass, CgState state)
        {
            return Cg.CreateStateAssignment(pass.Handle, state.Handle);
        }

        public static IntPtr CreateStateAssignmentIndex(CgPass pass, CgState state, int index)
        {
            return Cg.CreateStateAssignmentIndex(pass.Handle, state.Handle, index);
        }

        public static IntPtr CreateTechniqueAnnotation(CgTechnique technique, string name, ParameterType type)
        {
            return Cg.CreateTechniqueAnnotation(technique.Handle, name, type);
        }

        public static void DestroyObj(IntPtr obj)
        {
            Cg.DestroyObj(obj);
        }

        public static string GetAnnotationName(IntPtr annotation)
        {
            return Cg.GetAnnotationName(annotation);
        }

        public static ParameterType GetAnnotationType(IntPtr annotation)
        {
            return Cg.GetAnnotationType(annotation);
        }

        public static IntPtr GetArrayParameter(IntPtr aparam, int index)
        {
            return Cg.GetArrayParameter(aparam, index);
        }

        public static bool[] GetBoolAnnotationValues(IntPtr annotation)
        {
            return Cg.GetBoolAnnotationValues(annotation);
        }

        public static bool[] GetBoolStateAssignmentValues(IntPtr stateassignment)
        {
            return Cg.GetBoolStateAssignmentValues(stateassignment);
        }

        public static IntPtr GetConnectedStateAssignmentParameter(IntPtr sa)
        {
            return Cg.GetConnectedStateAssignmentParameter(sa);
        }

        public static IntPtr GetDependentAnnotationParameter(IntPtr annotation, int index)
        {
            return Cg.GetDependentAnnotationParameter(annotation, index);
        }

        public static IntPtr GetDependentProgramArrayStateAssignmentParameter(IntPtr sa, int index)
        {
            return Cg.GetDependentProgramArrayStateAssignmentParameter(sa, index);
        }

        public static IntPtr GetDependentStateAssignmentParameter(IntPtr stateassignment, int index)
        {
            return Cg.GetDependentStateAssignmentParameter(stateassignment, index);
        }

        public static IntPtr GetEffectParameterBySemantic(CgEffect effect, string name)
        {
            return Cg.GetEffectParameterBySemantic(effect.Handle, name);
        }

        public static IntPtr GetFirstEffectAnnotation(CgEffect effect)
        {
            return Cg.GetFirstEffectAnnotation(effect.Handle);
        }

        public static IntPtr GetFirstEffectParameter(CgEffect effect)
        {
            return Cg.GetFirstEffectParameter(effect.Handle);
        }

        public static IntPtr GetFirstLeafEffectParameter(CgEffect effect)
        {
            return Cg.GetFirstLeafEffectParameter(effect.Handle);
        }

        public static IntPtr GetFirstLeafParameter(CgProgram program, int nameSpace)
        {
            return Cg.GetFirstLeafParameter(program.Handle, nameSpace);
        }

        public static IntPtr GetFirstParameter(CgProgram prog, int nameSpace)
        {
            return Cg.GetFirstParameter(prog.Handle, nameSpace);
        }

        public static IntPtr GetFirstParameterAnnotation(CgParameter param)
        {
            return Cg.GetFirstParameterAnnotation(param.Handle);
        }

        public static IntPtr GetFirstPassAnnotation(CgPass pass)
        {
            return Cg.GetFirstPassAnnotation(pass.Handle);
        }

        public static IntPtr GetFirstProgramAnnotation(CgProgram prog)
        {
            return Cg.GetFirstProgramAnnotation(prog.Handle);
        }

        public static IntPtr GetFirstSamplerStateAssignment(CgParameter param)
        {
            return Cg.GetFirstSamplerStateAssignment(param.Handle);
        }

        public static IntPtr GetFirstStateAssignment(CgPass pass)
        {
            return Cg.GetFirstStateAssignment(pass.Handle);
        }

        public static IntPtr GetFirstTechniqueAnnotation(CgTechnique technique)
        {
            return Cg.GetFirstTechniqueAnnotation(technique.Handle);
        }

        public static float[] GetFloatAnnotationValues(IntPtr annotation, out int nvalues)
        {
            return Cg.GetFloatAnnotationValues(annotation, out nvalues);
        }

        public static float[] GetFloatStateAssignmentValues(IntPtr stateassignment, int[] nVals)
        {
            return Cg.GetFloatStateAssignmentValues(stateassignment, nVals);
        }

        public static int[] GetIntAnnotationValues(IntPtr annotation, out int nvalues)
        {
            return Cg.GetIntAnnotationValues(annotation, out nvalues);
        }

        public static int[] GetIntStateAssignmentValues(IntPtr stateassignment, int[] nVals)
        {
            return Cg.GetIntStateAssignmentValues(stateassignment, nVals);
        }

        public static IntPtr GetNamedEffectAnnotation(CgEffect effect, string name)
        {
            return Cg.GetNamedEffectAnnotation(effect.Handle, name);
        }

        public static IntPtr GetNamedParameter(CgProgram program, string parameter)
        {
            return Cg.GetNamedParameter(program.Handle, parameter);
        }

        public static IntPtr GetNamedParameterAnnotation(CgParameter param, string name)
        {
            return Cg.GetNamedParameterAnnotation(param.Handle, name);
        }

        public static IntPtr GetNamedPassAnnotation(CgPass pass, string name)
        {
            return Cg.GetNamedPassAnnotation(pass.Handle, name);
        }

        public static IntPtr GetNamedProgramAnnotation(CgProgram prog, string name)
        {
            return Cg.GetNamedProgramAnnotation(prog.Handle, name);
        }

        public static IntPtr GetNamedProgramParameter(CgProgram prog, ProgramNamespace nameSpace, string name)
        {
            return Cg.GetNamedProgramParameter(prog.Handle, nameSpace, name);
        }

        public static IntPtr GetNamedSamplerStateAssignment(CgParameter param, string name)
        {
            return Cg.GetNamedSamplerStateAssignment(param.Handle, name);
        }

        public static IntPtr GetNamedStateAssignment(CgPass pass, string name)
        {
            return Cg.GetNamedStateAssignment(pass.Handle, name);
        }

        public static IntPtr GetNamedTechniqueAnnotation(CgTechnique technique, string name)
        {
            return Cg.GetNamedTechniqueAnnotation(technique.Handle, name);
        }

        public static IntPtr GetNextAnnotation(IntPtr annotation)
        {
            return Cg.GetNextAnnotation(annotation);
        }

        public static IntPtr GetNextLeafParameter(IntPtr currentParam)
        {
            return Cg.GetNextLeafParameter(currentParam);
        }

        public static IntPtr GetNextParameter(IntPtr currentParam)
        {
            return Cg.GetNextParameter(currentParam);
        }

        public static IntPtr GetNextStateAssignment(IntPtr stateassignment)
        {
            return Cg.GetNextStateAssignment(stateassignment);
        }

        public static int GetNumDependentAnnotationParameters(IntPtr annotation)
        {
            return Cg.GetNumDependentAnnotationParameters(annotation);
        }

        public static int GetNumDependentProgramArrayStateAssignmentParameters(IntPtr sa)
        {
            return Cg.GetNumDependentProgramArrayStateAssignmentParameters(sa);
        }

        public static int GetNumDependentStateAssignmentParameters(IntPtr stateassignment)
        {
            return Cg.GetNumDependentStateAssignmentParameters(stateassignment);
        }

        public static IntPtr GetProgramStateAssignmentValue(IntPtr stateassignment)
        {
            return Cg.GetProgramStateAssignmentValue(stateassignment);
        }

        public static IntPtr GetSamplerStateAssignmentParameter(IntPtr stateassignment)
        {
            return Cg.GetSamplerStateAssignmentParameter(stateassignment);
        }

        public static IntPtr GetSamplerStateAssignmentState(IntPtr stateassignment)
        {
            return Cg.GetSamplerStateAssignmentState(stateassignment);
        }

        public static IntPtr GetSamplerStateAssignmentValue(IntPtr stateassignment)
        {
            return Cg.GetSamplerStateAssignmentValue(stateassignment);
        }

        public static int GetStateAssignmentIndex(IntPtr stateassignment)
        {
            return Cg.GetStateAssignmentIndex(stateassignment);
        }

        public static IntPtr GetStateAssignmentPass(IntPtr stateassignment)
        {
            return Cg.GetStateAssignmentPass(stateassignment);
        }

        public static IntPtr GetStateAssignmentState(IntPtr stateassignment)
        {
            return Cg.GetStateAssignmentState(stateassignment);
        }

        public static string GetStringAnnotationValue(IntPtr annotation)
        {
            return Cg.GetStringAnnotationValue(annotation);
        }

        public static string[] GetStringAnnotationValues(IntPtr ann)
        {
            return Cg.GetStringAnnotationValues(ann);
        }

        public static string GetStringStateAssignmentValue(IntPtr stateassignment)
        {
            return Cg.GetStringStateAssignmentValue(stateassignment);
        }

        public static IntPtr GetTextureStateAssignmentValue(IntPtr stateassignment)
        {
            return Cg.GetTextureStateAssignmentValue(stateassignment);
        }

        public static bool IsAnnotation(IntPtr annotation)
        {
            return Cg.IsAnnotation(annotation);
        }

        public static bool IsParameterUsed(CgParameter param, IntPtr handle)
        {
            return Cg.IsParameterUsed(param.Handle, handle);
        }

        public static bool IsStateAssignment(IntPtr stateassignment)
        {
            return Cg.IsStateAssignment(stateassignment);
        }

        public static bool SetAnnotation(IntPtr ann, int value)
        {
            return Cg.SetAnnotation(ann, value);
        }

        public static bool SetAnnotation(IntPtr ann, float value)
        {
            return Cg.SetAnnotation(ann, value);
        }

        public static bool SetAnnotation(IntPtr ann, string value)
        {
            return Cg.SetAnnotation(ann, value);
        }

        public static bool SetBoolAnnotation(IntPtr annotation, bool value)
        {
            return Cg.SetBoolAnnotation(annotation, value);
        }

        public static bool SetProgramStateAssignment(IntPtr stateassignment, CgProgram program)
        {
            return Cg.SetProgramStateAssignment(stateassignment, program.Handle);
        }

        public static bool SetSamplerStateAssignment(IntPtr stateassignment, CgParameter param)
        {
            return Cg.SetSamplerStateAssignment(stateassignment, param.Handle);
        }

        public static bool SetStateAssignment(IntPtr stateassignment, float value)
        {
            return Cg.SetStateAssignment(stateassignment, value);
        }

        public static bool SetStateAssignment(IntPtr stateassignment, int value)
        {
            return Cg.SetStateAssignment(stateassignment, value);
        }

        public static bool SetStateAssignment(IntPtr stateassignment, bool value)
        {
            return Cg.SetStateAssignment(stateassignment, value);
        }

        public static bool SetStateAssignment(IntPtr stateassignment, string value)
        {
            return Cg.SetStateAssignment(stateassignment, value);
        }

        public static bool SetStateAssignment(IntPtr stateassignment, float[] value)
        {
            return Cg.SetStateAssignment(stateassignment, value);
        }

        public static bool SetStateAssignment(IntPtr stateassignment, int[] value)
        {
            return Cg.SetStateAssignment(stateassignment, value);
        }

        public static bool SetStateAssignment(IntPtr stateassignment, bool[] value)
        {
            return Cg.SetStateAssignment(stateassignment, value);
        }

        public static bool SetTextureStateAssignment(IntPtr stateassignment, CgParameter param)
        {
            return Cg.SetTextureStateAssignment(stateassignment, param.Handle);
        }

        #endregion Public Static Methods

        #endregion Methods
    }
}