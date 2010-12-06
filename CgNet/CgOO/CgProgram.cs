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
namespace CgNet.CgOO
{
    using System;

    using CgNet;

    public sealed class CgProgram : WrapperObject
    {
        #region Constructors

        internal CgProgram(IntPtr handle)
            : base(handle)
        {
        }

        #endregion Constructors

        #region Properties

        #region Public Properties

        public CgContext Context
        {
            get
            {
                var retValue = new CgContext(Cg.GetProgramContext(this.Handle))
                {
                    OwnsHandle = false
                };

                return retValue;
            }
        }

        public bool IsCompiled
        {
            get
            {
                return Cg.IsProgramCompiled(this.Handle);
            }
        }

        public bool IsProgram
        {
            get
            {
                return Cg.IsProgram(this.Handle);
            }
        }

        public CgProgram NextProgram
        {
            get
            {
                return new CgProgram(Cg.GetNextProgram(this.Handle))
                               {
                                   OwnsHandle = false
                               };
            }
        }

        public int NumProgramDomains
        {
            get
            {
                return Cg.GetNumProgramDomains(this.Handle);
            }
        }

        public ProfileType Profile
        {
            get
            {
                return Cg.GetProgramProfile(this.Handle);
            }

            set
            {
                Cg.SetProgramProfile(this.Handle, value);
            }
        }

        public Domain ProgramDomain
        {
            get
            {
                return Cg.GetProgramDomain(this.Handle);
            }
        }

        public ProgramInput ProgramInput
        {
            get
            {
                return Cg.GetProgramInput(this.Handle);
            }
        }

        public string[] ProgramOptions
        {
            get
            {
                return Cg.GetProgramOptions(this.Handle);
            }
        }

        public ProgramOutput ProgramOutput
        {
            get
            {
                return Cg.GetProgramOutput(this.Handle);
            }
        }

        public ProgramType Type
        {
            get;
            internal set;
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Static Methods

        public static CgProgram CombinePrograms(CgProgram exe1, CgProgram exe2)
        {
            return new CgProgram(Cg.CombinePrograms(exe1.Handle, exe2.Handle));
        }

        public static CgProgram CombinePrograms(CgProgram exe1, CgProgram exe2, CgProgram exe3)
        {
            return new CgProgram(Cg.CombinePrograms(exe1.Handle, exe2.Handle, exe3.Handle));
        }

        public static CgProgram CombinePrograms(CgProgram exe1, CgProgram exe2, CgProgram exe3, CgProgram exe4)
        {
            return new CgProgram(Cg.CombinePrograms(exe1.Handle, exe2.Handle, exe3.Handle, exe4.Handle));
        }

        public static CgProgram CombinePrograms(CgProgram exe1, CgProgram exe2, CgProgram exe3, CgProgram exe4, CgProgram exe5)
        {
            return new CgProgram(Cg.CombinePrograms(exe1.Handle, exe2.Handle, exe3.Handle, exe4.Handle, exe5.Handle));
        }

        public static CgProgram CombinePrograms(params CgProgram[] programs)
        {
            var buf = new IntPtr[programs.Length];
            for (int i = 0; i < programs.Length; i++)
            {
                buf[i] = programs[i].Handle;
            }

            return new CgProgram(Cg.CombinePrograms(buf));
        }

        public static CgProgram Create(CgContext context, ProgramType type, string source, ProfileType profile, string entry, params string[] args)
        {
            return new CgProgram(Cg.CreateProgram(context.Handle, type, source, profile, entry, args))
                   {
                       Type = type,
                   };
        }

        public static CgProgram CreateFromFile(CgContext context, ProgramType type, string file, ProfileType profile, string entry, params string[] args)
        {
            return new CgProgram(Cg.CreateProgramFromFile(context.Handle, type, file, profile, entry, args))
                   {
                       Type = type,
                   };
        }

        #endregion Public Static Methods

        #region Public Methods

        public CgProgram Combine(CgProgram exe1)
        {
            return new CgProgram(Cg.CombinePrograms(this.Handle, exe1.Handle));
        }

        public void Compile()
        {
            Cg.CompileProgram(this.Handle);
        }

        public CgProgram Copy()
        {
            return new CgProgram(Cg.CopyProgram(this.Handle));
        }

        public float[] EvaluateProgram(int ncomps, int nx, int ny, int nz)
        {
            return Cg.EvaluateProgram(this.Handle, ncomps, nx, ny, nz);
        }

        public ParameterType GetNamedUserType(string name)
        {
            return Cg.GetNamedUserType(this.Handle, name);
        }

        public ProfileType GetProgramDomainProfile(int index)
        {
            return Cg.GetProgramDomainProfile(this.Handle, index);
        }

        public CgProgram GetProgramDomainProgram(int index)
        {
            return new CgProgram(Cg.GetProgramDomainProgram(this.Handle, index))
                   {
                       OwnsHandle = false
                   };
        }

        public string GetProgramString(SourceType sourceType)
        {
            return Cg.GetProgramString(this.Handle, sourceType);
        }

        public ParameterType GetUserType(int index)
        {
            return Cg.GetUserType(this.Handle, index);
        }

        public void SetLastListing(string listing)
        {
            Cg.SetLastListing(this.Handle, listing);
        }

        public void SetPassProgramParameters()
        {
            Cg.SetPassProgramParameters(this.Handle);
        }

        public void UpdateProgramParameters()
        {
            Cg.UpdateProgramParameters(this.Handle);
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        protected override void Dispose(bool disposing)
        {
            if (this.Handle != IntPtr.Zero)
            {
                Cg.DestroyProgram(this.Handle);
            }
        }

        #endregion Protected Methods

        #endregion Methods
    }
}