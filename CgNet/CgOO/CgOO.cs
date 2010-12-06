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

        public static void AddStateEnumerant(IntPtr state, string name, int value)
        {
            Cg.AddStateEnumerant(state, name, value);
        }

        public static bool CallStateResetCallback(IntPtr stateassignment)
        {
            return Cg.CallStateResetCallback(stateassignment);
        }

        public static bool CallStateSetCallback(IntPtr stateassignment)
        {
            return Cg.CallStateSetCallback(stateassignment);
        }

        public static bool CallStateValidateCallback(IntPtr stateassignment)
        {
            return Cg.CallStateValidateCallback(stateassignment);
        }

        public static void ConnectParameter(IntPtr from, IntPtr to)
        {
            Cg.ConnectParameter(from, to);
        }

        public static IntPtr CopyEffect(IntPtr effect)
        {
            return Cg.CopyEffect(effect);
        }

        public static IntPtr CreateArraySamplerState(CgContext context, string name, ParameterType type, int elementCount)
        {
            return Cg.CreateArraySamplerState(context.Handle, name, type, elementCount);
        }

        public static IntPtr CreateArrayState(CgContext context, string name, ParameterType type, int elementCount)
        {
            return Cg.CreateArrayState(context.Handle, name, type, elementCount);
        }

        public static IntPtr CreateBuffer(CgContext context, int size, IntPtr data, BufferUsage bufferUsage)
        {
            return Cg.CreateBuffer(context.Handle, size, data, bufferUsage);
        }

        public static IntPtr CreateEffect(CgContext context, string code, params string[] args)
        {
            return Cg.CreateEffect(context.Handle, code, args);
        }

        public static IntPtr CreateEffectAnnotation(IntPtr effect, string name, ParameterType type)
        {
            return Cg.CreateEffectAnnotation(effect, name, type);
        }

        public static IntPtr CreateEffectFromFile(CgContext context, string filename, params string[] args)
        {
            return Cg.CreateEffectFromFile(context.Handle, filename, args);
        }

        public static IntPtr CreateEffectParameter(CgContext context, string name, ParameterType type)
        {
            return Cg.CreateEffectParameter(context.Handle, name, type);
        }

        public static IntPtr CreateEffectParameterArray(IntPtr effect, string name, ParameterType type, int length)
        {
            return Cg.CreateEffectParameterArray(effect, name, type, length);
        }

        public static IntPtr CreateEffectParameterMultiDimArray(IntPtr effect, string name, ParameterType type, int dim, int[] lengths)
        {
            return Cg.CreateEffectParameterMultiDimArray(effect, name, type, dim, lengths);
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

        public static IntPtr CreateParameterAnnotation(IntPtr param, string name, ParameterType type)
        {
            return Cg.CreateParameterAnnotation(param, name, type);
        }

        public static IntPtr CreateParameterArray(CgContext context, ParameterType type, int length)
        {
            return Cg.CreateParameterArray(context.Handle, type, length);
        }

        public static IntPtr CreateParameterMultiDimArray(CgContext context, ParameterType type, int dim, int[] lengths)
        {
            return Cg.CreateParameterMultiDimArray(context.Handle, type, dim, lengths);
        }

        public static IntPtr CreatePass(IntPtr tech, string name)
        {
            return Cg.CreatePass(tech, name);
        }

        public static IntPtr CreatePassAnnotation(IntPtr pass, string name, ParameterType type)
        {
            return Cg.CreatePassAnnotation(pass, name, type);
        }

        public static IntPtr CreateProgramAnnotation(CgProgram prog, string name, ParameterType type)
        {
            return Cg.CreateProgramAnnotation(prog.Handle, name, type);
        }

        public static CgProgram CreateProgramFromEffect(IntPtr effect, ProfileType profile, string entry, params string[] args)
        {
            return new CgProgram(Cg.CreateProgramFromEffect(effect, profile, entry, args));
        }

        public static IntPtr CreateSamplerState(CgContext context, string name, ParameterType type)
        {
            return Cg.CreateSamplerState(context.Handle, name, type);
        }

        public static IntPtr CreateSamplerStateAssignment(IntPtr pass, IntPtr state)
        {
            return Cg.CreateSamplerStateAssignment(pass, state);
        }

        public static IntPtr CreateState(CgContext context, string name, ParameterType type)
        {
            return Cg.CreateState(context.Handle, name, type);
        }

        public static IntPtr CreateStateAssignment(IntPtr pass, IntPtr state)
        {
            return Cg.CreateStateAssignment(pass, state);
        }

        public static IntPtr CreateStateAssignmentIndex(IntPtr pass, IntPtr state, int index)
        {
            return Cg.CreateStateAssignmentIndex(pass, state, index);
        }

        public static IntPtr CreateTechnique(IntPtr effect, string name)
        {
            return Cg.CreateTechnique(effect, name);
        }

        public static IntPtr CreateTechniqueAnnotation(IntPtr tech, string name, ParameterType type)
        {
            return Cg.CreateTechniqueAnnotation(tech, name, type);
        }

        public static void DestroyBuffer(IntPtr buffer)
        {
            Cg.DestroyBuffer(buffer);
        }

        public static void DestroyEffect(IntPtr effect)
        {
            Cg.DestroyEffect(effect);
        }

        public static void DestroyObj(IntPtr obj)
        {
            Cg.DestroyObj(obj);
        }

        public static void DestroyParameter(IntPtr param)
        {
            Cg.DestroyParameter(param);
        }

        public static void DisconnectParameter(IntPtr param)
        {
            Cg.DisconnectParameter(param);
        }

        public static string GetAnnotationName(IntPtr annotation)
        {
            return Cg.GetAnnotationName(annotation);
        }

        public static ParameterType GetAnnotationType(IntPtr annotation)
        {
            return Cg.GetAnnotationType(annotation);
        }

        public static int GetArrayDimension(IntPtr param)
        {
            return Cg.GetArrayDimension(param);
        }

        public static IntPtr GetArrayParameter(IntPtr aparam, int index)
        {
            return Cg.GetArrayParameter(aparam, index);
        }

        public static int GetArraySize(IntPtr param, int dimension)
        {
            return Cg.GetArraySize(param, dimension);
        }

        public static int GetArrayTotalSize(IntPtr param)
        {
            return Cg.GetArrayTotalSize(param);
        }

        public static ParameterType GetArrayType(IntPtr param)
        {
            return Cg.GetArrayType(param);
        }

        public static bool[] GetBoolAnnotationValues(IntPtr annotation)
        {
            return Cg.GetBoolAnnotationValues(annotation);
        }

        public static bool[] GetBoolStateAssignmentValues(IntPtr stateassignment)
        {
            return Cg.GetBoolStateAssignmentValues(stateassignment);
        }

        public static int GetBufferSize(IntPtr buffer)
        {
            return Cg.GetBufferSize(buffer);
        }

        public static IntPtr GetConnectedParameter(IntPtr param)
        {
            return Cg.GetConnectedParameter(param);
        }

        public static IntPtr GetConnectedStateAssignmentParameter(IntPtr sa)
        {
            return Cg.GetConnectedStateAssignmentParameter(sa);
        }

        public static IntPtr GetConnectedToParameter(IntPtr param, int index)
        {
            return Cg.GetConnectedToParameter(param, index);
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

        public static IntPtr GetEffectContext(IntPtr effect)
        {
            return Cg.GetEffectContext(effect);
        }

        public static string GetEffectName(IntPtr effect)
        {
            return Cg.GetEffectName(effect);
        }

        public static IntPtr GetEffectParameterBuffer(IntPtr param)
        {
            return Cg.GetEffectParameterBuffer(param);
        }

        public static IntPtr GetEffectParameterBySemantic(IntPtr effect, string name)
        {
            return Cg.GetEffectParameterBySemantic(effect, name);
        }

        public static IntPtr GetFirstDependentParameter(IntPtr param)
        {
            return Cg.GetFirstDependentParameter(param);
        }

        public static IntPtr GetFirstEffect(CgContext context)
        {
            return Cg.GetFirstEffect(context.Handle);
        }

        public static IntPtr GetFirstEffectAnnotation(IntPtr effect)
        {
            return Cg.GetFirstEffectAnnotation(effect);
        }

        public static IntPtr GetFirstEffectParameter(IntPtr effect)
        {
            return Cg.GetFirstEffectParameter(effect);
        }

        public static IntPtr GetFirstLeafEffectParameter(IntPtr effect)
        {
            return Cg.GetFirstLeafEffectParameter(effect);
        }

        public static IntPtr GetFirstLeafParameter(CgProgram program, int nameSpace)
        {
            return Cg.GetFirstLeafParameter(program.Handle, nameSpace);
        }

        public static IntPtr GetFirstParameter(CgProgram prog, int nameSpace)
        {
            return Cg.GetFirstParameter(prog.Handle, nameSpace);
        }

        public static IntPtr GetFirstParameterAnnotation(IntPtr param)
        {
            return Cg.GetFirstParameterAnnotation(param);
        }

        public static IntPtr GetFirstPass(IntPtr technique)
        {
            return Cg.GetFirstPass(technique);
        }

        public static IntPtr GetFirstPassAnnotation(IntPtr pass)
        {
            return Cg.GetFirstPassAnnotation(pass);
        }

        public static IntPtr GetFirstProgramAnnotation(CgProgram prog)
        {
            return Cg.GetFirstProgramAnnotation(prog.Handle);
        }

        public static IntPtr GetFirstSamplerState(CgContext context)
        {
            return Cg.GetFirstSamplerState(context.Handle);
        }

        public static IntPtr GetFirstSamplerStateAssignment(IntPtr param)
        {
            return Cg.GetFirstSamplerStateAssignment(param);
        }

        public static IntPtr GetFirstState(CgContext context)
        {
            return Cg.GetFirstState(context.Handle);
        }

        public static IntPtr GetFirstStateAssignment(IntPtr pass)
        {
            return Cg.GetFirstStateAssignment(pass);
        }

        public static IntPtr GetFirstStructParameter(IntPtr param)
        {
            return Cg.GetFirstStructParameter(param);
        }

        public static IntPtr GetFirstTechnique(IntPtr effect)
        {
            return Cg.GetFirstTechnique(effect);
        }

        public static IntPtr GetFirstTechniqueAnnotation(IntPtr technique)
        {
            return Cg.GetFirstTechniqueAnnotation(technique);
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

        public static void GetMatrixParameter(IntPtr param, out int[] values)
        {
            Cg.GetMatrixParameter(param, out values);
        }

        public static void GetMatrixParameter(IntPtr param, out float[] values)
        {
            Cg.GetMatrixParameter(param, out values);
        }

        public static void GetMatrixParameter(IntPtr param, out double[] values)
        {
            Cg.GetMatrixParameter(param, out values);
        }

        public static T[] GetMatrixParameter<T>(IntPtr param)
            where T : struct
        {
            return Cg.GetMatrixParameter<T>(param);
        }

        public static T[] GetMatrixParameter<T>(IntPtr param, Order order)
            where T : struct
        {
            return Cg.GetMatrixParameter<T>(param, order);
        }

        public static Order GetMatrixParameterOrder(IntPtr param)
        {
            return Cg.GetMatrixParameterOrder(param);
        }

        public static IntPtr GetNamedEffect(CgContext context, string name)
        {
            return Cg.GetNamedEffect(context.Handle, name);
        }

        public static IntPtr GetNamedEffectAnnotation(IntPtr effect, string name)
        {
            return Cg.GetNamedEffectAnnotation(effect, name);
        }

        public static IntPtr GetNamedEffectParameter(IntPtr effect, string name)
        {
            return Cg.GetNamedEffectParameter(effect, name);
        }

        public static IntPtr GetNamedParameter(CgProgram program, string parameter)
        {
            return Cg.GetNamedParameter(program.Handle, parameter);
        }

        public static IntPtr GetNamedParameterAnnotation(IntPtr param, string name)
        {
            return Cg.GetNamedParameterAnnotation(param, name);
        }

        public static IntPtr GetNamedPass(IntPtr technique, string name)
        {
            return Cg.GetNamedPass(technique, name);
        }

        public static IntPtr GetNamedPassAnnotation(IntPtr pass, string name)
        {
            return Cg.GetNamedPassAnnotation(pass, name);
        }

        public static IntPtr GetNamedProgramAnnotation(CgProgram prog, string name)
        {
            return Cg.GetNamedProgramAnnotation(prog.Handle, name);
        }

        public static IntPtr GetNamedProgramParameter(CgProgram prog, ProgramNamespace nameSpace, string name)
        {
            return Cg.GetNamedProgramParameter(prog.Handle, nameSpace, name);
        }

        public static IntPtr GetNamedSamplerState(CgContext context, string name)
        {
            return Cg.GetNamedSamplerState(context.Handle, name);
        }

        public static IntPtr GetNamedSamplerStateAssignment(IntPtr param, string name)
        {
            return Cg.GetNamedSamplerStateAssignment(param, name);
        }

        public static IntPtr GetNamedState(CgContext context, string name)
        {
            return Cg.GetNamedState(context.Handle, name);
        }

        public static IntPtr GetNamedStateAssignment(IntPtr pass, string name)
        {
            return Cg.GetNamedStateAssignment(pass, name);
        }

        public static IntPtr GetNamedStructParameter(IntPtr param, string name)
        {
            return Cg.GetNamedStructParameter(param, name);
        }

        public static IntPtr GetNamedSubParameter(IntPtr param, string name)
        {
            return Cg.GetNamedSubParameter(param, name);
        }

        public static IntPtr GetNamedTechnique(IntPtr effect, string name)
        {
            return Cg.GetNamedTechnique(effect, name);
        }

        public static IntPtr GetNamedTechniqueAnnotation(IntPtr technique, string name)
        {
            return Cg.GetNamedTechniqueAnnotation(technique, name);
        }

        public static ParameterType GetNamedUserType(IntPtr effect, string name)
        {
            return Cg.GetNamedUserType(effect, name);
        }

        public static IntPtr GetNextAnnotation(IntPtr annotation)
        {
            return Cg.GetNextAnnotation(annotation);
        }

        public static IntPtr GetNextEffect(IntPtr effect)
        {
            return Cg.GetNextEffect(effect);
        }

        public static IntPtr GetNextLeafParameter(IntPtr currentParam)
        {
            return Cg.GetNextLeafParameter(currentParam);
        }

        public static IntPtr GetNextParameter(IntPtr currentParam)
        {
            return Cg.GetNextParameter(currentParam);
        }

        public static IntPtr GetNextPass(IntPtr pass)
        {
            return Cg.GetNextPass(pass);
        }

        public static IntPtr GetNextState(IntPtr state)
        {
            return Cg.GetNextState(state);
        }

        public static IntPtr GetNextStateAssignment(IntPtr stateassignment)
        {
            return Cg.GetNextStateAssignment(stateassignment);
        }

        public static IntPtr GetNextTechnique(IntPtr technique)
        {
            return Cg.GetNextTechnique(technique);
        }

        public static int GetNumConnectedToParameters(IntPtr param)
        {
            return Cg.GetNumConnectedToParameters(param);
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

        public static int GetNumStateEnumerants(IntPtr state)
        {
            return Cg.GetNumStateEnumerants(state);
        }

        public static int GetNumUserTypes(IntPtr handle)
        {
            return Cg.GetNumUserTypes(handle);
        }

        public static int GetParameterBaseResource(IntPtr param)
        {
            return Cg.GetParameterBaseResource(param);
        }

        public static ParameterType GetParameterBaseType(IntPtr param)
        {
            return Cg.GetParameterBaseType(param);
        }

        public static int GetParameterBufferIndex(IntPtr param)
        {
            return Cg.GetParameterBufferIndex(param);
        }

        public static int GetParameterBufferOffset(IntPtr param)
        {
            return Cg.GetParameterBufferOffset(param);
        }

        public static int GetParameterClass(IntPtr param)
        {
            return Cg.GetParameterClass(param);
        }

        public static int GetParameterColumns(IntPtr param)
        {
            return Cg.GetParameterColumns(param);
        }

        public static IntPtr GetParameterContext(IntPtr param)
        {
            return Cg.GetParameterContext(param);
        }

        public static int GetParameterDefaultValue(IntPtr param, ref double[] values)
        {
            return Cg.GetParameterDefaultValue(param, ref values, Order.RowMajor);
        }

        public static int GetParameterDefaultValue(IntPtr param, ref double[] values, Order order)
        {
            return Cg.GetParameterDefaultValue(param, ref values, order);
        }

        public static int GetParameterDefaultValue(IntPtr param, ref int[] values)
        {
            return Cg.GetParameterDefaultValue(param, ref values, Order.RowMajor);
        }

        public static int GetParameterDefaultValue(IntPtr param, ref int[] values, Order order)
        {
            return Cg.GetParameterDefaultValue(param, ref values, order);
        }

        public static int GetParameterDefaultValue(IntPtr param, ref float[] values)
        {
            return Cg.GetParameterDefaultValue(param, ref values, Order.RowMajor);
        }

        public static int GetParameterDefaultValue(IntPtr param, ref float[] values, Order order)
        {
            return Cg.GetParameterDefaultValue(param, ref values, order);
        }

        public static int GetParameterDirection(IntPtr param)
        {
            return Cg.GetParameterDirection(param);
        }

        public static IntPtr GetParameterEffect(IntPtr param)
        {
            return Cg.GetParameterEffect(param);
        }

        public static int GetParameterIndex(IntPtr param)
        {
            return Cg.GetParameterIndex(param);
        }

        public static string GetParameterName(IntPtr param)
        {
            return Cg.GetParameterName(param);
        }

        public static ParameterType GetParameterNamedType(IntPtr param)
        {
            return Cg.GetParameterNamedType(param);
        }

        public static int GetParameterOrdinalNumber(IntPtr param)
        {
            return Cg.GetParameterOrdinalNumber(param);
        }

        public static IntPtr GetParameterProgram(IntPtr param)
        {
            return Cg.GetParameterProgram(param);
        }

        public static int GetParameterResource(IntPtr param)
        {
            return Cg.GetParameterResource(param);
        }

        public static int GetParameterResourceIndex(IntPtr param)
        {
            return Cg.GetParameterResourceIndex(param);
        }

        public static string GetParameterResourceName(IntPtr param)
        {
            return Cg.GetParameterResourceName(param);
        }

        public static int GetParameterResourceSize(IntPtr param)
        {
            return Cg.GetParameterResourceSize(param);
        }

        public static ParameterType GetParameterResourceType(IntPtr param)
        {
            return Cg.GetParameterResourceType(param);
        }

        public static int GetParameterRows(IntPtr param)
        {
            return Cg.GetParameterRows(param);
        }

        public static string GetParameterSemantic(IntPtr param)
        {
            return Cg.GetParameterSemantic(param);
        }

        public static ParameterType GetParameterType(IntPtr param)
        {
            return Cg.GetParameterType(param);
        }

        public static void GetParameterValue(IntPtr param, ref int[] values)
        {
            Cg.GetParameterValue(param, ref values, Order.RowMajor);
        }

        public static void GetParameterValue(IntPtr param, ref double[] values)
        {
            Cg.GetParameterValue(param, ref values, Order.RowMajor);
        }

        public static void GetParameterValue(IntPtr param, ref float[] values)
        {
            Cg.GetParameterValue(param, ref values, Order.RowMajor);
        }

        public static T GetParameterValue<T>(IntPtr param)
            where T : struct
        {
            return Cg.GetParameterValue<T>(param);
        }

        public static void GetParameterValue<T>(IntPtr param, ref T[] values)
            where T : struct
        {
            Cg.GetParameterValue(param, ref values, Order.RowMajor);
        }

        public static void GetParameterValue<T>(IntPtr param, ref T[] values, Order order)
            where T : struct
        {
            Cg.GetParameterValue(param, ref values, order);
        }

        public static int GetParameterVariability(IntPtr param)
        {
            return Cg.GetParameterVariability(param);
        }

        public static string GetPassName(IntPtr pass)
        {
            return Cg.GetPassName(pass);
        }

        public static IntPtr GetPassProgram(IntPtr pass, Domain domain)
        {
            return Cg.GetPassProgram(pass, domain);
        }

        public static IntPtr GetPassTechnique(IntPtr pass)
        {
            return Cg.GetPassTechnique(pass);
        }

        public static IntPtr GetProgramBuffer(CgProgram program, int bufferIndex)
        {
            return Cg.GetProgramBuffer(program.Handle, bufferIndex);
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

        public static IntPtr GetStateContext(IntPtr state)
        {
            return Cg.GetStateContext(state);
        }

        public static string GetStateEnumerant(IntPtr state, int index, out int value)
        {
            return Cg.GetStateEnumerant(state, index, out value);
        }

        public static string GetStateEnumerantName(IntPtr state, int index)
        {
            return Cg.GetStateEnumerantName(state, index);
        }

        public static int GetStateEnumerantValue(IntPtr state, string name)
        {
            return Cg.GetStateEnumerantValue(state, name);
        }

        public static ProfileType GetStateLatestProfile(IntPtr state)
        {
            return Cg.GetStateLatestProfile(state);
        }

        public static string GetStateName(IntPtr state)
        {
            return Cg.GetStateName(state);
        }

        public static Cg.CgStateCallbackDelegate GetStateResetCallback(IntPtr state)
        {
            return Cg.GetStateResetCallback(state);
        }

        public static Cg.CgStateCallbackDelegate GetStateSetCallback(IntPtr state)
        {
            return Cg.GetStateSetCallback(state);
        }

        public static ParameterType GetStateType(IntPtr state)
        {
            return Cg.GetStateType(state);
        }

        public static Cg.CgStateCallbackDelegate GetStateValidateCallback(IntPtr state)
        {
            return Cg.GetStateValidateCallback(state);
        }

        public static string GetStringAnnotationValue(IntPtr annotation)
        {
            return Cg.GetStringAnnotationValue(annotation);
        }

        public static string[] GetStringAnnotationValues(IntPtr ann)
        {
            return Cg.GetStringAnnotationValues(ann);
        }

        public static string GetStringParameterValue(IntPtr param)
        {
            return Cg.GetStringParameterValue(param);
        }

        public static string GetStringStateAssignmentValue(IntPtr stateassignment)
        {
            return Cg.GetStringStateAssignmentValue(stateassignment);
        }

        public static IntPtr GetTechniqueEffect(IntPtr technique)
        {
            return Cg.GetTechniqueEffect(technique);
        }

        public static string GetTechniqueName(IntPtr technique)
        {
            return Cg.GetTechniqueName(technique);
        }

        public static IntPtr GetTextureStateAssignmentValue(IntPtr stateassignment)
        {
            return Cg.GetTextureStateAssignmentValue(stateassignment);
        }

        public static ParameterType GetUserType(IntPtr effect, int index)
        {
            return Cg.GetUserType(effect, index);
        }

        public static bool IsAnnotation(IntPtr annotation)
        {
            return Cg.IsAnnotation(annotation);
        }

        public static bool IsEffect(IntPtr effect)
        {
            return Cg.IsEffect(effect);
        }

        public static bool IsParameter(IntPtr param)
        {
            return Cg.IsParameter(param);
        }

        public static bool IsParameterGlobal(IntPtr param)
        {
            return Cg.IsParameterGlobal(param);
        }

        public static bool IsParameterReferenced(IntPtr param)
        {
            return Cg.IsParameterReferenced(param);
        }

        public static bool IsParameterUsed(IntPtr param, IntPtr handle)
        {
            return Cg.IsParameterUsed(param, handle);
        }

        public static bool IsPass(IntPtr pass)
        {
            return Cg.IsPass(pass);
        }

        public static bool IsState(IntPtr state)
        {
            return Cg.IsState(state);
        }

        public static bool IsStateAssignment(IntPtr stateassignment)
        {
            return Cg.IsStateAssignment(stateassignment);
        }

        public static bool IsTechnique(IntPtr technique)
        {
            return Cg.IsTechnique(technique);
        }

        public static bool IsTechniqueValidated(IntPtr technique)
        {
            return Cg.IsTechniqueValidated(technique);
        }

        public static IntPtr MapBuffer(IntPtr buffer, BufferAccess access)
        {
            return Cg.MapBuffer(buffer, access);
        }

        public static void ResetPassState(IntPtr pass)
        {
            Cg.ResetPassState(pass);
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

        public static void SetArraySize(IntPtr param, int size)
        {
            Cg.SetArraySize(param, size);
        }

        public static bool SetBoolAnnotation(IntPtr annotation, bool value)
        {
            return Cg.SetBoolAnnotation(annotation, value);
        }

        public static void SetBufferData(IntPtr buffer, int size, IntPtr data)
        {
            Cg.SetBufferData(buffer, size, data);
        }

        public static void SetBufferSubData(IntPtr buffer, int offset, int size, IntPtr data)
        {
            Cg.SetBufferSubData(buffer, offset, size, data);
        }

        public static bool SetEffectName(IntPtr effect, string name)
        {
            return Cg.SetEffectName(effect, name);
        }

        public static void SetEffectParameterBuffer(IntPtr param, IntPtr buffer)
        {
            Cg.SetEffectParameterBuffer(param, buffer);
        }

        public static void SetLastListing(IntPtr effect, string listing)
        {
            Cg.SetLastListing(effect, listing);
        }

        public static void SetMatrixParameter(IntPtr param, float[] matrix)
        {
            Cg.SetMatrixParameter(param, matrix, Order.RowMajor);
        }

        public static void SetMatrixParameter(IntPtr param, float[] matrix, Order order)
        {
            Cg.SetMatrixParameter(param, matrix, order);
        }

        public static void SetMatrixParameter(IntPtr param, double[] matrix)
        {
            Cg.SetMatrixParameter(param, matrix, Order.RowMajor);
        }

        public static void SetMatrixParameter(IntPtr param, double[] matrix, Order order)
        {
            Cg.SetMatrixParameter(param, matrix, order);
        }

        public static void SetMatrixParameter(IntPtr param, int[] matrix)
        {
            Cg.SetMatrixParameter(param, matrix, Order.RowMajor);
        }

        public static void SetMatrixParameter(IntPtr param, int[] matrix, Order order)
        {
            Cg.SetMatrixParameter(param, matrix, order);
        }

        public static void SetMultiDimArraySize(IntPtr param, int[] sizes)
        {
            Cg.SetMultiDimArraySize(param, sizes);
        }

        public static void SetParameter(IntPtr param, float x)
        {
            Cg.SetParameter(param, x);
        }

        public static void SetParameter(IntPtr param, float x, float y, float z)
        {
            Cg.SetParameter(param, x, y, z);
        }

        public static void SetParameter(IntPtr param, int[] v)
        {
            Cg.SetParameter(param, v);
        }

        public static void SetParameter(IntPtr param, double[] v)
        {
            Cg.SetParameter(param, v);
        }

        public static void SetParameter(IntPtr param, float[] v)
        {
            Cg.SetParameter(param, v);
        }

        public static void SetParameter(IntPtr param, float x, float y)
        {
            Cg.SetParameter(param, x, y);
        }

        public static void SetParameter(IntPtr param, float x, float y, float z, float w)
        {
            Cg.SetParameter(param, x, y, z, w);
        }

        public static void SetParameter(IntPtr param, double x)
        {
            Cg.SetParameter(param, x);
        }

        public static void SetParameter(IntPtr param, int x)
        {
            Cg.SetParameter(param, x);
        }

        public static void SetParameter(IntPtr param, double x, double y)
        {
            Cg.SetParameter(param, x, y);
        }

        public static void SetParameter(IntPtr param, int x, int y)
        {
            Cg.SetParameter(param, x, y);
        }

        public static void SetParameter(IntPtr param, double x, double y, double z)
        {
            Cg.SetParameter(param, x, y, z);
        }

        public static void SetParameter(IntPtr param, int x, int y, int z)
        {
            Cg.SetParameter(param, x, y, z);
        }

        public static void SetParameter(IntPtr param, double x, double y, double z, double w)
        {
            Cg.SetParameter(param, x, y, z, w);
        }

        public static void SetParameter(IntPtr param, int x, int y, int z, int w)
        {
            Cg.SetParameter(param, x, y, z, w);
        }

        public static void SetParameterSemantic(IntPtr param, string semantic)
        {
            Cg.SetParameterSemantic(param, semantic);
        }

        public static void SetParameterValue(IntPtr param, double[] vals)
        {
            Cg.SetParameterValue(param, vals, Order.RowMajor);
        }

        public static void SetParameterValue(IntPtr param, double[] vals, Order order)
        {
            Cg.SetParameterValue(param, vals, order);
        }

        public static void SetParameterValue(IntPtr param, float[] vals)
        {
            Cg.SetParameterValue(param, vals, Order.RowMajor);
        }

        public static void SetParameterValue(IntPtr param, float[] vals, Order order)
        {
            Cg.SetParameterValue(param, vals, order);
        }

        public static void SetParameterValue(IntPtr param, int[] vals)
        {
            Cg.SetParameterValue(param, vals, Order.RowMajor);
        }

        public static void SetParameterValue(IntPtr param, int[] vals, Order order)
        {
            Cg.SetParameterValue(param, vals, order);
        }

        public static void SetParameterVariability(IntPtr param, int vary)
        {
            Cg.SetParameterVariability(param, vary);
        }

        public static void SetPassState(IntPtr pass)
        {
            Cg.SetPassState(pass);
        }

        public static void SetProgramBuffer(CgProgram program, int bufferIndex, IntPtr buffer)
        {
            Cg.SetProgramBuffer(program.Handle, bufferIndex, buffer);
        }

        public static bool SetProgramStateAssignment(IntPtr stateassignment, CgProgram program)
        {
            return Cg.SetProgramStateAssignment(stateassignment, program.Handle);
        }

        public static void SetSamplerState(IntPtr param)
        {
            Cg.SetSamplerState(param);
        }

        public static bool SetSamplerStateAssignment(IntPtr stateassignment, IntPtr param)
        {
            return Cg.SetSamplerStateAssignment(stateassignment, param);
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

        public static void SetStateCallbacks(IntPtr state, Cg.CgStateCallbackDelegate set, Cg.CgStateCallbackDelegate reset, Cg.CgStateCallbackDelegate validate)
        {
            Cg.SetStateCallbacks(state, set, reset, validate);
        }

        public static void SetStateLatestProfile(IntPtr state, ProfileType profile)
        {
            Cg.SetStateLatestProfile(state, profile);
        }

        public static void SetStringParameterValue(IntPtr param, string str)
        {
            Cg.SetStringParameterValue(param, str);
        }

        public static bool SetTextureStateAssignment(IntPtr stateassignment, IntPtr param)
        {
            return Cg.SetTextureStateAssignment(stateassignment, param);
        }

        public static void UnmapBuffer(IntPtr buffer)
        {
            Cg.UnmapBuffer(buffer);
        }

        public static void UpdatePassParameters(IntPtr pass)
        {
            Cg.UpdatePassParameters(pass);
        }

        public static bool ValidateTechnique(IntPtr technique)
        {
            return Cg.ValidateTechnique(technique);
        }

        #endregion Public Static Methods

        #endregion Methods
    }
}