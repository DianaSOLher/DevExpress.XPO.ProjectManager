using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using ProjectManager.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Module.Controllers
{
    public class TaskCompletedController : ViewController
    {
        SimpleAction Complete;
        public TaskCompletedController()
        {
            // Target required Views (use the TargetXXX properties) and create their Actions.
            TargetObjectType = typeof(ProjectTask);

            Complete = new SimpleAction(this, "Complete", PredefinedCategory.Edit);
            Complete.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
            Complete.Execute += Complete_Execute;
        }

        private void Complete_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var currentObj = e.CurrentObject as ProjectTask;
            if(currentObj!=null )
            {
                currentObj.Status = Status.Completed;
            }

            if (this.ObjectSpace.IsModified)
                this.ObjectSpace.CommitChanges();

        }

        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
    }
}
