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
namespace CgOO
{
    using System;

    public abstract class WrapperObject : IDisposable
    {
        #region Constructors

        protected WrapperObject(IntPtr handle)
        {
            this.OwnsHandle = true;
            this.Handle = handle;
        }

        ~WrapperObject()
        {
            if (this.OwnsHandle)
            {
                this.Dispose(false);
            }
        }

        #endregion Constructors

        #region Properties

        #region Public Properties

        public IntPtr Handle
        {
            get;
            private set;
        }

        #endregion Public Properties

        #region Protected Internal Properties

        protected internal bool OwnsHandle
        {
            get;
            set;
        }

        #endregion Protected Internal Properties

        #endregion Properties

        #region Methods

        #region Public Static Methods

        //public static implicit operator IntPtr(WrapperObject obj)
        //{
        //    return obj.Handle;
        //}
        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(WrapperObject left, WrapperObject right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(WrapperObject left, WrapperObject right)
        {
            return left.Equals(right);
        }

        #endregion Public Static Methods

        #region Public Methods

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            this.Dispose(true);
            this.Handle = IntPtr.Zero;
            GC.SuppressFinalize(this);
        }

        public bool Equals(WrapperObject other)
        {
            return other != null && this.Handle == other.Handle;
        }

        public override bool Equals(object obj)
        {
            return obj != null && (obj is WrapperObject && this.Equals((WrapperObject)obj));
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return this.Handle.GetHashCode();
        }

        #endregion Public Methods

        #region Protected Methods

        protected virtual void Dispose(bool disposing)
        {
        }

        #endregion Protected Methods

        #endregion Methods
    }
}