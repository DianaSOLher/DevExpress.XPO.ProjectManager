using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ProjectManager.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Employee : BaseObject
    { 
        public Employee(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        
        string _name;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [RuleRequiredField]
        public string Name
        {
            get => _name;
            set => SetPropertyValue(nameof(Name), ref _name, value);
        }

        string _lastname;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]

        public string LastName
        {
            get => _lastname;
            set => SetPropertyValue(nameof(LastName), ref _lastname, value);
        }


        DateTime _birthday;

        public DateTime Birthday
        {
            get => _birthday;
            set => SetPropertyValue(nameof(Birthday), ref _birthday, value);
        }

        bool _active;
        public bool Active
        {
            get => _active;
            set => SetPropertyValue(nameof(Active), ref _active, value);
        }

        [Association("Employee-Projects")]

        public XPCollection<Project> Projects
        {
            get
            {
                return GetCollection<Project>(nameof(Projects));
            }
        }

        byte[] image;
        [ImageEditor]
        public byte[] Image
        {
            get => image;
            set => SetPropertyValue(nameof(Image), ref image, value);
        }
    }
}