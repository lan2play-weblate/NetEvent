﻿namespace NetEvent.Shared.Config
{
    public abstract class ValueType
    {
        protected ValueType()
        {
        }

        public abstract string DefaultValueSerialized { get; }
    }
}
