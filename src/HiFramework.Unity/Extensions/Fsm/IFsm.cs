/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework.Unity
 * Author: hiramtan@live.com
 ****************************************************************************/
 
 using System;

namespace HiFramework.Unity
{
    public interface IFsm : IDisposable
    {
        /// <summary>
        /// Current state
        /// </summary>
        IState CurrentState { get; }

        /// <summary>
        /// Init regist state and it's name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="state"></param>
        void RegistState(StateBase state);

        /// <summary>
        /// Init state machine
        /// </summary>
        /// <param name="stateName"></param>
        void Init(string stateName);

        /// <summary>
        /// Change state
        /// </summary>
        /// <param name="stateName"></param>
        void ChangeState(string stateName);

        /// <summary>
        /// Tick logic
        /// </summary>
        /// <param name="time"></param>
        void Tick(float time);
    }
}