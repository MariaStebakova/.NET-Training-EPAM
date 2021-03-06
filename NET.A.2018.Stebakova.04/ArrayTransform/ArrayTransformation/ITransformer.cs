﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayTransform.ArrayTransformation
{
    public interface ITransformer<in TInput, out TOutput>
    {
        TOutput Transform(TInput number);
    }
}
