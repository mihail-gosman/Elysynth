using System;
using System.Collections.Generic;
using System.Numerics;
using Core;
using Models;

namespace Management
{
    class FieldsHandler
    {
        public static void AddParticle(Field field, List<Field> fields)
        {
            /*
            TODO: Incomplete code.
            No checking of variable 'ID' yet. 
            Need to add validation for 'ID' later.
            */

            field.Id = fields.Count + 1;
            fields.Add(field);
        }
    }
}
