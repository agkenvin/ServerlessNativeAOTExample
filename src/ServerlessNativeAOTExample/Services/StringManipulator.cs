using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerlessNativeAOTExample.Models;
using ServerlessNativeAOTExample.Services.Interfaces;

namespace ServerlessNativeAOTExample.Services
{
    public class StringManipulator : IStringManipulator
    {
        public List<StringModel> toLower(string input1, string input2)
        {
            List<StringModel> list = new List<StringModel>();   
            list.Add(new StringModel() { Value = input1.ToLower() });
            list.Add(new StringModel() { Value = input2.ToLower() });
            return list;
        }
        public List<StringModel> toUpper(string input1, string input2)
        {
            List<StringModel> list = new List<StringModel>();   
            list.Add(new StringModel() { Value = input1.ToUpper() });
            list.Add(new StringModel() { Value = input2.ToUpper() });
            return list;
        }
    }
}