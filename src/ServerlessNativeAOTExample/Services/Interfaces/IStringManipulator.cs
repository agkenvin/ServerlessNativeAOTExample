using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerlessNativeAOTExample.Models;

namespace ServerlessNativeAOTExample.Services.Interfaces
{
    public interface IStringManipulator
    {
        List<StringModel> toUpper(string input1, string input2);
        List<StringModel> toLower(string input1, string input2);
    }
}