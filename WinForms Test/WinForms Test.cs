using cAlgo.API;
using System.Threading;

namespace cAlgo.Robots
{
    [Robot(TimeZone = TimeZones.UTC, AccessRights = AccessRights.FullAccess)]
    public class WinFormsTest : Robot
    {
        private MainForm _mainForm;

        protected override void OnStart()
        {
            // You can pass your indicator/cBot to form and start interacting with it via form controls
            _mainForm = new MainForm(this);

            // You have to create a new thread to show the form, so it will not block the cBot main thread
            var staThread = new Thread(() => _mainForm.ShowDialog());

            // The form must be executed on a STA thread
            staThread.SetApartmentState(ApartmentState.STA);

            staThread.Start();
        }

        protected override void OnStop()
        {
            _mainForm.Close();
        }
    }
}