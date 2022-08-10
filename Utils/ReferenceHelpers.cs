﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StormSurge.Utils.ReferenceHelper
{
    public class InstReference<T> where T : class
    {
        Func<T> refMethod;
        public InstReference(Func<T> RefMethod)
        {
            this.refMethod = RefMethod;
        }
        T _backingField;
        public T Reference
        { 
            get
            {
                return Reference ??= refMethod();
            }
            private set
            {Reference = value;}
        }
        public static implicit operator T(InstReference<T> self)
        {
            return self.Reference;
        }
        public static implicit operator InstReference<T>(Func<T> newMethod)
        {
            return new InstReference<T>(newMethod);
        }
    }
}
