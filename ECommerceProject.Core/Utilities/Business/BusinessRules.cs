using System;
using System.Collections.Generic;
using System.Text;
using ECommerceProject.Core.Utilities.Results;

namespace ECommerceProject.Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }

            return null;
        }


    }
}
