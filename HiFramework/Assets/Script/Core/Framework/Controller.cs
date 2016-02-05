﻿using System;

namespace HiFramework
{
    public class Controller : IController
    {
        public static Action<Message> viewEventHandler;
        private bool disposed = false;

        public void Dispatch(object paramKey, Message paramMessage)
        {
            Facade.Mediator.Dispatch(paramKey, paramMessage);
        }

        public void Register<T>(object paramKey) where T : IController
        {
            Facade.Mediator.Register<T>(paramKey);
        }

        public virtual void OnMessage(Message paramMessage)
        {

        }

        public void Remove(object paramKey)
        {
            Facade.Mediator.Remove(paramKey);
            Dispose();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~Controller()
        {
            Dispose(false);
        }
        protected virtual void Dispose(bool paramDisposing)
        {
            if (disposed)
                return;
            if (paramDisposing)
            {
                viewEventHandler = null;
            }
            disposed = true;
        }
    }
}
