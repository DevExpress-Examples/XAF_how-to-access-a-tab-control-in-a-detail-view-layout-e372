using System;

using DevExpress.Xpo;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace WebSolution.Module {
    [DefaultClassOptions]
    public class MyPerson : Person {
        public MyPerson(Session session) : base(session) { }
        [Association("MyPerson-MyTasks")]
        public XPCollection<MyTask> MyTasks {
            get {
                return GetCollection<MyTask>("MyTasks");
            }
        }
    }
    public class MyTask : Task {
        public MyTask(Session session) : base(session) { }
        private MyPerson _myPerson;
        [Association("MyPerson-MyTasks")]
        public MyPerson MyPerson {
            get {
                return _myPerson;
            }
            set {
                SetPropertyValue("MyPerson", ref _myPerson, value);
            }
        }
    }
}
