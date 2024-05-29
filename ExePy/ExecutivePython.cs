using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExePy
{
    [Transaction(TransactionMode.Manual)]
    public class ExecutivePython : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var setting = new Dictionary<string, object>() { { "Frames", true }, { "FullFrames", true } };
            var exePy = IronPython.Hosting.Python.CreateEngine(setting);
            exePy.Runtime.LoadAssembly(typeof(Autodesk.Revit.UI.TaskDialog).Assembly);
            string filePath = @"U:\17_TraningAdvanceDynamo\Data\Python\Alert.py";
            exePy.ExecuteFile(filePath);
            return Result.Succeeded;
        }
    }
}
