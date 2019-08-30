using Microsoft.VisualStudio.TestTools.UnitTesting;
using HiFramework.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiFramework.Unity.Tests
{
    [TestClass()]
    public class FsmTests
    {
        [TestInitialize]
        public void FrameworkInitTest()
        {
            Center.Init(new UnityBinder());
        }

        [TestCleanup]
        public void FrameworkDisposeTest()
        {
            Center.Dispose();
        }

        [TestMethod()]
        public void FsmTest()
        {
            var fsm = new Fsm(new StateChangeRule());
        }

        [TestMethod()]
        public void RegistStateTest()
        {
            var fsm = new Fsm(new StateChangeRule());
            fsm.RegistState(new Idle("idle", fsm));
            fsm.RegistState(new Run("run", fsm));
        }

        [TestMethod()]
        public void InitTest()
        {
            var fsm = new Fsm(new StateChangeRule());
            fsm.RegistState(new Idle("idle", fsm));
            fsm.RegistState(new Run("run", fsm));
            fsm.Init("idle");
        }

        [TestMethod()]
        public void ChangeStateTest()
        {
            var fsm = new Fsm(new StateChangeRule());
            fsm.RegistState(new Idle("idle", fsm));
            fsm.RegistState(new Run("run", fsm));
            fsm.Init("idle");
            fsm.ChangeState("run");
        }

        [TestMethod()]
        public void TickTest()
        {
            var fsm = new Fsm(new StateChangeRule());
            fsm.RegistState(new Idle("idle", fsm));
            fsm.RegistState(new Run("run", fsm));
            fsm.Init("idle");
            fsm.Tick(0.1f);
        }

        [TestMethod()]
        public void DisposeTest()
        {
            var fsm = new Fsm(new StateChangeRule());
            fsm.RegistState(new Idle("idle", fsm));
            fsm.Init("idle");
            fsm.Dispose();
        }

        private class StateChangeRule : IStateChangeRule
        {
            public bool IsCanChangeState(IState current, IState next)
            {
                if (current.Name == "idle")
                {
                    if (next.Name == "run")
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        private class Idle : StateBase
        {
            public Idle(string stateName, Fsm fsm) : base(stateName, fsm)
            {
            }

            public override void Init()
            {
            }

            public override void Tick(float time)
            {
            }

            public override void Exit()
            {
            }
        }

        private class Run : StateBase
        {
            public Run(string stateName, Fsm fsm) : base(stateName, fsm)
            {
            }

            public override void Init()
            {
            }

            public override void Tick(float time)
            {
            }

            public override void Exit()
            {
            }

            private void Test()
            {
                base.ChangeState("fly");
            }
        }
    }
}