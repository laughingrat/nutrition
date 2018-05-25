using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nutrition.Models
{
    public sealed class Enums
    {
        public enum Options : byte {
           light = 0,
           middle = 1,
           heavy = 2
        }

        public enum Status : byte {
            InProgress = 0,
            Success=1
        }
    }
}