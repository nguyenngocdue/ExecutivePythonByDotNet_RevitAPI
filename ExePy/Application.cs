using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace ExePy
{
  
    public class Application : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            // Tạo tab ribbon tùy chỉnh
            string tabName = "CustomTab";
            application.CreateRibbonTab(tabName);

            // Tạo một panel ribbon trong tab
            RibbonPanel panel = application.CreateRibbonPanel(tabName, "CustomPanel");

            // Tạo một nút bấm để kích hoạt lệnh
            PushButtonData buttonData = new PushButtonData(
                "CommandButton",
                "Execute Python",
                Assembly.GetExecutingAssembly().Location,
                "ExePy.RunPython"
            );

            PushButton pushButton = panel.AddItem(buttonData) as PushButton;
            pushButton.ToolTip = "Execute a Python script";


            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }

}

